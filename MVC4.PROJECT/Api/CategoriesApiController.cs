using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model.EF;


namespace MVC4.PROJECT
{
    public class CategoriesApiController : ApiController
    {
        MVCDbContext db = new MVCDbContext();
        #region "tìm kiếm danh mục"

        [NonAction]
        public List<CW_Category> catechil(int? parent, List<CW_Category> objcate)
        {
            List<CW_Category> objbind = new List<CW_Category>();
            foreach (CW_Category info in objcate)
            {
                if (info.ParentID == parent)
                {
                    objbind.Add(info);
                }
            }
            return objbind;
        }

        [NonAction]
        public List<CW_Category> GetAllCategory(int? parent, List<CW_Category> objcate, string lang, List<CW_Category> objaddcate)
        {
            List<CW_Category> objbind = catechil(parent, objcate);
            if (objbind != null && objbind.Count > 0)
            {
                CW_Category objtab = null;
                for (int i = 0; i < objbind.Count; i++)
                {
                    objtab = (CW_Category)objbind[i];
                    objaddcate.Add(objtab);
                    GetAllCategory(objtab.ID, objcate, lang, objaddcate);
                }
            }
            return objaddcate;
        }

        [HttpGet]
        public JArray JTreeTableSearch(int? select, string title, int parent, string typecode, string lang)
        {
            int? tempParentid = null;

            IEnumerable<CW_Category> allitems = from x in db.CW_Category orderby x.Order where x.LanguageCode.Equals(lang) select x;
            if (title != null)
            {
                allitems = allitems.Where(x => x.KeySearch.ToLower().Contains(title.ToLower()));
            }
            if (typecode != "--")
            {
                allitems = allitems.Where(x => x.TypeCode.Equals(typecode));
            }
            if (parent != 0)
            {
                List<CW_Category> objtemp = new List<CW_Category>();
                allitems = GetAllCategory(parent, allitems.ToList(), lang, objtemp);
                tempParentid = parent;
            }

            var jarray = new JArray();
            foreach (var i in allitems.Where(x => x.ParentID == tempParentid))
            {
                if (select.HasValue && i.ID == select) continue;
                var subs = from x in allitems where x.ParentID == i.ID select x;
                var haschild = false;
                if (subs.Count() > 0) haschild = true;
                jarray.Add(new JObject(new JProperty("ID", i.ID), new JProperty("Level", 0), new JProperty("CreatedDate", i.CreatedDate.ToShortDateString()),
                    new JProperty("Title", i.Title), new JProperty("MetaTitle", i.MetaTitle), new JProperty("MetaDescription", i.MetaDescription), new JProperty("Parent", null), new JProperty("IsActive", i.IsActive), new JProperty("HasChild", haschild)));
                if (subs.Count() > 0) SubTreeTableSearch(ref jarray, subs, allitems, 1, select);
            }
            return jarray;
        }

        [NonAction]
        private JArray SubTreeTableSearch(ref JArray jarray, IEnumerable<CW_Category> subs, IEnumerable<CW_Category> allitems, int level, int? select)
        {
            foreach (var i in subs)
            {
                if (select.HasValue && i.ID == select) continue;
                var subsubs = from x in allitems where x.ParentID == i.ID orderby x.Order select x;
                var haschild = false;
                if (subsubs.ToList().Count() > 0) haschild = true;
                jarray.Add(new JObject(new JProperty("ID", i.ID), new JProperty("Level", 0), new JProperty("CreatedDate", i.CreatedDate.ToShortDateString()),
                    new JProperty("Title", i.Title), new JProperty("MetaTitle", i.MetaTitle), new JProperty("MetaDescription", i.MetaDescription), new JProperty("Parent", i.ParentID), new JProperty("IsActive", i.IsActive), new JProperty("HasChild", haschild)));
                if (subsubs.Count() > 0) SubTreeTableSearch(ref jarray, subsubs, allitems, level + 1, select);
            }
            return jarray;
        }

        #endregion

        #region "Danh cho quản lý danh mục"

        [HttpGet]
        public JArray JTreeTable(int? select, string lang)
        {
           
            var allitems = from x in db.CW_Category orderby x.Order where x.LanguageCode.Equals(lang) select x;
            var roots = from x in allitems where x.ParentID == null select x;
            var jarray = new JArray();
            foreach (var i in roots)
            {
                if (select.HasValue && i.ID == select) continue;
                var subs = from x in allitems where x.ParentID == i.ID select x;
                var haschild = false;
                if (subs.Count() > 0) haschild = true;
                jarray.Add(new JObject(new JProperty("ID", i.ID), new JProperty("Level", 0), new JProperty("CreatedDate", i.CreatedDate.ToShortDateString()),
                    new JProperty("Title", i.Title), new JProperty("MetaTitle", i.MetaTitle), new JProperty("MetaDescription", i.MetaDescription), new JProperty("Parent", null), new JProperty("IsActive", i.IsActive), new JProperty("HasChild", haschild)));
                if (subs.Count() > 0) SubTreeTable(ref jarray, subs, allitems, 1, select);
            }
            return jarray;
        }

