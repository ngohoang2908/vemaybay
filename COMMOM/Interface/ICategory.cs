using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Model.EF;

namespace COMMOM.Interface
{
    public class ICategory
    {
        static MVCDbContext db = new MVCDbContext();
        public static CW_Category objCate = null;
        public static List<CW_Category> listCategory = new List<CW_Category>();

        #region "list categoryby"

        [NonAction]
        public static List<CW_Category> catechilby(int? parent, List<CW_Category> objcate)
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
        public static List<CW_Category> ByTypeCode(int? parent, List<CW_Category> objcate, string space, string typecode, string lang)
        {
            //typecode = "";
            IEnumerable<CW_Category> objtemp = db.CW_Category.Where(x => x.TypeCode == typecode && x.LanguageCode.Equals(lang)).OrderBy(x => x.Order);
            List<CW_Category> objbind = catechilby(parent, objtemp.ToList());
            if (objbind != null && objbind.Count > 0)
            {
                CW_Category objtab = null;
                for (int i = 0; i < objbind.Count; i++)
                {
                    objtab = (CW_Category)objbind[i];
                    objtab.Title = objtab.Title.Replace("--- ", "");
                    objtab.Title = space + objtab.Title;
                    objcate.Add(objtab);
                    if (objbind[i].SubCategories.Count() > 0)
                    {
                        ByTypeCode(objtab.ID, objcate, space + "--- ", typecode, lang);
                    }

                }
            }
            return objcate;
        }

        #endregion

        #region "return list<int> category"

        public static IEnumerable<int> ListCategoryID(IEnumerable<CW_Category> objcate)
        {
            List<int> obj = new List<int>();
            if (objcate.Count() > 0)
            {
                foreach (var item in objcate)
                {
                    if (item.SubCategories.Count() > 0)
                    {
                        foreach (var subitem in item.SubCategories)
                        {
                            obj.Add(subitem.ID);
                        }
                        ListCategoryID(item.SubCategories);
                    }
                }
            }
            return obj;
        }

        #endregion

        public static int? GetRoot(int? CategoryID)
        {
            if (CategoryID == null || CategoryID == -1) return -1;
            CW_Category ydto = new CW_Category();
            ydto.ParentID = null;
            int? cate = CategoryID;
            for (int? i = CategoryID; i != 0; i = ydto.ParentID)
            {
                ydto = db.CW_Category.Where(x => x.ID == i).FirstOrDefault();
                if (ydto == null) return -1;
                if (ydto.ParentID == null)
                {
                    cate = ydto.ID;
                    return cate;
                }
            }
            return cate;
        }

        #region "render breadcrumb website"

        //breadcumbs
        public static CW_Category GetCurentCategory(List<CW_Category> objCate, int? CategoryID)
        {
            foreach (CW_Category obj in objCate)
            {
                if (CategoryID == obj.ID)
                {
                    return obj;
                }
            }
            return null;
        }

        public static List<CW_Category> GetTabsList(List<CW_Category> lstCategory, int? CategoryID)
        {
            objCate = new CW_Category();
            objCate = GetCurentCategory(lstCategory, CategoryID);
            if (objCate != null)
            {
                listCategory.Add(objCate);
                GetTabsList(lstCategory, objCate.ParentID);
            }
            return listCategory;
        }

        public static string GetURL(string typecode, string categoryname, int id, string link)
        {
            string url = "";
            string filter = Filter.FilterChar(categoryname);
            switch (typecode)
            {
                case "bai-viet":
                    url = "/bv/" + filter + "-" + id.ToString();
                    break;
                case "tin-tuc":
                    url = "/ds-" + filter + "-" + id.ToString();
                    break;
                case "san-pham":
                    url = "/" + filter + "-" + id.ToString();
                    break;
                case "lien-ket":
                    url = link;
                    break;
            }
            return url;
        }

        public static string Renderbreadcrumb(int? CategoryID)
        {
            var Objcate = db.CW_Category.Find(CategoryID);
            IEnumerable<CW_Category> category = db.CW_Category.OrderBy(x => x.Order);
            CW_Category obj = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='breadcrumb'>");
            sb.Append("<div class='breadcrumb-inner'>");
            sb.Append("<ul class='list-inline list-unstyled'>");
            sb.Append("<li><a href='/' title='Trang chủ'>Trang chủ <i class='fa fa-angle-double-right'></i></a></li>");
            if (Objcate != null)
            {
                if (GetRoot(CategoryID) == null)
                {
                    sb.Append("<li class='active'>" + Objcate.Title + " <i class='fa fa-angle-double-right'></i></li>");
                }
                else
                {
                    List<CW_Category> ObjcateRoot = GetTabsList(category.ToList(), CategoryID);
                    for (int i = ObjcateRoot.Count - 1; i >= 0; i--)
                    {
                        obj = (CW_Category)ObjcateRoot[i];
                        if (i == 0)
                        {
                            sb.Append("<li class='active'>" + obj.Title + "</li>");
                        }
                        else
                            sb.Append("<li><a href='" + GetURL(obj.TypeCode, obj.Title, obj.ID, obj.Link) + "' title='" + obj.Title + "' >" + obj.Title + " <i class='fa fa-angle-double-right'></i></a></li>");
                    }
                }
            }
            sb.Append("</ul>");
            sb.Append("</div>");
            sb.Append("</div>");
            listCategory = new List<CW_Category>();
            return sb.ToString();
        }

