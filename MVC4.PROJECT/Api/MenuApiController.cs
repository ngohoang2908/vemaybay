using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model.EF;
using Newtonsoft.Json.Linq;

namespace MVC4.PROJECT.Api
{
    public class MenuApiController : ApiController
    {
        MVCDbContext db =new MVCDbContext();
        #region "dùng cho việc thêm danh mục vào menu"

        [HttpGet]
        public JArray JTreeTableAddCate(int? select, string menucode, string lang)
        {
            //var db = new MVCDbContext();
            var allitems = from x in db.CW_Category orderby x.Order where x.LanguageCode.Equals(lang) select x;
            var roots = from x in allitems where x.ParentID == null select x;
            var menu_cate = from x in db.CW_Menu_Category where x.MenuCode == menucode select x;
            var jarray = new JArray();

            if (menu_cate != null)
            {

                foreach (var i in roots)
                {
                    var selectedcate = false;
                    foreach (var selected in menu_cate)
                    {
                        if (selected.CategoryID == i.ID)
                        {
                            selectedcate = true;
                        }
                    }
                    if (select.HasValue && i.ID == select) continue;
                    var subs = from x in allitems where x.ParentID == i.ID select x;
                    var haschild = false;
                    if (subs.Count() > 0) haschild = true;

                    jarray.Add(new JObject(new JProperty("ID", i.ID), new JProperty("Level", 0),
                        new JProperty("Title", i.Title), new JProperty("Parent", null), new JProperty("HasChild", haschild), new JProperty("selectedcate", selectedcate)));
                    if (subs.Count() > 0) SubTreeTableselectedcate(ref jarray, subs, allitems, 1, select, menu_cate);
                }
            }
            else
            {
                foreach (var i in roots)
                {
                    if (select.HasValue && i.ID == select) continue;
                    var subs = from x in allitems where x.ParentID == i.ID select x;
                    var haschild = false;
                    if (subs.Count() > 0) haschild = true;

                    jarray.Add(new JObject(new JProperty("ID", i.ID), new JProperty("Level", 0),
                        new JProperty("Title", i.Title), new JProperty("Parent", null), new JProperty("HasChild", haschild), new JProperty("selectedcate", false)));
                    if (subs.Count() > 0) SubTreeTableselectedcate(ref jarray, subs, allitems, 1, select, menu_cate);
                }
            }

            return jarray;
        }

        [NonAction]
        private JArray SubTreeTableselectedcate(ref JArray jarray, IEnumerable<CW_Category> subs, IEnumerable<CW_Category> allitems, int level, int? select, IEnumerable<CW_Menu_Category> menu_cate)
        {
            if (menu_cate != null)
            {

                foreach (var i in subs)
                {
                    var selectedcate = false;
                    foreach (var selected in menu_cate)
                    {
                        if (selected.CategoryID == i.ID)
                        {
                            selectedcate = true;
                        }
                    }
                    if (select.HasValue && i.ID == select) continue;
                    var subsubs = from x in allitems where x.ParentID == i.ID orderby x.Order select x;
                    var haschild = false;
                    if (subsubs.ToList().Count() > 0) haschild = true;
                    jarray.Add(new JObject(new JProperty("ID", i.ID), new JProperty("Level", 0),
                        new JProperty("Title", i.Title), new JProperty("Parent", i.ParentID), new JProperty("HasChild", haschild), new JProperty("selectedcate", selectedcate)));
                    if (subsubs.Count() > 0) SubTreeTableselectedcate(ref jarray, subsubs, allitems, level + 1, select, menu_cate);
                }
            }
            else
            {
                foreach (var i in subs)
                {
                    if (select.HasValue && i.ID == select) continue;
                    var subsubs = from x in allitems where x.ParentID == i.ID orderby x.Order select x;
                    var haschild = false;
                    if (subsubs.ToList().Count() > 0) haschild = true;
                    jarray.Add(new JObject(new JProperty("ID", i.ID), new JProperty("Level", 0),
                        new JProperty("Title", i.Title), new JProperty("Parent", i.ParentID), new JProperty("HasChild", haschild), new JProperty("selectedcate", false)));
                    if (subsubs.Count() > 0) SubTreeTableselectedcate(ref jarray, subsubs, allitems, level + 1, select, menu_cate);
                }
            }
            return jarray;
        }

        #endregion

    }
}
