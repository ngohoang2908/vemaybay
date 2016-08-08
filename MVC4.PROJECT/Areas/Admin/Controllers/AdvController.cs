using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC4.PROJECT.Areas.Admin.Controllers;
using Model.EF;

namespace MVC4.PROJECT.Areas.Admin.Controllers
{
     [Authorize(Roles = "administrator, codeadmin")]
    public class AdvController : BaseController
    {
        //
        // GET: /Admin/Adv/
         MVCDbContext db = new MVCDbContext();
        public ActionResult Index()
        {
            var lang = Session["language"].ToString();
            IEnumerable<CW_Adv> adv;
            adv = db.CW_Adv.Where(x => x.LanguageCode.Equals(lang)).OrderByDescending(x => x.CreatedDate);

            return View(adv);
        }
        public ActionResult Add()
        {
            return View();
        }
         /// <summary>
         /// thêm quảng cáo
         /// </summary>
         /// <param name="model"></param>
         /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Exclude = "")]CW_Adv model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.LanguageCode = Session["language"].ToString();
                if (model.MetaTitle == null)
                {
                    model.MetaTitle = model.Title;
                }
                db.Set<CW_Adv>().Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            
            var cate = db.Set<CW_Adv>().Find(id);
            if (cate == null)
            {
                return HttpNotFound();
            }
            return View(cate);
        }
         /// <summary>
         /// sửa quảng cáo
         /// </summary>
         /// <param name="adv"></param>
         /// <returns></returns>
        [HttpPost]
        public ActionResult Edit([Bind(Include = "")]CW_Adv adv)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", adv);
            }
            else
            {
                if (adv.MetaTitle == null)
                    adv.MetaTitle = adv.Title;
                db.CW_Adv.Attach(adv);
                db.Entry(adv).Property(a => a.Title).IsModified = true;
                db.Entry(adv).Property(a => a.Image).IsModified = true;
                db.Entry(adv).Property(a => a.Link).IsModified = true;
                db.Entry(adv).Property(a => a.Description).IsModified = true;
                db.Entry(adv).Property(a => a.Height).IsModified = true;
                db.Entry(adv).Property(a => a.Width).IsModified = true;
                db.Entry(adv).Property(a => a.Order).IsModified = true;
                db.Entry(adv).Property(a => a.Position).IsModified = true;
                db.Entry(adv).Property(a => a.Target).IsModified = true;
                db.Entry(adv).Property(a => a.IsFlash).IsModified = true;
                db.Entry(adv).Property(a => a.IsActive).IsModified = true;
                db.Entry(adv).Property(a => a.CreatedDate).IsModified = false;
                db.Entry(adv).Property(a => a.MetaTitle).IsModified = true;
                db.Entry(adv).Property(a => a.MetaDescription).IsModified = true;
                db.Entry(adv).Property(a => a.LanguageCode).IsModified = false;

                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
         /// <summary>
         /// xóa quảng cáo
         /// </summary>
         /// <param name="id"></param>
         /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var article = db.Set<CW_Adv>().Find(id);
            if (article != null)
            {
                var catedelte = db.CW_Adv.Attach(article);
                db.Set<CW_Adv>().Remove(catedelte);
                db.SaveChanges();
            }

            return Json("Delete", JsonRequestBehavior.AllowGet);
        }
         /// <summary>
         /// tim kiem theo vi trí
         /// </summary>
         /// <param name="position"></param>
         /// <returns></returns>
        [HttpGet]
        public JsonResult Search(int position)
        {
            var lang = Session["language"].ToString();
            IEnumerable<CW_Adv> adv;
            adv = db.CW_Adv.Where(x => x.Position == position && x.LanguageCode.Equals(lang)).OrderByDescending(x => x.CreatedDate);
            var item = adv.Select(x => new
            {
                id = x.ID,
                name = x.Title,
                images = x.Image
            });
            return Json(item, JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
