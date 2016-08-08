using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web.SessionState;

namespace COMMOM.Interface
{
    public class SessionManager
    {
        protected HttpSessionState session;
        public SessionManager(HttpSessionState httpSessionState)
        {
            session = httpSessionState;
        }
        public static string CurrentCulture
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "vi-VN")
                    return "vi";
                else if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                    return "en";
                else
                    return "vi";
            }
            set
            {
                if (value == "vi")
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
                else if (value == "en")
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                else
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
            }
        }
    }
}