        #endregion

        #region"render menu"

        public static string RenderMenu(string menu, string lang, int? categoryid)
        {
            StringBuilder sb = new StringBuilder();
            IEnumerable<CW_Category> category = from cate in db.CW_Category
                                             join cate_menu in db.CW_Menu_Category
                                             on cate.ID equals cate_menu.CategoryID
                                             where cate_menu.MenuCode.Equals(menu) && cate.ParentID == null && cate.LanguageCode.Equals(lang)
                                             orderby cate_menu.SortOrder
                                             select cate;
            if (category != null)
            {
                sb.Append("<ul class='nav navbar-nav'>");
                foreach (var item in category)
                {
                    if (item.ID == categoryid)
                    {
                        sb.Append("<li class='active'>");
                        sb.Append("<a href='" + Helper.RenderURL(item.TypeCode, item.ID, item.CategoryCode, item.Link) + "' title='" + item.Title + "'>" + item.Title + "</a>");
                        sb.Append(RenderSubMenu(item.ID, category.ToList()));
                        sb.Append("</li>");
                    }
                    else
                    {
                        sb.Append("<li>");
                        sb.Append("<a href='" + Helper.RenderURL(item.TypeCode, item.ID, item.CategoryCode, item.Link) + "' title='" + item.Title + "'>" + item.Title + "</a>");
                        sb.Append(RenderSubMenu(item.ID, category.ToList()));
                        sb.Append("</li>");
                    }

                }

                sb.Append("</ul>");
            }

            return sb.ToString();
        }

        public static string RenderMenuLeft(int parent, string lang, int? categoryid)
        {
            StringBuilder sb = new StringBuilder();
            IEnumerable<CW_Category> category = db.CW_Category.Where(x => x.ParentID == parent && x.LanguageCode.Equals(lang));
            if (category != null)
            {
                sb.Append("<ul class='list-unstyled list-cat'>");
                foreach (var item in category)
                {
                    sb.Append("<li>" + item.Title);
                    sb.Append("<a href='" + Helper.RenderURL(item.TypeCode, item.ID, item.CategoryCode, item.Link) + "' title='" + item.Title + "'></a>");
                    sb.Append(RenderSubMenu(item.ID, category.ToList()));
                    sb.Append("</li>");
                }
                sb.Append("</ul>");
            }

            return sb.ToString();
        }

        public static string RenderSubMenu(int parentid, List<CW_Category> obj)
        {
            var objparent = db.CW_Category.Where(x => x.ParentID == parentid);
            StringBuilder sb = new StringBuilder();
            if (objparent != null && objparent.Count() > 0)
            {
                sb.Append("<ul>");
                foreach (var item in objparent)
                {
                    sb.Append("<li>");
                    sb.Append("<a href='" + Helper.RenderURL(item.TypeCode, item.ID, item.CategoryCode, item.Link) + "' title='" + item.Title + "'>" + item.Title + "</a>");
                    sb.Append(RenderSubMenu(item.ID, obj));
                    sb.Append("</li>");
                }
                sb.Append("</ul>");
            }
            return sb.ToString();
        }

        public static string RenderMenuBottom(string lang, int? categoryid)
        {
            StringBuilder sb = new StringBuilder();
            IEnumerable<CW_Category> category = from cate in db.CW_Category
                                             join cate_menu in db.CW_Menu_Category
                                             on cate.ID equals cate_menu.CategoryID
                                             where cate_menu.MenuCode.Equals("menu-bottom") && cate.ParentID == null && cate.LanguageCode.Equals(lang)
                                             orderby cate_menu.SortOrder
                                             select cate;
            if (category != null)
            {
                sb.Append("<ul class='list-unstyled'>");
                foreach (var item in category)
                {
                    sb.Append("<li>");
                    sb.Append("<a href='" + Helper.RenderURL(item.TypeCode, item.ID, item.CategoryCode, item.Link) + "' title='" + item.Title + "'>" + item.Title + "</a>");
                    sb.Append("</li>");
                }
                sb.Append("</ul>");
            }

            return sb.ToString();
        }

        //Menu tren menu footer
        public static string RenderMenuBottomFooter(string lang, int? categoryid)
        {
            StringBuilder sb = new StringBuilder();
            IEnumerable<CW_Category> category = from cate in db.CW_Category
                                                join cate_menu in db.CW_Menu_Category
                                                on cate.ID equals cate_menu.CategoryID
                                                where cate_menu.MenuCode.Equals("menu-middle") && cate.ParentID == null && cate.LanguageCode.Equals(lang)
                                                orderby cate_menu.SortOrder
                                                select cate;
            if (category != null)
            {
                sb.Append("<ul class='list-unstyled'>");
                foreach (var item in category)
                {
                    sb.Append("<li>");
                    sb.Append("<a href='" + Helper.RenderURL(item.TypeCode, item.ID, item.CategoryCode, item.Link) + "' title='" + item.Title + "'>" + item.Title + "</a>");
                    sb.Append("</li>");
                }
                sb.Append("</ul>");
            }

            return sb.ToString();
        }
        #endregion
    }
}
