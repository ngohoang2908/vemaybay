using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace MVC4.PROJECT.Areas.Admin.Controllers
{
    [Authorize(Roles = "administrator, codeadmin")]
    public class HomeController : BaseLangController
    {
        //
        // GET: /Admin/Home/
        MVCDbContext db= new MVCDbContext();
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        public ActionResult Index()
        {
            //Số tin tức
            IEnumerable<CW_News> news = db.CW_News;
            ViewBag.NewsCount = news.ToList().Count();

            //Số bài viết
            IEnumerable<CW_Article> art = db.CW_Article;
            ViewBag.ArtCount = art.ToList().Count();

            //Commennt
            var objnewscomment = db.CW_NewsComment.Where(x => x.CreatedDate.Year == DateTime.Today.Year
                && x.CreatedDate.Month == DateTime.Today.Month
                && x.CreatedDate.Day == DateTime.Today.Day);
            ViewBag.TodayCommentCount = objnewscomment.ToList().Count();

          
            //QUảng cao
            var objfqa = db.CW_Adv.ToList();
            ViewBag.AdvCount = objfqa.Count;
            //Menu
            var categories = db.CW_Category;
            ViewBag.CategoriesCount = categories.ToList().Count();
            //Ho tro truc tuyen
            var sup = db.CW_Support;
            ViewBag.SupCount = sup.ToList().Count();
            return View();
        }

        public PartialViewResult _Menutop()
        {
            return PartialView();
        }

        [HttpGet]
        public JsonResult LoadMenutop()
        {
            StringBuilder sb = new StringBuilder();
            var response = new { message = "", count = 0 };
           

            //đếm số liên hệ mới
            int countcontact = db.CW_Contact.Where(x => !x.IsRead).Count();
            if (countcontact > 0)
            {
                sb.Append("<li><a href='/admin/AdminContact' >");
                sb.Append("    <span class='label label-primary'>");
                sb.Append("        <i class='fa fa-comment'></i> ");
                sb.Append("    </span>");
                sb.Append(" "+@StaticResources.Resources.Youhave+" " + countcontact +" "+ @StaticResources.Resources.newcustomercontact);
                sb.Append("</a></li>");
            }
            else
            {
                sb.Append("<li><a href='/admin/AdminContact' >");
                sb.Append("    <span class='label label-primary'>");
                sb.Append("        <i class='fa fa-comment'></i> ");
                sb.Append("    </span>");
                sb.Append(" "+@StaticResources.Resources.Younotcontact);
                sb.Append("</a></li>");
            }

           

           
            int total = countcontact;
            response = new { message = sb.ToString(), count = total };

            return Json(response, JsonRequestBehavior.AllowGet);
        }

    }
}
