using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Model.EF
{
    [Table("CW_Contact")]
    public class CW_Contact
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập họ tên !")]
        [Display(Name = "Họ tên")]
        [StringLength(100, ErrorMessage = "Bạn chỉ được nhập tối đa 100 ký tự !")]
        public string FullName { get; set; }

        [Display(Name = "Tên công ty")]
        [StringLength(150, ErrorMessage = "Bạn chỉ được nhập tối đa 150 ký tự !")]
        public string Company { get; set; }

        [Display(Name = "Điện thoại")]
        [StringLength(12, ErrorMessage = "Bạn chỉ được nhập tối đa 12 ký tự !")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email không được để trống !")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email không đúng định dạng!")]
        [Display(Name = "Email")]
        [StringLength(100, ErrorMessage = "Bạn chỉ được nhập tối đa 100 ký tự !")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập tiêu đề!")]
        [Display(Name = "Tiêu đề")]
        [StringLength(200, ErrorMessage = "Bạn chỉ được nhập tối đa 200 ký tự !")]
        public string Title { get; set; }

        [Display(Name = "Nội dung")]
        [AllowHtml]
        [StringLength(1500, ErrorMessage = "Bạn chỉ được nhập tối đa 1500 ký tự !")]
        public string Content { get; set; }

        public bool IsRead { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
