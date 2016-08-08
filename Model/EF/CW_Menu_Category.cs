using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Model.EF
{
    [Table("CW_Menu_Category")]
    public class CW_Menu_Category
    {
        //đây là bảng nhiều, mình cần viết kết nối đến bảng 1 như: public virtual Category Category { get; set; }
        [Key, Column(Order = 0)]
        public string MenuCode { get; set; }

        [Key, Column(Order = 1)]
        public int CategoryID { get; set; }

        //[RegularExpression(@"[0-9]*$", ErrorMessage = "Bạn phải nhập kiểu số (1->9) ")]
        public int SortOrder { get; set; }

        public virtual CW_Category Category { get; set; }

        public virtual CW_Menu CW_Menu { get; set; }

    }
}
