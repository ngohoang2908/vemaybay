using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Model.EF
{
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        //[RegularExpression(@"^[a-zA-Z][a-zA-Z0-9]{2,255}$", ErrorMessage = "Định dạng tài khoản không hợp lệ.")]
        [Display(Name = "Tài khoản")]
        [StringLength(50, ErrorMessage = "Bạn chỉ được nhập tối đa 50 ký tự !")]
        public string UserName { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Bắt buộc phải nhập!")]
        [StringLength(70, ErrorMessage = "Bạn chỉ được nhập tối đa 70 ký tự !")]
        public string FullName { get; set; }

        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email không đúng định dạng")]
        [Display(Name = "Email")]
        //[Required(ErrorMessage = "Bắt buộc phải nhập!")]
        [StringLength(70, ErrorMessage = "Bạn chỉ được nhập tối đa 70 ký tự !")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Địa chỉ")]
        [StringLength(200, ErrorMessage = "Bạn chỉ được nhập tối đa 200 ký tự !")]
        public string Address { get; set; }

        [Display(Name = "Điện thoại")]
        [StringLength(12, ErrorMessage = "Bạn chỉ được nhập tối đa 12 ký tự !")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        [Display(Name = "Khóa tài khoản")]
        public bool IsLock { get; set; }

    
    }
}
