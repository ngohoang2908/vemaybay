using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Model.EF
{
    [Table("CW_Menu")]
    public class CW_Menu
    {
        public CW_Menu()
        {
            this.CW_menu_category = new HashSet<CW_Menu_Category>();
        }
        [Key]
        public string MenuCode { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Bạn chỉ được nhập tối đa 100 ký tự !")]
        public string Title
        {
            get;
            set;
        }

        [Range(0, int.MaxValue)]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "Bạn phải nhập kiểu số (1->9) ")]
        public int Order { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<CW_Menu_Category> CW_menu_category { get; set; }
    }
}
