using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace MVC4.PROJECT.Areas.Admin.Controllers
{
    [Authorize(Roles = "administrator, codeadmin")]
    public class MenuController : BaseController
    {
        //
        // GET: /Admin/Menu/
        MVCDbContext db=new MVCDbContext();
        public ActionResult Index(string id)
        {
            if (String.IsNullOrEmpty(id))
                id = "menu-top";
            ViewBag.menucode = id;
            CW_Menu obj = db.CW_Menu.Where(x => x.MenuCode == id).First();
            ViewBag.menutitle = obj.Title;
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult _ListCateByMenu(string menucode)
        {
            if (String.IsNullOrEmpty(menucode))
                menucode = "menu-top";
            var menu = db.CW_Menu.OrderBy(x => x.Order);
            CW_Menu obj = db.CW_Menu.Where(x => x.MenuCode == menucode).First();
            ViewBag.menutitle = obj.Title;
            ViewBag.menucode = menucode;

            IEnumerable<CW_Category> category = from cate in db.CW_Category
                                             join cate_menu in db.CW_Menu_Category
                                             on cate.ID equals cate_menu.CategoryID
                                             where cate_menu.MenuCode.Equals(menucode)
                                             orderby cate_menu.SortOrder
                                             select cate;
            ViewBag.countcate = category.ToList().Count;
            return PartialView(menu);
        }

        [HttpPost]
        public PartialViewResult _ListCateByMenu(string menucode, string catetitle)
        {
            var menucate = db.CW_Menu_Category.Where(x => x.Category.Title.ToLower().Equals(catetitle));
            var menu = db.CW_Menu.OrderBy(x => x.Order);
            if (menucate == null)
            {
                var category = db.CW_Category.Where(x => x.Title.Equals(catetitle)).FirstOrDefault();
                CW_Menu_Category obj = new CW_Menu_Category();
                obj.MenuCode = menucode;
                obj.CategoryID = category.ID;
                obj.SortOrder = 1;
                db.Set<CW_Menu_Category>().Add(obj);
                db.SaveChanges();
            }
            else
            {
                ViewBag.Message = "Danh mục này đã tồn tại trong menu này !";
            }
            ViewBag.menucode = menucode;
            return PartialView("_ListCateByMenu", menu);
        }
        public JsonResult AutoCompleteCate(string term)
        {
            var result = (from r in db.CW_Category

                          where r.Title.ToLower().Contains(term.ToLower())

                          select new { r.ID, r.Title }).Distinct();

            return Json(result, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// theem menu
        /// </summary>
        /// <param name="menucode"></param>
        /// <param name="categoryid"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCate(string menucode, int categoryid)
        {
            //kiểm tra xem có danh mục trong menu hay chưa?
            var objtest = db.CW_Menu_Category.Where(x => x.CategoryID == categoryid && x.MenuCode == menucode).FirstOrDefault();
            if (objtest == null)
            {
                CW_Menu_Category obj = new CW_Menu_Category();
                obj.MenuCode = menucode;
                obj.CategoryID = categoryid;
                obj.SortOrder = 1;
                db.Set<CW_Menu_Category>().Add(obj);
                db.SaveChanges();
                ViewBag.menucode = menucode;
            }

            return Json("Index", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteItem(int item, string menu)
        {
            var cate = db.Set<CW_Menu_Category>().Where(x => x.CategoryID == item && x.MenuCode == menu).FirstOrDefault();
            if (cate != null)
            {
                var catedelte = db.CW_Menu_Category.Attach(cate);
                db.Set<CW_Menu_Category>().Remove(catedelte);
                db.SaveChanges();
            }

            return Json("Delete", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateOrder(int item, int order, string menu)
        {
            var menucate = db.CW_Menu_Category.Where(x => x.CategoryID == item && x.MenuCode == menu).FirstOrDefault();
            if (menucate != null)
            {
                db.Set<CW_Menu_Category>().Attach(menucate);
                menucate.SortOrder = order;
                db.SaveChanges();
            }
            return Json("chamara", JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
