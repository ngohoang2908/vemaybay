using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.EF;

namespace COMMOM.Interface
{
    public class ISetting
    {
        public static string GetSettingValue(string key)
        {
            CW_Setting obj = new CW_Setting();
            using (var db = new MVCDbContext())
            {
                obj = db.CW_Setting.Where(x => x.SettingKey == key).FirstOrDefault();
                if (obj != null)
                    return obj.SettingValue;

            }
            return "nothing";
        }

        public static string GetSettingCheckValue(string key)
        {
            CW_Setting obj = new CW_Setting();
            using (var db = new MVCDbContext())
            {
                obj = db.CW_Setting.Where(x => x.SettingKey == key).FirstOrDefault();
                if (obj != null)
                    return obj.SettingValue;
                else
                    return null;

            }
            // return "";
        }

        public static bool CheckMenu(List<CW_Menu> obj, string menucode)
        {
            bool flag = false;
            if (obj.Count > 0)
            {
                foreach (CW_Menu item in obj)
                {
                    if (item.MenuCode.Equals(menucode))
                    {
                        flag = true;
                        break;
                    }

                }
            }
            return flag;
        }

        public static bool CheckKeyIsExist(string key)
        {
            bool check = false;
            using (var db = new MVCDbContext())
            {
                IEnumerable<CW_Setting> objbind = db.CW_Setting.OrderBy(x => x.CreatedDate);
                foreach (CW_Setting info in objbind)
                {
                    if (info.SettingKey.Equals(key))
                    {
                        check = true;
                        break;
                    }
                }
            }

            return check;
        }

        public static string SettingValue(string key, string group, string defaultvalue, string settingcomment)
        {
            CW_Setting model = new CW_Setting();
            model.SettingKey = key;
            model.SettingValue = defaultvalue;
            if (group.Equals(""))
            {
                model.SettingGroup = "Config";
            }
            else
            {
                model.SettingGroup = group;
            }

            model.SettingComment = settingcomment;
            model.CreatedDate = DateTime.Now;
            using (var db = new MVCDbContext())
            {
                if (!CheckKeyIsExist(key))
                {
                    db.Set<CW_Setting>().Add(model);
                    db.SaveChanges();
                }
                else
                    return "Trùng key mất rồi, nhập key khác đi";
            }
            return model.SettingValue;
        }

        public static string GetLanguage(string lang)
        {
            string rtL = "";
            using (var db = new MVCDbContext())
            {
                CW_Language strrtL = db.CW_Language.Where(x => x.LanguageCode.Equals(lang)).FirstOrDefault();
                if (strrtL != null)
                    rtL = strrtL.Title;

            }
            return rtL;
        }
    }
}
