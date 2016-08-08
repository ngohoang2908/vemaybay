using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace MVC4.PROJECT.Controllers
{
    public class HomeController : BaseController
    {
        MVCDbContext db = new MVCDbContext();
        public ActionResult Index()
        {
            var lang = Session["culture"].ToString();
            int cateid = int.Parse(COMMOM.Interface.ISetting.GetSettingValue("SettingDefaultPage" + lang));
            var cateobj = db.CW_Category.Find(cateid);
            if (!cateobj.CategoryCode.Equals("trang-chu") && !cateobj.CategoryCode.Equals("home"))
            {
                return Redirect(COMMOM.Interface.Helper.RenderURL(cateobj.TypeCode, cateobj.ID, cateobj.CategoryCode, cateobj.Link));
            }
            ViewBag.CateID = 1;
          
            return View();
        }
       
    }
}
