using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace MVC4.PROJECT.Areas.Admin.Controllers
{
    [Authorize(Roles = "administrator, codeadmin")]
    public class NewsCommentController : BaseController
    {
        //
        // GET: /Admin/NewsComment/
        MVCDbContext db = new MVCDbContext();
        public ActionResult Index(int? id)
        {
            IEnumerable<CW_NewsComment> obj = db.CW_NewsComment.Where(x => x.ID == id).OrderByDescending(x => x.CreatedDate);
            ViewBag.CountItem = obj.Count();
            CW_News objNews = db.CW_News.Where(x => x.ID == id).First();
            ViewBag.NewsTitle = objNews.Title;
            return View(obj);
        }

        [HttpPost]
        public ActionResult DeleteMutileItem(int item)
        {
            var newscomment = db.Set<CW_NewsComment>().Find(item);
            if (newscomment != null)
            {
                var catedelte = db.CW_NewsComment.Attach(newscomment);
                db.Set<CW_NewsComment>().Remove(catedelte);
                db.SaveChanges();
            }

            return Json("Delete", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateIsActive(int id, bool isactive)
        {
            CW_NewsComment newscomment = db.CW_NewsComment.Find(id);
            if (newscomment != null)
            {
                db.Set<CW_NewsComment>().Attach(newscomment);
                if (isactive)
                {
                    newscomment.IsActive = false;
                }
                else
                {
                    newscomment.IsActive = true;
                }

                db.SaveChanges();
            }
            return Json("chamara", JsonRequestBehavior.AllowGet);
        }


    }
}
