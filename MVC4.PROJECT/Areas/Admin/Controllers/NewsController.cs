using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Model.EF;
using COMMOM.Interface;

namespace MVC4.PROJECT.Areas.Admin.Controllers
{
    [Authorize(Roles = "administrator, codeadmin")]
    public class NewsController : BaseController
    {
        MVCDbContext db=new MVCDbContext();
        public ActionResult Index()
        {
            var lang = Session["language"].ToString();
            IEnumerable<CW_News> news =
                db.CW_News.Where(x => x.LanguageCode.Equals(lang)).OrderByDescending(x => x.CreatedDate);
            List<CW_Category> objLst=new List<CW_Category>();
            ViewBag.Select = ICategory.ByTypeCode(null, objLst, "", "tin-tuc", lang);
            return View(news);
        }

        public ActionResult Add()
        {
            var lang = Session["language"].ToString();
            List<CW_Category> obj = new List<CW_Category>();
            ViewBag.Select = new SelectList(ICategory.ByTypeCode(null, obj, "", "tin-tuc", lang), "ID", "Title");
            return View();
        }
        /// <summary>
        /// Them moi tin tuc
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Exclude = "")] CW_News model)
        {
            if (model.MetaTitle == null)
                model.MetaTitle = model.Title;
            model.LanguageCode = Session["language"].ToString();
            model.FilterTitle =COMMOM.Filter.FilterChar(model.Title);
            model.CreatedDate = DateTime.Now;
            db.Set<CW_News>().Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var lang = Session["language"].ToString();
            List<CW_Category> obj = new List<CW_Category>();
            ViewBag.Select = new SelectList(ICategory.ByTypeCode(null, obj, "", "tin-tuc", lang), "ID", "Title");

            var cate = db.Set<CW_News>().Find(id);
            if (cate == null)
            {
                return HttpNotFound();
            }
            return View(cate);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "")]CW_News news)
        {
            if (news.MetaTitle == null)
                news.MetaTitle = news.Title;
            news.FilterTitle = COMMOM.Filter.FilterChar(news.Title);
            db.CW_News.Attach(news);
            news.CreatedDate = DateTime.Now;
            db.Entry(news).Property(a => a.Title).IsModified = true;
            db.Entry(news).Property(a => a.Image).IsModified = true;
            db.Entry(news).Property(a => a.Description).IsModified = true;
            db.Entry(news).Property(a => a.Content).IsModified = true;
            db.Entry(news).Property(a => a.ImageNotes).IsModified = true;
            db.Entry(news).Property(a => a.Read).IsModified = true;
            db.Entry(news).Property(a => a.MetaKeywords).IsModified = true;
            db.Entry(news).Property(a => a.IsActive).IsModified = true;
            db.Entry(news).Property(a => a.IsHome).IsModified = true;
            db.Entry(news).Property(a => a.CreatedDate).IsModified = false;
            db.Entry(news).Property(a => a.Order).IsModified = true;
            db.Entry(news).Property(a => a.LanguageCode).IsModified = true;
            db.Entry(news).Property(a => a.CategoryID).IsModified = true;
            db.Entry(news).Property(a => a.MetaTitle).IsModified = true;
            db.Entry(news).Property(a => a.MetaDescription).IsModified = true;
            db.Entry(news).Property(a => a.LanguageCode).IsModified = false;
            db.Entry(news).Property(a => a.FilterTitle).IsModified = true;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        /// <summary>
        /// Xóa ban ghi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var cate = db.Set<CW_News>().Find(id);
            if (cate != null)
            {
                var catedelete = db.CW_News.Attach(cate);
                db.Set<CW_News>().Remove(cate);
                db.SaveChanges();
            }
            return Json("Delete", JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// hiện thi trang home True and false
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isHome"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateIsHome(int id, bool isHome)
        {
            CW_News obj = db.CW_News.Find(id);
            if (obj != null)
            {
                db.Set<CW_News>().Attach(obj);
                if (isHome)
                {
                    obj.IsHome = false;
                }
                else
                {
                    obj.IsHome = true;
                }
                db.SaveChanges();
            }
            return Json("chamara", JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Hiện thị hoặc ẩn
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isActive"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateIsActive(int id, bool isActive)
        {
            CW_News obj = db.CW_News.Find(id);
            if (obj != null)
            {
                db.Set<CW_News>().Attach(obj);
                if (isActive)
                {
                    obj.IsActive = false;
                }
                else
                {
                    obj.IsActive = true;
                }
                db.SaveChanges();
            }
            return Json("chamara", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdateOrder(int id, int order)
        {
            CW_News art = db.CW_News.Find(id);
            if (art != null)
            {
                db.Set<CW_News>().Attach(art);
                art.Order = order;
                db.SaveChanges();
            }
            return Json("chamara", JsonRequestBehavior.AllowGet);
        }
    }
}
