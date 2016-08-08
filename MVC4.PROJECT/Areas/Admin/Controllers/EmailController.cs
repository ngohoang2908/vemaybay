using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace MVC4.PROJECT.Areas.Admin.Controllers
{
    [Authorize(Roles = "administrator, codeadmin")]
    public class EmailController : BaseController
    {
        //
        // GET: /Admin/Email/
        MVCDbContext db=new MVCDbContext();
        public ActionResult Index()
        {
            var email = db.CW_Email.OrderByDescending(x => x.CreatedDate);
            return View(email);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var email = db.Set<CW_Email>().Find(id);
            if (email != null)
            {
                var catedelte = db.CW_Email.Attach(email);
                db.Set<CW_Email>().Remove(catedelte);
                db.SaveChanges();
            }

            return Json("Delete", JsonRequestBehavior.AllowGet);
        }

    }
}
