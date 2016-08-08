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
    public class AdminContactController : BaseController
    {
        //
        // GET: /Admin/AdminContact/
        MVCDbContext db = new MVCDbContext();
        public ActionResult Index()
        {
            var contact = db.CW_Contact.OrderByDescending(x => x.ID);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }
        public ActionResult View(int id)
        {
            var contact = db.CW_Contact.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            //cập nhật đã đọc
            if (contact != null)
            {
                db.Set<CW_Contact>().Attach(contact);
                contact.IsRead = true;
                db.SaveChanges();
            }
            return View(contact);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var contact = db.Set<CW_Contact>().Find(id);
            if (contact != null)
            {
                var catedelte = db.CW_Contact.Attach(contact);
                db.Set<CW_Contact>().Remove(catedelte);
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
