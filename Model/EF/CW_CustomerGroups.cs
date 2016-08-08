using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Model.EF
{
    //nhóm khách hàng
    [Table("CW_CustomerGroups")]
    public class CW_CustomerGroups
    {
        public CW_CustomerGroups()
        {
            this.CW_Customers = new HashSet<CW_Customers>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CustomerGroupsID { get; set; }

        [StringLength(100, ErrorMessage = "Bạn chỉ có thể nhập tối đa 100 ký tự !")]
        [Display(Name = "Tên nhóm")]
        [Required(ErrorMessage = "Bắt buộc phải nhập!")]
        public string CustomerGroupName { get; set; }

        [Display(Name = "Nhóm mặc định")]
        public bool IsDefault { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<CW_Customers> CW_Customers { get; set; }
    }
}