        [NonAction]
        private JArray SubTreeTable(ref JArray jarray, IEnumerable<CW_Category> subs, IEnumerable<CW_Category> allitems, int level, int? select)
        {
            foreach (var i in subs)
            {
                if (select.HasValue && i.ID == select) continue;
                var subsubs = from x in allitems where x.ParentID == i.ID orderby x.Order select x;
                var haschild = false;
                if (subsubs.ToList().Count() > 0) haschild = true;
                jarray.Add(new JObject(new JProperty("ID", i.ID), new JProperty("Level", 0),
                    new JProperty("Title", i.Title), new JProperty("CreatedDate", i.CreatedDate.ToShortDateString()), new JProperty("MetaTitle", i.MetaTitle), new JProperty("Parent", i.ParentID), new JProperty("IsActive", i.IsActive), new JProperty("HasChild", haschild)));
                if (subsubs.Count() > 0) SubTreeTable(ref jarray, subsubs, allitems, level + 1, select);
            }
            return jarray;
        }

        #endregion

        #region "dành cho menu"

        [HttpGet]
        public JArray JTreeTableByMenu(int? select, string menucode, string lang)
        {
            var db = new MVCDbContext();
            var allitems = from cate in db.CW_Category
                           join cate_menu in db.CW_Menu_Category
                           on cate.ID equals cate_menu.CategoryID
                           where cate_menu.MenuCode.Equals(menucode) && cate.LanguageCode.Equals(lang)
                           orderby cate_menu.SortOrder
                           select cate;

            var roots = from x in allitems where x.ParentID == null select x;
            var jarray = new JArray();
            foreach (var i in roots)
            {
                if (select.HasValue && i.ID == select) continue;
                var subs = from x in allitems where x.ParentID == i.ID select x;
                var ordercatemenu = db.CW_Menu_Category.Where(x => x.CategoryID == i.ID && x.MenuCode == menucode).FirstOrDefault();
                var haschild = false;
                if (subs.Count() > 0) haschild = true;
                jarray.Add(new JObject(new JProperty("ID", i.ID), new JProperty("Level", 0),
                    new JProperty("Title", i.Title), new JProperty("CreatedDate", i.CreatedDate), new JProperty("SortOrder", ordercatemenu.SortOrder), new JProperty("Parent", null), new JProperty("HasChild", haschild)));
                if (subs.Count() > 0) SubTreeTableByMenu(ref jarray, subs, allitems, 1, select, menucode);
            }
            return jarray;
        }

        [NonAction]
        private JArray SubTreeTableByMenu(ref JArray jarray, IEnumerable<CW_Category> subs, IEnumerable<CW_Category> allitems, int level, int? select, string menucode)
        {
            var db = new MVCDbContext();
            IEnumerable<CW_Category> subsubs = null;
            CW_Menu_Category ordercatemenu = null;
            bool haschild = false;
            foreach (var i in subs)
            {
                if (select.HasValue && i.ID == select) continue;
                subsubs = from x in allitems join cate_menu in db.CW_Menu_Category on x.ID equals cate_menu.CategoryID where x.ParentID == i.ID orderby cate_menu.SortOrder select x;
                ordercatemenu = db.CW_Menu_Category.Where(x => x.CategoryID == i.ID && x.MenuCode == menucode).FirstOrDefault();
                if (subsubs.ToList().Count() > 0) haschild = true;
                jarray.Add(new JObject(new JProperty("ID", i.ID), new JProperty("Level", 0),
                    new JProperty("Title", i.Title), new JProperty("CreatedDate", i.CreatedDate), new JProperty("SortOrder", ordercatemenu.SortOrder), new JProperty("Parent", i.ParentID), new JProperty("HasChild", haschild)));
                if (subsubs.Count() > 0) SubTreeTableByMenu(ref jarray, subsubs, allitems, level + 1, select, menucode);
            }
            return jarray;
        }

        #endregion

        

        public JArray Get()
        {
           
            var allitems = from x in db.CW_Category orderby x.Order select x;
            var roots = allitems.Where(x => x.ParentID == null);
            var jarray = new JArray();
            foreach (var i in roots)
            {
                var subs = allitems.Where(x => x.ParentID == i.ID).ToList(); ;
                var haschild = false;
                if (subs.Count() > 0) haschild = true;
                jarray.Add(new JObject(new JProperty("ID", i.ID),
                    new JProperty("Title", i.Title),
                    new JProperty("MetaTitle", i.MetaTitle), new JProperty("Parent", null), new JProperty("HasChild", haschild),
                     new JProperty("Child", GetJArraySub(subs, allitems))));
            }
            return jarray;
        }

        [NonAction]
        private JArray GetJArraySub(IEnumerable<CW_Category> subs, IEnumerable<CW_Category> allitems)
        {
            var jarray = new JArray();
            if (subs.Count() > 0)
            {
                foreach (var i in subs)
                {
                    var subsubs = allitems.Where(x => x.ParentID == i.ID).ToList(); ;
                    var haschild = false;
                    if (subsubs.Count() > 0) haschild = true;
                    jarray.Add(new JObject(new JProperty("ID", i.ID),
                        new JProperty("Title", i.Title),
                        new JProperty("MetaTitle", i.MetaTitle), new JProperty("Parent", null), new JProperty("HasChild", haschild),
                         new JProperty("Child", GetJArraySub(subsubs, allitems))));
                }
            }
            return jarray;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
