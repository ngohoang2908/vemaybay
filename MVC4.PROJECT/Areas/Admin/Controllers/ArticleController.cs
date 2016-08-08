using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COMMOM.Interface;
using Model.EF;

namespace MVC4.PROJECT.Areas.Admin.Controllers
{
     [Authorize(Roles = "administrator, codeadmin")]
    public class ArticleController : BaseController
    {
        //
        // GET: /Admin/Article/
         MVCDbContext db = new MVCDbContext();
        public ActionResult Index()
        {
            var lang = Session["language"].ToString();
            IEnumerable<CW_Article> article;
            article = db.CW_Article.Where(x => x.LanguageCode.Equals(lang)).OrderByDescending(x => x.CreatedDate);
            List<CW_Category> obj = new List<CW_Category>();
            ViewBag.Select = ICategory.ByTypeCode(null, obj, "", "bai-viet", lang);
            return View(article);
        }


        public ActionResult Add()
        {
            var lang = Session["language"].ToString();
            List<CW_Category> obj = new List<CW_Category>();
            ViewBag.Select = new SelectList(ICategory.ByTypeCode(null, obj, "", "bai-viet", lang), "ID", "Title");
            return View();
        }
         /// <summary>
         /// thêm bài viết
         /// </summary>
         /// <param name="model"></param>
         /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Exclude = "")]CW_Article model)
        {
            if (model.MetaTitle == null)
                model.MetaTitle = model.Title;
            model.LanguageCode = Session["language"].ToString();
            model.FilterTitle = COMMOM.Filter.FilterChar(model.Title);
            model.CreatedDate = DateTime.Now;
            db.Set<CW_Article>().Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var lang = Session["language"].ToString();
            List<CW_Category> obj = new List<CW_Category>();
            ViewBag.Select = new SelectList(ICategory.ByTypeCode(null, obj, "", "bai-viet", lang), "ID", "Title");
            //var db = new PortalContext();
            var cate = db.Set<CW_Article>().Find(id);
            if (cate == null)
            {
                return HttpNotFound();
            }
            return View(cate);
        }
         /// <summary>
         /// Sửa bài viết
         /// </summary>
         /// <param name="article"></param>
         /// <returns></returns>
        [HttpPost]
        public ActionResult Edit([Bind(Include = "")]CW_Article article)
        {
            if (article.MetaTitle == null)
                article.MetaTitle = article.Title;
            article.FilterTitle = COMMOM.Filter.FilterChar(article.Title);
            db.CW_Article.Attach(article);
            db.Entry(article).Property(a => a.Title).IsModified = true;
            db.Entry(article).Property(a => a.Description).IsModified = true;
            db.Entry(article).Property(a => a.Body).IsModified = true;
            db.Entry(article).Property(a => a.CategoryID).IsModified = true;
            db.Entry(article).Property(a => a.Order).IsModified = true;
            db.Entry(article).Property(a => a.FilterTitle).IsModified = true;
            db.Entry(article).Property(a => a.MetaKeywords).IsModified = true;

            db.Entry(article).Property(a => a.IsActive).IsModified = true;
            db.Entry(article).Property(a => a.CreatedDate).IsModified = false;
            db.Entry(article).Property(a => a.Description).IsModified = true;
            db.Entry(article).Property(a => a.MetaTitle).IsModified = true;
            db.Entry(article).Property(a => a.MetaDescription).IsModified = true;
            db.Entry(article).Property(a => a.LanguageCode).IsModified = false;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var article = db.Set<CW_Article>().Find(id);
            if (article != null)
            {
                var catedelte = db.CW_Article.Attach(article);
                db.Set<CW_Article>().Remove(catedelte);
                db.SaveChanges();
            }

            return Json("Delete", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateIsActive(int id, bool isactive)
        {
            CW_Article art = db.CW_Article.Find(id);
            if (art != null)
            {
                db.Set<CW_Article>().Attach(art);
                if (isactive)
                {
                    art.IsActive = false;
                }
                else
                {
                    art.IsActive = true;
                }

                db.SaveChanges();
            }
            return Json("chamara", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateOrder(int id, int order)
        {
            CW_Article art = db.CW_Article.Find(id);
            if (art != null)
            {
                db.Set<CW_Article>().Attach(art);
                art.Order = order;
                db.SaveChanges();
            }
            return Json("chamara", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateTitle(int id, string title)
        {
            CW_Article article = db.CW_Article.Find(id);
            if (article != null)
            {
                db.Set<CW_Article>().Attach(article);
                article.Title = title;
                article.FilterTitle = COMMOM.Filter.FilterChar(title);
                db.SaveChanges();
            }
            return Json("chamara", JsonRequestBehavior.AllowGet);
        }
    }
}
