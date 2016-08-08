using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace MVC4.PROJECT.Areas.Admin.Controllers
{
     [Authorize(Roles = "administrator, codeadmin")]
    public class SupportController : BaseController
    {
        //
        // GET: /Admin/Support/
         MVCDbContext db= new MVCDbContext();
         public ActionResult Index()
         {
             IEnumerable<CW_Support> supp;
             supp = db.CW_Support.OrderByDescending(x => x.CreatedDate);
             return View(supp);
         }

         public ActionResult Add()
         {
             return View();
         }
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Add([Bind(Exclude = "")]CW_Support model)
         {
             if (ModelState.IsValid)
             {
                 model.LanguageCode = Session["language"].ToString();
                 model.CreatedDate = DateTime.Now;
                 db.Set<CW_Support>().Add(model);
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
             //var db = new PortalContext();
             var cate = db.Set<CW_Support>().Find(id);
             if (cate == null)
             {
                 return HttpNotFound();
             }
             return View(cate);
         }

         [HttpPost]
         public ActionResult Edit([Bind(Include = "")]CW_Support support)
         {
             if (!ModelState.IsValid)
             {
                 return View("Edit", support);
             }
             else
             {

                 db.CW_Support.Attach(support);
                 db.Entry(support).Property(a => a.NickYahoo).IsModified = true;
                 db.Entry(support).Property(a => a.NickSkyper).IsModified = true;
                 db.Entry(support).Property(a => a.Title).IsModified = true;
                 db.Entry(support).Property(a => a.Phone).IsModified = true;
                 db.Entry(support).Property(a => a.Description).IsModified = true;
                 db.Entry(support).Property(a => a.Order).IsModified = true;
                 db.Entry(support).Property(a => a.LanguageCode).IsModified = false;
                 db.Entry(support).Property(a => a.IsActive).IsModified = true;
                 db.Entry(support).Property(a => a.CreatedDate).IsModified = false;

                 db.SaveChanges();

             }
             return RedirectToAction("Index");
         }

         [HttpPost]
         public ActionResult Delete(int id)
         {
             var supp = db.Set<CW_Support>().Find(id);
             if (supp != null)
             {
                 var catedelte = db.CW_Support.Attach(supp);
                 db.Set<CW_Support>().Remove(catedelte);
                 db.SaveChanges();
             }

             return Json("Delete", JsonRequestBehavior.AllowGet);
         }

         [HttpPost]
         public ActionResult UpdateIsActive(int id, bool isactive)
         {
             CW_Support supp = db.CW_Support.Find(id);
             if (supp != null)
             {
                 db.Set<CW_Support>().Attach(supp);
                 if (isactive)
                 {
                     supp.IsActive = false;
                 }
                 else
                 {
                     supp.IsActive = true;
                 }

                 db.SaveChanges();
             }
             return Json("chamara", JsonRequestBehavior.AllowGet);
         }

         [HttpPost]
         public ActionResult UpdateTitle(int id, string title)
         {
             CW_Support support = db.CW_Support.Find(id);
             if (support != null)
             {
                 db.Set<CW_Support>().Attach(support);
                 support.Title = title;
                 db.SaveChanges();
             }
             return Json("chamara", JsonRequestBehavior.AllowGet);
         }

         [HttpPost]
         public ActionResult UpdateNikskyper(int id, string skyper)
         {
             CW_Support support = db.CW_Support.Find(id);
             if (support != null)
             {
                 db.Set<CW_Support>().Attach(support);
                 support.NickSkyper = skyper;
                 db.SaveChanges();
             }
             return Json("chamara", JsonRequestBehavior.AllowGet);
         }

         [HttpPost]
         public ActionResult UpdateNikyahoo(int id, string yahoo)
         {
             CW_Support support = db.CW_Support.Find(id);
             if (support != null)
             {
                 db.Set<CW_Support>().Attach(support);
                 support.NickYahoo = yahoo;
                 db.SaveChanges();
             }
             return Json("chamara", JsonRequestBehavior.AllowGet);
         }

         [HttpPost]
         public ActionResult UpdatePhone(int id, string phone)
         {
             CW_Support support = db.CW_Support.Find(id);
             if (support != null)
             {
                 db.Set<CW_Support>().Attach(support);
                 support.Phone = phone;
                 db.SaveChanges();
             }
             return Json("chamara", JsonRequestBehavior.AllowGet);
         }

         [HttpPost]
         public ActionResult UpdateOrder(int id, int order)
         {
             CW_Support supp = db.CW_Support.Find(id);
             if (supp != null)
             {
                 db.Set<CW_Support>().Attach(supp);
                 supp.Order = order;
                 db.SaveChanges();
             }
             return Json("chamara", JsonRequestBehavior.AllowGet);
         }

    }
}
