using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace MVC4.PROJECT.Areas.Admin.Controllers
{
    [Authorize(Roles = "administrator, codeadmin")]
    public class SettingController : BaseLangController
    {
        //
        // GET: /Admin/Setting/
        MVCDbContext db = new MVCDbContext();
       
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// lưu cài đặt
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public PartialViewResult _SaveSetting()
        {
            string lang = Session["language"].ToString();
            IEnumerable<CW_Category> cate = db.CW_Category.Where(x => x.ParentID == null && x.LanguageCode.Equals(lang));
            ViewBag.ListCate = cate;
            return PartialView();
        }

        [HttpPost]
        [ValidateInput(false)]
        public PartialViewResult _SaveSetting(string SettingTitle, string SettingBanner,string SettingLogo, string SettingBannerWidth, string SettingBannerHeight,
            string SettingEmail, string SettingFooter, string SettingMetakeyword, string SettingMetadescription, string SettingContact, string SettingHotline,string SettingFanpage,
            string SettingPayment, string SettingFavicon, string SettingMaps, string SettingGoogleAnalytics, string SettingPageProduct, string SettingPageNews, string SettingGoogleWebmaster,
            string SettingOffWebsite, string SettingNoticle, string SettingDefaultPage, string SettingBackgroundWebsite, string SettingBackgroundColor, string SettingBackgroundImage,
            string SettingBackgroundRepeat, string SettingPopupOff, string SettingPopupContent, string SettingAdvLeftRight, string SettingAdvLeft, string SettingAdvRight, string SettingCommentNewsOff)
        {
            string lang = Session["language"].ToString();
            CW_Setting modelSetting;

            modelSetting = new CW_Setting();

            #region "Bình luận tin tức"

            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingCommentNewsOff" + lang) == null)
            {
                modelSetting.SettingComment = "Bật tắt chức năng bình luận tin tức";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingCommentNewsOff" + lang;
                modelSetting.SettingValue = SettingCommentNewsOff;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);
            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingCommentNewsOff" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingCommentNewsOff;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            #endregion

            #region "Quảng cáo hai bên"

            modelSetting = new CW_Setting();
            //Quảng cáo bên phải
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingAdvRight" + lang) == null)
            {
                modelSetting.SettingComment = "Quảng cáo bên phải";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingAdvRight" + lang;
                modelSetting.SettingValue = SettingAdvRight;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);

            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingAdvRight" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingAdvRight;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            modelSetting = new CW_Setting();
            //Quảng cáo bên trái
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingAdvLeft" + lang) == null)
            {
                modelSetting.SettingComment = "Quảng cáo bên trái";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingAdvLeft" + lang;
                modelSetting.SettingValue = SettingAdvLeft;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);

            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingAdvLeft" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingAdvLeft;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            modelSetting = new CW_Setting();
            //bặt tắt chức năng quảng cáo hai bên
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingAdvLeftRight" + lang) == null)
            {
                modelSetting.SettingComment = "Bật tắt chức năng";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingAdvLeftRight" + lang;
                modelSetting.SettingValue = SettingAdvLeftRight;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);

            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingAdvLeftRight" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingAdvLeftRight;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            #endregion

            #region "popup website"

            modelSetting = new CW_Setting();
            //nội dung popup
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingPopupContent" + lang) == null)
            {
                modelSetting.SettingComment = "nội dung popup";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingPopupContent" + lang;
                modelSetting.SettingValue = SettingPopupContent;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);

            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingPopupContent" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingPopupContent;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            modelSetting = new CW_Setting();
            //bật tắt
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingPopupOff" + lang) == null)
            {
                modelSetting.SettingComment = "Bật tắt popup";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingPopupOff" + lang;
                modelSetting.SettingValue = SettingPopupOff;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);

            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingPopupOff" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingPopupOff;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            #endregion

            #region "setting background website"

            modelSetting = new CW_Setting();
            //background repeat
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingBackgroundRepeat" + lang) == null)
            {
                modelSetting.SettingComment = "Backgorund repeat";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingBackgroundRepeat" + lang;
                modelSetting.SettingValue = SettingBackgroundRepeat;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);

            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingBackgroundRepeat" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingBackgroundRepeat;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            modelSetting = new CW_Setting();
            //background images
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingBackgroundImage" + lang) == null)
            {
                modelSetting.SettingComment = "Backgorund image";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingBackgroundImage" + lang;
                modelSetting.SettingValue = SettingBackgroundImage;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);

            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingBackgroundImage" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingBackgroundImage;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            modelSetting = new CW_Setting();
            //background color
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingBackgroundColor" + lang) == null)
            {
                modelSetting.SettingComment = "Backgorund color";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingBackgroundColor" + lang;
                modelSetting.SettingValue = SettingBackgroundColor;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);

            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingBackgroundColor" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingBackgroundColor;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            modelSetting = new CW_Setting();
            //background website
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingBackgroundWebsite" + lang) == null)
            {
                modelSetting.SettingComment = "Backgorund website";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingBackgroundWebsite" + lang;
                modelSetting.SettingValue = SettingBackgroundWebsite;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);

            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingBackgroundWebsite" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingBackgroundWebsite;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            #endregion

            #region "add setting"

            modelSetting = new CW_Setting();
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingTitle" + lang) == null)
            {
                modelSetting.SettingComment = "Tiêu đề trang";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingTitle" + lang;
                modelSetting.SettingValue = SettingTitle;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);

            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingTitle" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingTitle;
                db.Entry(modelSetting).State = EntityState.Modified;
            }
            //Logo
            modelSetting = new CW_Setting();
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingLogo" + lang) == null)
            {
                modelSetting.SettingComment = "Logo";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingLogo" + lang;
                modelSetting.SettingValue = SettingLogo;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);

            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingLogo" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingLogo;
                db.Entry(modelSetting).State = EntityState.Modified;
            }
            //
            modelSetting = new CW_Setting();
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingBanner" + lang) == null)
            {
                modelSetting.SettingComment = "Banner";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingBanner" + lang;
                modelSetting.SettingValue = SettingBanner;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);
            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingBanner" + lang).SingleOrDefault();

                modelSetting.SettingValue = SettingBanner;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            modelSetting = new CW_Setting();
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingBannerWidth" + lang) == null)
            {
                modelSetting.SettingComment = "Chiều rộng banner";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingBannerWidth" + lang;
                modelSetting.SettingValue = SettingBannerWidth;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);
            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingBannerWidth" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingBannerWidth;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            modelSetting = new CW_Setting();
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingEmail" + lang) == null)
            {
                modelSetting.SettingComment = "Email";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingEmail" + lang;
                modelSetting.SettingValue = SettingEmail;
                modelSetting.LanguageCode = lang;
                modelSetting.CreatedDate = DateTime.Now;
                db.Set<CW_Setting>().Add(modelSetting);

            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingEmail" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingEmail;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            modelSetting = new CW_Setting();
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingBannerHeight" + lang) == null)
            {
                modelSetting.SettingComment = "Chiều cao banner";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingBannerHeight" + lang;
                modelSetting.SettingValue = SettingBannerHeight;
                modelSetting.LanguageCode = lang;
                modelSetting.CreatedDate = DateTime.Now;
                db.Set<CW_Setting>().Add(modelSetting);

            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingBannerHeight" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingBannerHeight;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            modelSetting = new CW_Setting();
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingFooter" + lang) == null)
            {
                modelSetting.SettingComment = "Thông tin chân trang";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingFooter" + lang;
                modelSetting.SettingValue = SettingFooter;
                modelSetting.LanguageCode = lang;
                modelSetting.CreatedDate = DateTime.Now;
                db.Set<CW_Setting>().Add(modelSetting);
            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingFooter" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingFooter;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            modelSetting = new CW_Setting();
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingMetakeyword" + lang) == null)
            {
                modelSetting.SettingComment = "Metakeyword";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingMetakeyword" + lang;
                modelSetting.SettingValue = SettingMetakeyword;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);
            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingMetakeyword" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingMetakeyword;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            modelSetting = new CW_Setting();
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingMetadescription" + lang) == null)
            {
                modelSetting.SettingComment = "Metadescription";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingMetadescription" + lang;
                modelSetting.SettingValue = SettingMetadescription;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);
            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingMetadescription" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingMetadescription;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            modelSetting = new CW_Setting();
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingContact" + lang) == null)
            {
                modelSetting.SettingComment = "Thông tin liên hệ";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingContact" + lang;
                modelSetting.SettingValue = SettingContact;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);
            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingContact" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingContact;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            modelSetting = new CW_Setting();
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingHotline" + lang) == null)
            {
                modelSetting.SettingComment = "Hotline";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingHotline" + lang;
                modelSetting.SettingValue = SettingHotline;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);
            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingHotline" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingHotline;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            //Fanpage
            modelSetting = new CW_Setting();
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingFanpage" + lang) == null)
            {
                modelSetting.SettingComment = "Fanpage";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingFanpage" + lang;
                modelSetting.SettingValue = SettingFanpage;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);
            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingFanpage" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingFanpage;
                db.Entry(modelSetting).State = EntityState.Modified;
            }
            modelSetting = new CW_Setting();
            //thanh toán
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingPayment" + lang) == null)
            {
                modelSetting.SettingComment = "Hướng dẫn thanh toán";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingPayment" + lang;
                modelSetting.SettingValue = SettingPayment;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);
            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingPayment" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingPayment;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            modelSetting = new CW_Setting();
            //Favicon
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingFavicon" + lang) == null)
            {
                modelSetting.SettingComment = "Favicon";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingFavicon" + lang;
                modelSetting.SettingValue = SettingFavicon;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);
            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingFavicon" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingFavicon;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            modelSetting = new CW_Setting();
            //bản đồ
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingMaps" + lang) == null)
            {
                modelSetting.SettingComment = "Bản đồ";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingMaps" + lang;
                modelSetting.SettingValue = SettingMaps;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);
            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingMaps" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingMaps;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            modelSetting = new CW_Setting();
            //Mã nhúng google analytics
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingGoogleAnalytics" + lang) == null)
            {
                modelSetting.SettingComment = "Bản đồ";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingGoogleAnalytics" + lang;
                modelSetting.SettingValue = SettingGoogleAnalytics;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);
            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingGoogleAnalytics" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingGoogleAnalytics;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            modelSetting = new CW_Setting();
            //phân trang sản phẩm
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingPageProduct" + lang) == null)
            {
                modelSetting.SettingComment = "Phân trang sản phẩm";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingPageProduct" + lang;
                modelSetting.SettingValue = SettingPageProduct;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);
            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingPageProduct" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingPageProduct;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            modelSetting = new CW_Setting();
            //phân trang tin tức
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingPageNews" + lang) == null)
            {
                modelSetting.SettingComment = "Phân trang tin tức";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingPageNews" + lang;
                modelSetting.SettingValue = SettingPageNews;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);
            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingPageNews" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingPageNews;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            modelSetting = new CW_Setting();
            //google webmaster
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingGoogleWebmaster" + lang) == null)
            {
                modelSetting.SettingComment = "Google webmaster";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingGoogleWebmaster" + lang;
                modelSetting.SettingValue = SettingGoogleWebmaster;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);
            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingGoogleWebmaster" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingGoogleWebmaster;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            modelSetting = new CW_Setting();
            //off website
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingOffWebsite" + lang) == null)
            {
                modelSetting.SettingComment = "Bật tắt website";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingOffWebsite" + lang;
                modelSetting.SettingValue = SettingOffWebsite;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);
            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingOffWebsite" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingOffWebsite;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            modelSetting = new CW_Setting();
            //thông báo khi tắt website
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingNoticle" + lang) == null)
            {
                modelSetting.SettingComment = "Thông báo khi tắt website";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingNoticle" + lang;
                modelSetting.SettingValue = SettingNoticle;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);
            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingNoticle" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingNoticle;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            modelSetting = new CW_Setting();
            //Cấu hình trang mặc định
            if (COMMOM.Interface.ISetting.GetSettingCheckValue("SettingDefaultPage" + lang) == null)
            {
                modelSetting.SettingComment = "Cấu hình trang mặc định";
                modelSetting.SettingGroup = "Config";
                modelSetting.SettingKey = "SettingDefaultPage" + lang;
                modelSetting.SettingValue = SettingDefaultPage;
                modelSetting.CreatedDate = DateTime.Now;
                modelSetting.LanguageCode = lang;
                db.Set<CW_Setting>().Add(modelSetting);
            }
            else
            {
                modelSetting = db.CW_Setting.Where(x => x.SettingKey == "SettingDefaultPage" + lang).SingleOrDefault();
                modelSetting.SettingValue = SettingDefaultPage;
                db.Entry(modelSetting).State = EntityState.Modified;
            }

            #endregion

            db.SaveChanges();
            var cate = db.CW_Category.Where(x => x.ParentID == null);
            ViewBag.ListCate = cate;
            return PartialView("_SaveSetting");

        }
    }
}
