using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.SessionState;
using Model.EF;

namespace COMMOM.Interface
{
    public class Helper
    {
        public static string RenderURL(string TypeCode, int Categoryid, string filterCategoryname, string link)
        {
            string strurl = "";
            if (TypeCode.Equals("bai-viet"))
            {
                strurl = "/bai-viet/" + filterCategoryname;
            }
            else if (TypeCode.Equals("tin-tuc"))
            {
                strurl = "/muc-" + filterCategoryname;
            }
            else if (TypeCode.Equals("san-pham"))
            {
                strurl = "/" + filterCategoryname + "-" + Categoryid.ToString();
            }
            else if (TypeCode.Equals("lien-ket"))
            {
                strurl = link;
            }
            else if (TypeCode.Equals("file"))
            {
                strurl = "/file/" + filterCategoryname + "-" + Categoryid.ToString();
            }
            else if (TypeCode.Equals("album"))
            {
                strurl = "/album/" + filterCategoryname + "-" + Categoryid.ToString();
            }
            else if (TypeCode.Equals("video"))
            {
                strurl = "/video/" + filterCategoryname + "-" + Categoryid.ToString();
            }
            return strurl;
        }

        public static string RenderBackgroundWebsite(string lang)
        {
            string bw = ISetting.GetSettingValue("SettingBackgroundWebsite" + lang);
            string bc = ISetting.GetSettingValue("SettingBackgroundColor" + lang);
            string bi = ISetting.GetSettingValue("SettingBackgroundImage" + lang);
            string br = ISetting.GetSettingValue("SettingBackgroundRepeat" + lang);
            if (bw.Equals("color"))
            {
                return "background: " + bc;
            }
            else if (bw.Equals("image"))
            {
                if (br.Equals("repeat"))
                {
                    return "background: url(" + bi + ") center top " + br;
                }
                else if (br.Equals("fix"))
                {
                    return "background: url(" + bi + ") center top; background-attachment: fixed;";
                }
            }
            return "";
        }

        public static string GetFullNameCustomer(int userid)
        {
            var db = new MVCDbContext();
            var cus = db.CW_Customers.Find(userid);
            if (cus != null)
            {
                return cus.UserProfile.FullName;
            }
            return "admin";
        }

        public static string Template(string path)
        {
            string strTemplate = "";
            string strFile = System.Web.HttpContext.Current.Server.MapPath(path);
            if (File.Exists(strFile))
            {
                TextReader txtreader = null;
                txtreader = new StreamReader(strFile);
                strTemplate = txtreader.ReadToEnd();
                txtreader.Close();
            }
            return strTemplate;
        }

        public static bool SendMail(string name, string subject, string content,
            string toMail)
        {
            bool rs = false;
            try
            {
                MailMessage message = new MailMessage();
                var smtp = new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com"; //host name
                    smtp.Port = 587; //port number
                    smtp.EnableSsl = true; //whether your smtp server requires SSL
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential("ngohoang29@gmail.com", "29089090");
                    smtp.Timeout = 20000;
                }
                MailAddress fromAddress = new MailAddress("ngohoang29@gmail.com", name);
                message.From = fromAddress;
                message.To.Add(toMail);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = content;
                smtp.Send(message);
                rs = true;
            }
            catch (Exception)
            {
                rs = false;
            }
            return rs;
        }
    }
}
