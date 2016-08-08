using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace MVC4.PROJECT.Areas.Admin.Controllers
{
    [Authorize(Roles = "administrator, codeadmin")]
    public class CategoriesController : BaseLangController
    {
        //
        // GET: /Admin/Categories/
        MVCDbContext db = new MVCDbContext();
        public ActionResult Index()
        {
            List<CW_Category> objbind = new List<CW_Category>();
            ViewBag.ListCateEdit = GetTreeTable(null, objbind, "");
            IEnumerable<CW_Category> cate = db.CW_Category;
            ViewBag.CountCate = cate.ToList().Count();
            return View();
        }

        public ActionResult Add()
        {
            List<CW_Category> objbind = new List<CW_Category>();
            ViewBag.ListCateEdit = new SelectList(GetTreeTable(null, objbind, ""), "ID", "Title");
            ViewBag.SelectListItems = new MultiSelectList(db.CW_Menu.ToList<CW_Menu>(), "MenuCode", "Title");
            return View();
        }
        /// <summary>
        /// them moi danh muc
        /// </summary>
        /// <param name="model"></param>
        /// <param name="lstmenu"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CW_Category model, List<string> lstmenu)
        {
            if (lstmenu != null)
            {
                lstmenu.ForEach(x => model.CW_menu_category.Add(
                   new CW_Menu_Category() { MenuCode = x.ToString(), SortOrder = 1 }
                ));
            }
            if (model.MetaTitle == null)
                model.MetaTitle = model.Title;
            model.CategoryCode = COMMOM.Filter.FilterChar(model.Title);
            model.CreatedDate = DateTime.Now;
            model.LanguageCode = Session["language"].ToString();
            model.KeySearch = model.Title + " , " + COMMOM.Filter.FilterChar(model.Title);
            db.Set<CW_Category>().Add(model);
            db.SaveChanges();

            ViewBag.SelectListItems = new MultiSelectList(db.CW_Menu.ToList<CW_Menu>(), "MenuCode", "Title");
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Thu muc con
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="objcate"></param>
        /// <returns></returns>
        [NonAction]
        public List<CW_Category> catechil(int? parent, List<CW_Category> objcate)
        {
            List<CW_Category> objbind = new List<CW_Category>();
            foreach (CW_Category info in objcate)
            {
                if (info.ParentID == parent)
                {
                    objbind.Add(info);
                }
            }
            return objbind;
        }
        /// <summary>
        /// Muc cha
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="objcate"></param>
        /// <param name="space"></param>
        /// <returns></returns>
        [NonAction]
        public List<CW_Category> GetTreeTable(int? parent, List<CW_Category> objcate, string space)
        {
            var lang = Session["language"].ToString();
            IEnumerable<CW_Category> objtemp = db.CW_Category.Where(x => x.LanguageCode.Equals(lang)).OrderBy(x => x.Order);
            List<CW_Category> objbind = catechil(parent, objtemp.ToList());
            if (objbind != null && objbind.Count > 0)
            {
                CW_Category objtab = null;
                for (int i = 0; i < objbind.Count; i++)
                {
                    objtab = (CW_Category)objbind[i];
                    objtab.Title = space + objtab.Title;
                    objcate.Add(objtab);
                    GetTreeTable(objtab.ID, objcate, space + "--- ");
                }
            }
            return objcate;
        }

        public ActionResult Edit(int id)
        {
            //danh mục cha
            List<CW_Category> objbind = new List<CW_Category>();
            ViewBag.ListCateEdit = new SelectList(GetTreeTable(null, objbind, ""), "ID", "Title");

            var cate = db.Set<CW_Category>().Find(id);
            cate.Title = cate.Title.Replace("--- ", "");

            #region "kiểu danh mục"
            //tất cả menu
            ViewBag.AllSelectListItems = new MultiSelectList(db.CW_Menu.ToList<CW_Menu>(), "MenuCode", "Title");
            //menu được chọn
            List<CW_Menu> selectlist = new List<CW_Menu>();
            IEnumerable<CW_Menu_Category> listcatemenu = db.CW_Menu_Category.Where(a => a.CategoryID == id);

            foreach (CW_Menu_Category item in listcatemenu)
            {
                var menu = db.Set<CW_Menu>().Find(item.MenuCode);
                if (menu != null)
                {
                    selectlist.Add((CW_Menu)menu);
                }
            }
            if (selectlist.Count > 0)
            {
                ViewBag.SelectListItems = selectlist;
            }
            #endregion
            return View(cate);
        }
        /// <summary>
        /// sua danh muc
        /// </summary>
        /// <param name="category"></param>
        /// <param name="lstmenuedit"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "")]CW_Category category, List<string> lstmenuedit)
        {
            //lấy ra menu không được chọn
            IEnumerable<CW_Menu> objmenunoselect = db.CW_Menu;
            //Nếu có menu muốn edit
            if (lstmenuedit != null)
            {
                //đối tượng để kiểm tra sự tồn tại của menu được chọn trong data hay chưa
                CW_Menu_Category obj = null;
                //đối tượng dùng để thêm mới menu và data.
                CW_Menu_Category addmenucate = null;
                foreach (string str in lstmenuedit)
                {
                    obj = db.CW_Menu_Category.Where(x => x.CategoryID == category.ID && x.MenuCode.Equals(str)).FirstOrDefault();
                    if (obj == null) //chưa có menu này thì thêm vào
                    {
                        addmenucate = new CW_Menu_Category();
                        addmenucate.CategoryID = category.ID;
                        addmenucate.MenuCode = str;
                        addmenucate.SortOrder = 1;
                        db.Set<CW_Menu_Category>().Add(addmenucate);
                        db.SaveChanges();
                    }
                    objmenunoselect = objmenunoselect.Where(x => !x.MenuCode.Equals(str));
                }
                //menu không được chọn nữa, nhưng đang tồn tại trong bảng CW_Menu_Category thì xóa đi
                if (objmenunoselect != null)
                {
                    CW_Menu_Category objMenuCategory = null;
                    foreach (var item in objmenunoselect)
                    {
                        objMenuCategory = db.CW_Menu_Category.Where(x => x.CategoryID == category.ID && x.MenuCode.Equals(item.MenuCode)).FirstOrDefault();
                        if (objMenuCategory != null)
                        {
                            db.CW_Menu_Category.Attach(objMenuCategory);
                            db.Set<CW_Menu_Category>().Remove(objMenuCategory);
                        }
                    }
                    db.SaveChanges();
                }
            }
            else //xóa bản ghi ở bảng CW_Menu_Category
            {
                IEnumerable<CW_Menu_Category> menucate = (from s in db.CW_Menu_Category
                                                          where s.CategoryID == category.ID
                                                          select s);
                foreach (CW_Menu_Category obj in menucate)
                {
                    db.CW_Menu_Category.Attach(obj);
                    db.Set<CW_Menu_Category>().Remove(obj);
                }
                db.SaveChanges();
            }


            category.MetaTitle = category.Title;
            category.CategoryCode = COMMOM.Filter.FilterChar(category.Title);
            category.KeySearch = category.Title + " , " + COMMOM.Filter.FilterChar(category.Title);
            db.CW_Category.Attach(category);
            db.Entry(category).Property(a => a.Title).IsModified = true;
            db.Entry(category).Property(a => a.TypeCode).IsModified = true;
            db.Entry(category).Property(a => a.CategoryCode).IsModified = true;
            db.Entry(category).Property(a => a.Description).IsModified = true;
            db.Entry(category).Property(a => a.ParentID).IsModified = true;
            db.Entry(category).Property(a => a.Order).IsModified = false;
            db.Entry(category).Property(a => a.MetaTitle).IsModified = true;
            db.Entry(category).Property(a => a.MetaDescription).IsModified = true;
            db.Entry(category).Property(a => a.KeySearch).IsModified = true;
            db.Entry(category).Property(a => a.Link).IsModified = true;
            db.Entry(category).Property(a => a.Icon).IsModified = true;
            db.Entry(category).Property(a => a.Target).IsModified = true;
            db.Entry(category).Property(a => a.IsActive).IsModified = true;
            db.Entry(category).Property(a => a.CreatedDate).IsModified = false;
            db.Entry(category).Property(a => a.LanguageCode).IsModified = false;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        /// <summary>
        /// xoa tung danh muc 1
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteOneItem(int item)
        {
            //xóa cấp con trước
            var chil = db.CW_Category.Where(x => x.ParentID == item);
            if (chil != null && chil.Count() > 0)
            {
                foreach (var items in chil)
                {
                    var catedeltes = db.CW_Category.Attach(items);
                    db.Set<CW_Category>().Remove(catedeltes);
                }
                db.SaveChanges();
            }

            var cate = db.Set<CW_Category>().Find(item);
            if (cate != null)
            {
                var catedelte = db.CW_Category.Attach(cate);
                db.Set<CW_Category>().Remove(catedelte);
                db.SaveChanges();
            }

            return Json("Delete", JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// xoa nhieu danh muc
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string id)
        {
            if (!id.Equals(""))
            {
                CW_Category obj = new CW_Category();
                int cateid = 0;
                string[] arr = id.Split(',');
                for (int i = 0; i < arr.Count() - 1; i++)
                {
                    cateid = int.Parse(arr[i].ToString());
                    obj = db.CW_Category.Find(cateid);
                    if (obj != null)
                    {
                        var catedelte = db.CW_Category.Attach(obj);
                        db.Set<CW_Category>().Remove(catedelte);
                    }
                }
                db.SaveChanges();
            }
            return Json("Delete", JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// update trang thai
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isactive"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateIsActive(int id, bool isactive)
        {
            CW_Category category = db.CW_Category.Find(id);
            if (category != null)
            {
                db.Set<CW_Category>().Attach(category);
                if (isactive)
                {
                    category.IsActive = false;
                }
                else
                {
                    category.IsActive = true;
                }

                db.SaveChanges();
            }
            return Json("chamara", JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// update ten danh muc
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateTitle(int id, string title)
        {
            CW_Category cate = db.CW_Category.Find(id);
            if (cate != null)
            {
                db.Set<CW_Category>().Attach(cate);
                cate.Title = title;
                db.SaveChanges();
            }
            return Json("chamara", JsonRequestBehavior.AllowGet);
        }
    }
}
