using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC4.PROJECT.Areas.Admin.Controllers
{
    public class BaseLangController : Controller
    {
        //
        // GET: /Admin/BaseLang/
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["language"] != null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["language"].ToString());
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["language"].ToString());
            }
            else
            {
                Session["language"] = "vi";
                Thread.CurrentThread.CurrentCulture = new CultureInfo("vi");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi");
            }
        }

        // changing culture
        public ActionResult ChangeCulture(string ddlCulture, string returnUrl)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(ddlCulture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(ddlCulture);

            Session["language"] = ddlCulture;
            return Redirect(returnUrl);
        }

        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    //var session = (UserLogin)Session[CommonConstants.USER_SESSION];
        //    if (Session["IsAuthenticated"] == null)
        //    {
        //        filterContext.Result = new RedirectToRouteResult(new
        //            RouteValueDictionary(new { controller = "User", action = "Login", Area = "Admin" }));
        //    }
        //    base.OnActionExecuting(filterContext);
        //}
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}
