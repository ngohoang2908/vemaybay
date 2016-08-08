using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Model.EF
{
    [Table("CW_NewsComment")]
    public class CW_NewsComment
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CommentID { get; set; }

        [Display(Name = "Tin tức")]
        [Required(ErrorMessage = "Bắt buộc phải nhập trường này !")]
        public int ID { get; set; }

        [Display(Name = "Bình luận")]
        [AllowHtml]
        public string Content { get; set; }

        [Required(ErrorMessage = "Bắt buộc phải nhập!")]
        [Display(Name = "Họ tên")]
        [StringLength(70, ErrorMessage = "Bạn chỉ được nhập tối đa 70 ký tự !")]
        public string FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email không được để trống !")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email không đúng định dạng!")]
        [Display(Name = "Email")]
        [StringLength(100, ErrorMessage = "Bạn chỉ được nhập tối đa 100 ký tự !")]
        public string Email { get; set; }

        [Display(Name = "Kích hoạt hiển thị")]
        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual CW_News CW_News { get; set; }
    }

}
