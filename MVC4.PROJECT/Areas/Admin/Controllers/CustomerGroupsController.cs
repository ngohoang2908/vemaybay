using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace MVC4.PROJECT.Areas.Admin.Controllers
{
    [Authorize(Roles = "administrator, codeadmin")]
    public class CustomerGroupsController : BaseController
    {
        //
        // GET: /Admin/CustomerGroups/
        MVCDbContext db = new MVCDbContext();
        public ActionResult Index()
        {
            var cusGroup = db.CW_CustomerGroups.OrderByDescending(x => x.CreatedDate);
            return View(cusGroup);
        }

        public ActionResult Add()
        {
            return View();
        }
        /// <summary>
        /// Thêm mới nhóm khách hàng
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Exclude = "")]CW_CustomerGroups model)
        {
            if (model.IsDefault)
            {
                CW_CustomerGroups obj = new CW_CustomerGroups();
                var lstCg = db.CW_CustomerGroups;
                if (lstCg != null)
                {
                    foreach (var item in lstCg)
                    {
                        obj = db.CW_CustomerGroups.Find(item.CustomerGroupsID);
                        db.Set<CW_CustomerGroups>().Attach(obj);
                        obj.IsDefault = false;
                    }
                }
            }
            model.CreatedDate = DateTime.Now;
            db.Set<CW_CustomerGroups>().Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            CW_CustomerGroups cusg = db.CW_CustomerGroups.Find(id);
            return View(cusg);
        }
        /// <summary>
        /// Sua nhom khach hang
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit([Bind(Include = "")]CW_CustomerGroups model)
        {
            if (model.IsDefault)
            {
                CW_CustomerGroups obj = new CW_CustomerGroups();
                var lstCusg = db.CW_CustomerGroups.Where(x => x.CustomerGroupsID != model.CustomerGroupsID);
                if (lstCusg!=null)
                {
                    foreach (var item in lstCusg)
                    {
                        obj = db.CW_CustomerGroups.Find(item.CustomerGroupsID);
                        db.Set<CW_CustomerGroups>().Attach(obj);
                        obj.IsDefault = false;
                    }
                }
            }
            db.CW_CustomerGroups.Attach(model);
            db.Entry(model).Property(x => x.CustomerGroupName).IsModified = true;
            db.Entry(model).Property(x => x.IsDefault).IsModified = true;
            db.Entry(model).Property(x => x.CreatedDate).IsModified = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Thay đổi IsDefault
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isDefault"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateIsDefault(int id,bool isDefault)
        {
            CW_CustomerGroups obj = db.CW_CustomerGroups.Find(id);
            if (obj != null)
            {
                db.Set<CW_CustomerGroups>().Attach(obj);
                if (isDefault)
                {
                    obj.IsDefault = false;
                }
                else
                {
                    obj.IsDefault = true;
                    var lstCusg = db.CW_CustomerGroups.Where(x => x.CustomerGroupsID != id);
                    if (lstCusg!=null)
                    {
                        foreach (var item in lstCusg)
                        {
                            obj = db.CW_CustomerGroups.Find(item.CustomerGroupsID);
                            db.Set<CW_CustomerGroups>().Attach(obj);
                            obj.IsDefault = false;
                        }
                    }
                }
                db.SaveChanges();

            }
            return Json("chamara", JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Xóa bản ghi nhóm
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var cg = db.Set<CW_CustomerGroups>().Find(id);
            if (cg != null)
            {
                var catedelte = db.CW_CustomerGroups.Attach(cg);
                db.Set<CW_CustomerGroups>().Remove(catedelte);
                db.SaveChanges();
            }

            return Json("Delete", JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
