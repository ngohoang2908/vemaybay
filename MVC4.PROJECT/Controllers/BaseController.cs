using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COMMOM.Interface;

namespace MVC4.PROJECT.Controllers
{
    public class BaseController : Controller
    {
        protected override void ExecuteCore()
        {
            string culture = "vi";
            if (this.Session == null || this.Session["culture"] == null)
            {
                //int.TryParse(System.Configuration.ConfigurationManager.AppSettings["Culture"], out culture);
                this.Session["culture"] = culture;
            }
            else
            {
                culture = this.Session["culture"].ToString();
            }
            //
            SessionManager.CurrentCulture = culture;

            base.ExecuteCore();
        }

        protected override bool DisableAsyncSupport
        {
            get { return true; }
        }
    }
}
