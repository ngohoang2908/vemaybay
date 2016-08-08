using Model.EF;
using System.Collections.Generic;
using System.Web.Mvc;

namespace COMMOM.Interface
{
    public class ICommon
    {
        private static MVCDbContext db = new MVCDbContext();

        [NonAction]
        public static List<CW_Category> ListCategory(int parent, List<CW_Category> objcate, List<CW_Category> objtemp)
        {
            List<CW_Category> objbind = ICategory.catechilby(parent, objcate);
            if (objbind != null && objbind.Count > 0)
            {
                CW_Category objtab = null;
                for (int i = 0; i < objbind.Count; i++)
                {
                    objtab = (CW_Category)objbind[i];
                    objtemp.Add(objtab);
                    ListCategory(objtab.ID, objcate, objtemp);
                }
            }
            return objtemp;
        }
    }
}