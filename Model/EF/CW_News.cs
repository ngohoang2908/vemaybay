using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Model.EF
{
    [Table("CW_News")]
    public class CW_News
    {
        public CW_News()
        {
            this.CW_newscomment = new HashSet<CW_NewsComment>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Yêu cầu nhập tiêu đề !")]
        [StringLength(400, ErrorMessage = "Chỉ được nhập tối đa 400 ký tự !")]
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

        [Display(Name = "Ảnh đại diện")]
        [StringLength(200, ErrorMessage = "Chỉ được nhập tối đa 200 ký tự !")]
        public string Image { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(1000)]
        public string Description { get; set; }

        [Display(Name = "Chi tiết tin")]
        [AllowHtml]
        public string Content { get; set; }

        [Display(Name = "Chú thích ảnh")]
        [StringLength(200, ErrorMessage = "Chỉ được nhập tối đa 200 ký tự !")]
        public string ImageNotes { get; set; }

        [Display(Name = "Số lượng người đọc")]
        public int Read { get; set; }

        [Display(Name = "Kích hoạt")]
        public bool IsActive { get; set; }

        [Display(Name = "Trang chủ")]
        public bool IsHome { get; set; }

        public DateTime CreatedDate { get; set; }

        [Display(Name = "Thứ tự")]
        [Range(0, int.MaxValue, ErrorMessage = "Chỉ được nhập số dương!")]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "Bạn phải nhập kiểu số (1->9) ")]
        public int Order { get; set; }

        [Display(Name = "Danh mục")]
        [Required(ErrorMessage = "Cần phải chọn danh mục !")]
        public int CategoryID { get; set; }

        [Display(Name = "Ngôn ngữ")]
        [StringLength(10, ErrorMessage = "Chỉ được nhập tối đa 10 ký tự !")]
        public string LanguageCode { get; set; }

        [StringLength(400, ErrorMessage = "Chỉ được nhập tối đa 400 ký tự !")]
        public string MetaTitle { get; set; }

        [StringLength(200, ErrorMessage = "Bạn chỉ có thể nhập tối đa 200 ký tự !")]
        public string MetaKeywords { get; set; }

        [StringLength(600, ErrorMessage = "Chỉ được nhập tối đa 600 ký tự !")]
        public string MetaDescription { get; set; }

        public virtual CW_Category Category { get; set; }
        public virtual ICollection<CW_NewsComment> CW_newscomment { get; set; }
        public virtual CW_Language CW_Language { get; set; }
    }
}
