using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Model.EF
{
    //dùng cho thành viên đăng ký 
    [Table("CW_Customers")]
    public class CW_Customers
    {
        [Key]
        [ForeignKey("UserProfile")]
        [HiddenInput(DisplayValue = false)]
        public int UserId { get; set; }

        [Display(Name = "Tài khoản (Email)")]
        [Required(ErrorMessage = "Bắt buộc phải nhập!")]
        [StringLength(70, ErrorMessage = "Bạn chỉ được nhập tối đa 70 ký tự !")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email không đúng định dạng")]
        [DataType(DataType.EmailAddress)]
        public string UserNameCustomer { get; set; }

        [Display(Name = "Yahoo")]
        [StringLength(50, ErrorMessage = "Bạn chỉ được nhập tối đa 50 ký tự !")]
        public string NickYahoo { get; set; }

        [Display(Name = "Skype")]
        [StringLength(50, ErrorMessage = "Bạn chỉ được nhập tối đa 50 ký tự !")]
        public string NickSkype { get; set; }

        [Display(Name = "Facebook")]
        [StringLength(100, ErrorMessage = "Bạn chỉ được nhập tối đa 100 ký tự !")]
        public string Facebook { get; set; }

        [Display(Name = "Nhóm khách hàng")]
        public int? CustomerGroupsID { get; set; }

        [Display(Name = "Tham gia")]
        public DateTime CreatedDate { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual CW_CustomerGroups CW_CustomerGroups { get; set; }
    }
}
