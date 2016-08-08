using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Model.EF
{
    [Table("CW_Support")]
    public class CW_Support
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Nick yahoo")]
        [StringLength(100, ErrorMessage = "Bạn chỉ được nhập tối đa 100 ký tự !")]
        public string NickYahoo
        {
            get;
            set;
        }

        [Display(Name = "Nick skyper")]
        [StringLength(100, ErrorMessage = "Bạn chỉ được nhập tối đa 100 ký tự !")]
        public string NickSkyper { get; set; }

        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Bắt buộc phải nhập!")]
        [StringLength(100, ErrorMessage = "Bạn chỉ được nhập tối đa 100 ký tự !")]
        public string Title { get; set; }

        [Display(Name = "Điện thoại")]
        [StringLength(12, ErrorMessage = "Bạn chỉ được nhập tối đa 12 ký tự !")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(200, ErrorMessage = "Bạn chỉ được nhập tối đa 200 ký tự !")]
        public string Description { get; set; }

        [Display(Name = "Thứ tự")]
        [Range(0, int.MaxValue, ErrorMessage = "Chỉ được nhập số dương !")]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "Bạn phải nhập kiểu số (1->9) ")]
        public int Order { get; set; }

        [Display(Name = "Kích hoạt")]
        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        [Display(Name = "Ngôn ngữ")]
        [StringLength(10, ErrorMessage = "Bạn chỉ được nhập tối đa 10 ký tự !")]
        public string LanguageCode { get; set; }

        public virtual CW_Language CW_Language { get; set; }
    }
}
