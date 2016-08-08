using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace COMMOM
{
    class Utility
    {
        public static string RemoveHtmlTag(string htmlContent)
        {
            return Regex.Replace(htmlContent, "<[^>]*>", string.Empty).Replace("&nbsp;", "").Trim();
        }
    }
}
