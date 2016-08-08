using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Model.EF
{
    [Table("CW_Category")]
    public class CW_Category
    {
        public CW_Category()
        {
            this.CW_menu_category = new HashSet<CW_Menu_Category>();
            this.CW_articles = new HashSet<CW_Article>();
            this.CW_news = new HashSet<CW_News>();
            //this.Contents = new HashSet<Content>();
            //this.CW_products = new HashSet<CW_Product>();
            //this.CW_files = new HashSet<CW_File>();
            //this.CW_videoclip = new HashSet<CW_VideoClip>();
            //this.CW_album = new HashSet<CW_Album>();
            //this.CW_Category_UpdatePrice = new HashSet<CW_Category_UpdatePrice>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Yêu cầu nhập tiêu đề !")]
        [StringLength(300, ErrorMessage = "Chỉ được nhập tối đa 300 ký tự !")]
        public string Title
        {
            get;
            set;
        }

        [Display(Name = "Kiểu danh mục")]
        [Required(ErrorMessage = "Yêu cầu nhập kiểu danh mục !")]
        [StringLength(100, ErrorMessage = "Chỉ được nhập tối đa 100 ký tự !")]
        public string TypeCode
        {
            get;
            set;
        }

        [Display(Name = "Mã danh mục")]
        [Required(ErrorMessage = "Yêu cầu nhập trường này !")]
        [StringLength(400, ErrorMessage = "Chỉ được nhập tối đa 400 ký tự !")]
        public string CategoryCode { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(1000, ErrorMessage = "Số ký tự cho phép tối đa là 1000!")]
        public string Description { get; set; }

        [Display(Name = "Danh mục cha")]
        public int? ParentID { get; set; }

        [Display(Name = "Thứ tự")]
        [Range(0, int.MaxValue, ErrorMessage = "Thứ tự nhập vào phải là số dương")]
        public int? Order { get; set; }

        [Display(Name = "MetaTitle")]
        [StringLength(400, ErrorMessage = "Chỉ được nhập tối đa 400 ký tự !")]
        public string MetaTitle { get; set; }

        [StringLength(200, ErrorMessage = "Bạn chỉ có thể nhập tối đa 200 ký tự !")]
        public string MetaKeywords { get; set; }

        [Display(Name = "MetaDescription")]
        [StringLength(700, ErrorMessage = "Chỉ được nhập tối đa 700 ký tự !")]
        public string MetaDescription { get; set; }

        [Display(Name = "Liên kết")]
        [StringLength(200, ErrorMessage = "Chỉ được nhập tối đa 200 ký tự !")]
        public string Link { get; set; }

        [Display(Name = "Ảnh đại diện")]
        [StringLength(200, ErrorMessage = "Chỉ được nhập tối đa 200 ký tự !")]
        public string Icon { get; set; }

        [Display(Name = "Kiểu liên kết")]
        [StringLength(50, ErrorMessage = "Chỉ được nhập tối đa 50 ký tự !")]
        public string Target { get; set; }

        [Display(Name = "Kích hoạt")]
        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        [Display(Name = "Ngôn ngữ")]
        [StringLength(10, ErrorMessage = "Chỉ được nhập tối đa 10 ký tự !")]
        public string LanguageCode { get; set; }

        [ForeignKey("ParentID")]
        public virtual ICollection<CW_Category> SubCategories { get; set; }

        [StringLength(300, ErrorMessage = "Chỉ được nhập tối đa 300 ký tự !")]
        public string KeySearch { get; set; }

        public virtual ICollection<CW_Article> CW_articles { get; set; }
        public virtual ICollection<CW_News> CW_news { get; set; }
        //public virtual ICollection<Content> Contents { get; set; }
     
        public virtual ICollection<CW_Menu_Category> CW_menu_category { get; set; }
        public virtual CW_Language CW_Language { get; set; }
    }
}
