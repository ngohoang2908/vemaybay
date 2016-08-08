using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Model.EF
{
    [Table("CW_Article")]
    public class CW_Article
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Yêu cầu nhập tiêu đề !")]
        [StringLength(300, ErrorMessage = "Bạn chỉ được nhập tối đa 300 ký tự !")]
        public string Title
        {
            get;
            set;
        }

        [Display(Name = "Filter title")]
        [Required(ErrorMessage = "Yêu cầu nhập trường này !")]
        public string FilterTitle
        {
            get;
            set;
        }

        [Display(Name = "Mô tả")]
        [StringLength(1000, ErrorMessage = "Bạn chỉ được nhập tối đa 1000 ký tự")]
        public string Description { get; set; }

        [Display(Name = "Chi tiết bài viết")]
        [AllowHtml]
        public string Body { get; set; }

        [Display(Name = "Danh mục")]
        [Required(ErrorMessage = "Bắt buộc phải chọn danh mục")]
        public int CategoryID { get; set; }

        [Display(Name = "Thứ tự")]
        [Range(0, int.MaxValue, ErrorMessage = "Chỉ được nhập số dương !")]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "Bạn phải nhập kiểu số (1->9) ")]
        public int Order { get; set; }

        [Display(Name = "Ngôn ngữ")]
        [StringLength(10, ErrorMessage = "Bạn chỉ được nhập tối đa 10 ký tự !")]
        public string LanguageCode { get; set; }

        [Display(Name = "Kích hoạt")]
        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(400, ErrorMessage = "Bạn chỉ được nhập tối đa 400 ký tự !")]
        public string MetaTitle { get; set; }

        [StringLength(200, ErrorMessage = "Bạn chỉ có thể nhập tối đa 200 ký tự !")]
        public string MetaKeywords { get; set; }

        [StringLength(500, ErrorMessage = "Bạn chỉ được nhập tối đa 500 ký tự !")]
        public string MetaDescription { get; set; }

        public virtual CW_Category Category { get; set; }
        public virtual CW_Language CW_Language { get; set; }
    }
}
