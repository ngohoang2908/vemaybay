    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace MVC4.PROJECT.Models
{
    //public class MVCDbContext:DbContext
    //{
    //    //public DbSet<UserProfile> UserProfiles { get; set; }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    //    }
    //    public MVCDbContext()
    //        : base("DefaultConnection")
    //    {
    //    }
    //    public DbSet<CW_Category> CW_Category { get; set; }
    //    public DbSet<CW_Article> CW_Article { get; set; }
    //    public DbSet<CW_News> CW_News { get; set; }
    //    public DbSet<CW_Adv> CW_Adv { get; set; }
    //    public DbSet<CW_Contact> CW_Contact { get; set; }
    //    public DbSet<CW_Menu> CW_Menu { get; set; }
    //    public DbSet<CW_Support> CW_Support { get; set; }
    //    public DbSet<CW_Setting> CW_Setting { get; set; }
    //    public DbSet<CW_OrderDetail> CW_OrderDetail { get; set; }
    //    public DbSet<CW_Menu_Category> CW_Menu_Category { get; set; }
    //    public DbSet<CW_Product> CW_Product { get; set; }
    //    public DbSet<CW_ProductImages> CW_ProductImages { get; set; }
    //    public DbSet<CW_File> CW_File { get; set; }
    //    public DbSet<CW_Order> CW_Order { get; set; }
    //    public DbSet<CW_OrderStatus> CW_OrderStatus { get; set; }
    //    public DbSet<CW_VideoClip> CW_VideoClip { get; set; }
    //    public DbSet<CW_Album> CW_Album { get; set; }
    //    public DbSet<CW_AlbumImages> CW_AlbumImages { get; set; }
    //    public DbSet<CW_FQAProduct> CW_FQAProduct { get; set; }
    //    public DbSet<CW_NewsComment> CW_NewsComment { get; set; }
    //    public DbSet<CW_Language> CW_Language { get; set; }
    //    public DbSet<CW_OpinionAboutUs> CW_OpinionAboutUs { get; set; }
    //    public DbSet<CW_Email> CW_Email { get; set; }
    //    public DbSet<CW_Vendor> CW_Vendor { get; set; }
    //    public DbSet<CW_ProductField> CW_ProductField { get; set; }
    //    public DbSet<CW_ProductTab> CW_ProductTab { get; set; }
    //    public DbSet<CW_ProductOption> CW_ProductOption { get; set; }
    //    public DbSet<CW_ProductOptionSet> CW_ProductOptionSet { get; set; }
    //    public DbSet<CW_ProductOptionSetValue> CW_ProductOptionSetValue { get; set; }
    //    public DbSet<CW_Product_Option_OptionSet> CW_Product_Option_OptionSet { get; set; }
    //    public DbSet<CW_OptionRule> CW_OptionRule { get; set; }
    //    public DbSet<CW_OptionRuleValue> CW_OptionRuleValue { get; set; }
    //    public DbSet<CW_Option_Rule_SetValue> CW_Option_Rule_SetValue { get; set; }
    //    public DbSet<CW_Option_Rule_Value> CW_Option_Rule_Value { get; set; }
    //    public DbSet<CW_UpdatePrice> CW_UpdatePrice { get; set; }
    //    public DbSet<CW_Category_UpdatePrice> CW_Category_UpdatePrice { get; set; }
    //    public DbSet<CW_Message> CW_Message { get; set; }
    //    public DbSet<CW_MessageReply> CW_MessageReply { get; set; }
    //    public DbSet<CW_SettingCurrency> CW_SettingCurrency { get; set; }
    //    public DbSet<CW_Reviews> CW_Reviews { get; set; }

    //    // phương thức vận chuyển
    //    public DbSet<CW_ShippingMethods> CW_ShippingMethods { get; set; }
    //    public DbSet<CW_ShippingValues> CW_ShippingValues { get; set; }

    //    // phương thức thanh toán
    //    public DbSet<CW_SettingCommonPayment> CW_SettingCommonPayment { get; set; }
    //    public DbSet<CW_SettingCommonPayment_PaymentMethods> CW_SettingCommonPayment_PaymentMethods { get; set; }
    //    public DbSet<CW_PaymentMethods> CW_PaymentMethods { get; set; }
    //    public DbSet<CW_PaymentAtShop> CW_PaymentAtShop { get; set; }
    //    public DbSet<CW_PaymentBaoKimMerchant> CW_PaymentBaoKimMerchant { get; set; }
    //    public DbSet<CW_PaymentNganLuongMerchant> CW_PaymentNganLuongMerchant { get; set; }
    //    public DbSet<CW_PaymentPayPal> CW_PaymentPayPal { get; set; }
    //    public DbSet<CW_PaymentOnePay> CW_PaymentOnePay { get; set; }

    //    //user model
    //    public DbSet<UserProfile> UserProfiles { get; set; }
    //    public DbSet<CW_Customers> CW_Customers { get; set; }
    //    public DbSet<CW_CustomerGroups> CW_CustomerGroups { get; set; }
    //    public DbSet<WebRole> WebRoles { get; set; }
    //    public DbSet<webpages_Membership> webpages_Memberships { get; set; }
    //    public DbSet<Wishlist> CW_Wishlist { get; set; }
    //}
    //[Table("CW_Wishlist")]
    //public class Wishlist
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int ID { get; set; }

    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    public int ProductID { get; set; }

    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    public string UserName { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    public virtual CW_Product CW_Product { get; set; }
    //}
    //#region "Product & product relate table model"

    //[Table("CW_OrderStatus")]
    //public class CW_OrderStatus
    //{
    //    public CW_OrderStatus()
    //    {
    //        this.CW_Order = new HashSet<CW_Order>();
    //    }

    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int OrderStatusID { get; set; }

    //    [Required]
    //    [StringLength(150, ErrorMessage = "Bạn chỉ được nhập tối đa 150 ký tự !")]
    //    public string OrderStatus { get; set; }

    //    public virtual ICollection<CW_Order> CW_Order { get; set; }
    //}

    //[Table("CW_Order")]
    //public class CW_Order
    //{
    //    public CW_Order()
    //    {
    //        this.CW_OrderDetails = new HashSet<CW_OrderDetail>();
    //        this.CW_Message = new HashSet<CW_Message>();
    //    }

    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int OrderID { get; set; }

    //    [Required(ErrorMessage = "Yêu cầu nhập mã đơn hàng !")]
    //    [StringLength(50, ErrorMessage = "Bạn chỉ được nhập tối đa 50 ký tự !")]
    //    public string OrderCode { get; set; }

    //    public int? UserId { get; set; }

    //    [Required(ErrorMessage = "Yêu cầu nhập họ tên !")]
    //    [Display(Name = "Họ tên người đặt hàng")]
    //    [StringLength(100, ErrorMessage = "Bạn chỉ được nhập tối đa 100 ký tự !")]
    //    public string FullnameOrder { get; set; }

    //    public bool SexOrder { get; set; }

    //    [StringLength(200, ErrorMessage = "Bạn chỉ được nhập tối đa 200 ký tự !")]
    //    public string AddressOrder { get; set; }

    //    [DataType(DataType.EmailAddress)]
    //    [Required(ErrorMessage = "Email không được để trống !")]
    //    [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email không đúng định dạng!")]
    //    [Display(Name = "Email")]
    //    [StringLength(100, ErrorMessage = "Bạn chỉ được nhập tối đa 100 ký tự !")]
    //    public string EmailOrder { get; set; }

    //    [Required(ErrorMessage = "Yêu cầu nhập điện thoại !")]
    //    [Display(Name = "Điện thoại")]
    //    [StringLength(12, ErrorMessage = "Bạn chỉ được nhập tối đa 12 ký tự !")]
    //    [DataType(DataType.PhoneNumber)]
    //    public string PhoneOrder { get; set; }

    //    [Display(Name = "Thông tin khác")]
    //    [StringLength(300, ErrorMessage = "Bạn chỉ được nhập tối đa 300 ký tự !")]
    //    public string OtherInfoOrder { get; set; }

    //    [Display(Name = "Họ và tên")]
    //    [StringLength(100, ErrorMessage = "Bạn chỉ được nhập tối đa 100 ký tự !")]
    //    public string FullnameReceived { get; set; }

    //    [Display(Name = "Giới tính")]
    //    public bool SexReceived { get; set; }

    //    [Display(Name = "Địa chỉ")]
    //    [StringLength(200, ErrorMessage = "Bạn chỉ được nhập tối đa 200 ký tự !")]
    //    public string AddressReceived { get; set; }

    //    [DataType(DataType.EmailAddress)]
    //    //[Required(ErrorMessage = "Email không được để trống !")]
    //    [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email không đúng định dạng!")]
    //    [Display(Name = "Email")]
    //    [StringLength(100, ErrorMessage = "Bạn chỉ được nhập tối đa 100 ký tự !")]
    //    public string EmailReceived { get; set; }

    //    //[Required(ErrorMessage = "Yêu cầu nhập điện thoại !")]
    //    [Display(Name = "Điện thoại")]
    //    [StringLength(12, ErrorMessage = "Bạn chỉ được nhập tối đa 12 ký tự !")]
    //    [DataType(DataType.PhoneNumber)]
    //    public string PhoneReceived { get; set; }

    //    [Display(Name = "Thông tin khác")]
    //    [StringLength(300, ErrorMessage = "Bạn chỉ được nhập tối đa 300 ký tự !")]
    //    public string OtherInfoReceived { get; set; }

    //    [Display(Name = "Phương thức vận chuyển")]
    //    public int Shipping { get; set; }

    //    [StringLength(200, ErrorMessage = "Bạn chỉ được nhập tối đa 200 ký tự !")]
    //    [Display(Name = "Thêm ghi chú cho đơn hàng")]
    //    public string TransitTime { get; set; }

    //    [Display(Name = "Phương thức thanh toán")]
    //    public int Payment { get; set; }

    //    [Display(Name = "Tổng tiền thanh toán")]
    //    public decimal TotalPayment { get; set; }

    //    [Display(Name = "Phí vận chuyển")]
    //    public decimal PriceShipping { get; set; }

    //    public int ProductNumber { get; set; }

    //    [Required]
    //    public int OrderStatusID { get; set; }

    //    public DateTime OnOrder { get; set; }

    //    public bool IsRead { get; set; }

    //    public virtual ICollection<CW_OrderDetail> CW_OrderDetails { get; set; }
    //    public virtual ICollection<CW_Message> CW_Message { get; set; }
    //    public virtual UserProfile UserProfile { get; set; }
    //    public virtual CW_OrderStatus CW_OrderStatus { get; set; }
    //}

    //[Table("CW_OrderDetail")]
    //public class CW_OrderDetail
    //{
    //    [Key, Column(Order = 1)]
    //    public int OrderID { get; set; }

    //    [Key, Column(Order = 2)]
    //    public int ProductID { get; set; }

    //    public int Number { get; set; }

    //    public virtual CW_Order CW_Order { get; set; }
    //    public virtual CW_Product CW_Product { get; set; }

    //}

    //[Table("CW_Product")]
    //public class CW_Product
    //{
    //    public CW_Product()
    //    {
    //        this.CW_ProductTab = new HashSet<CW_ProductTab>();
    //        this.CW_ProductField = new HashSet<CW_ProductField>();
    //        this.CW_ProductImages = new HashSet<CW_ProductImages>();
    //        this.CW_FQAProduct = new HashSet<CW_FQAProduct>();
    //        this.CW_Wishlist = new HashSet<Wishlist>();
    //        this.CW_OrderDetail = new HashSet<CW_OrderDetail>();
    //        this.CW_OptionRule = new HashSet<CW_OptionRule>();
    //        this.CW_Reviews = new HashSet<CW_Reviews>();
    //    }

    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int ProductID { get; set; }

    //    [Display(Name = "Danh mục")]
    //    [Required(ErrorMessage = "Bắt buộc phải chọn danh mục sản phẩm!")]
    //    public int CategoryID { get; set; }

    //    [Display(Name = "Tên sản phẩm")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập tên sản phẩm!")]
    //    [StringLength(200, ErrorMessage = "Bạn chỉ có thể nhập tối đa 200 ký tự !")]
    //    public string ProductName { get; set; }

    //    [Display(Name = "Filter title")]
    //    [Required(ErrorMessage = "Yêu cầu nhập trường này !")]
    //    public string FilterTitle
    //    {
    //        get;
    //        set;
    //    }

    //    [Display(Name = "Mã sản phẩm")]
    //    [StringLength(30, ErrorMessage = "Bạn chỉ có thể nhập tối đa 30 ký tự !")]
    //    public string ProductCode { get; set; }

    //    [Display(Name = "Giá bán")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập giá bán, nếu không nhập số 0!")]
    //    [DataType(DataType.Currency)]
    //    //[RegularExpression(@"[0-9]*$", ErrorMessage = "Bạn phải nhập kiểu số (1->9) ")]
    //    public decimal Price { get; set; }

    //    [Display(Name = "Giá khuyến mãi")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập giá bán, nếu không nhập số 0!")]
    //    [DataType(DataType.Currency)]
    //    //[RegularExpression(@"[0-9]*$", ErrorMessage = "Bạn phải nhập kiểu số (1->9) ")]
    //    public decimal PriceSaleOff { get; set; }

    //    [Display(Name = "Mô tả")]
    //    [StringLength(3000)]
    //    public string Description { get; set; }

    //    [Display(Name = "Chi tiết sản phẩm")]
    //    [AllowHtml]
    //    public string Content { get; set; }

    //    [Display(Name = "Lượt xem")]
    //    public int ViewCount { get; set; }

    //    [StringLength(20)]
    //    public string CreatedBy { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    [StringLength(20)]
    //    public string ModifiedBy { get; set; }

    //    public DateTime ModifiedDate { get; set; }

    //    [AllowHtml]
    //    public string Tag { get; set; }

    //    [StringLength(200, ErrorMessage = "Bạn chỉ có thể nhập tối đa 200 ký tự !")]
    //    public string Metatitle { get; set; }

    //    [StringLength(200, ErrorMessage = "Bạn chỉ có thể nhập tối đa 200 ký tự !")]
    //    public string MetaKeywords { get; set; }

    //    [StringLength(300, ErrorMessage = "Bạn chỉ có thể nhập tối đa 300 ký tự !")]
    //    public string MetaDescription { get; set; }

    //    [Display(Name = "Kích hoạt")]
    //    public bool IsActive { get; set; }

    //    [Display(Name = "Đang hót")]
    //    public bool IsHot { get; set; }

    //    [Display(Name = "Hàng mới về")]
    //    public bool IsNew { get; set; }

    //    [Display(Name = "Sản phẩm nổi bật")]
    //    public bool IsFeatured { get; set; }

    //    [Display(Name = "Sản phẩm khuyến mãi")]
    //    public bool IsPromotion { get; set; }

    //    [Display(Name = "Thứ tự")]
    //    [Range(0, int.MaxValue, ErrorMessage = "Số thứ tự phải nhập vào số dương!")]
    //    [Required(ErrorMessage = "Cần phải nhập số thứ tự!")]
    //    [RegularExpression(@"[0-9]*$", ErrorMessage = "Bạn phải nhập kiểu số (1->9) ")]
    //    public int SortOrder { get; set; }

    //    [Display(Name = "Cho phép đặt hàng")]
    //    [StringLength(20, ErrorMessage = "Bạn chỉ có thể nhập tối đa 20 ký tự !")]
    //    public string IsAllowPurchase { get; set; }

    //    [Display(Name = "Chữ hiển thị thay thế")]
    //    [StringLength(50, ErrorMessage = "Bạn chỉ có thể nhập tối đa 50 ký tự !")]
    //    public string CallForPricingLabel { get; set; }

    //    [Display(Name = "Ngôn ngữ")]
    //    [StringLength(10, ErrorMessage = "Bạn chỉ có thể nhập tối đa 10 ký tự !")]
    //    public string LanguageCode { get; set; }

    //    [Display(Name = "Sản phẩm liên quan")]
    //    [StringLength(100, ErrorMessage = "Bạn chỉ có thể nhập tối đa 100 ký tự !")]
    //    public string ProductRelateID { get; set; }

    //    [Display(Name = "Dùng để search sản phẩm")]
    //    public string KeySearch { get; set; }

    //    [Display(Name = "Nhà sản xuất")]
    //    public int? VendorID { get; set; }

    //    [Display(Name = "Nhóm tùy chọn")]
    //    public int? ProductOptionID { get; set; }

    //    public virtual CW_Language CW_Language { get; set; }

    //    public virtual CW_Category Category { get; set; }
    //    public virtual CW_ProductOption CW_ProductOption { get; set; }
    //    public virtual CW_Vendor CW_Vendor { get; set; }
    //    public virtual ICollection<CW_ProductTab> CW_ProductTab { get; set; }
    //    public virtual ICollection<CW_ProductField> CW_ProductField { get; set; }
    //    public virtual ICollection<CW_ProductImages> CW_ProductImages { get; set; }
    //    public virtual ICollection<CW_FQAProduct> CW_FQAProduct { get; set; }
    //    public virtual ICollection<Wishlist> CW_Wishlist { get; set; }
    //    public virtual ICollection<CW_OrderDetail> CW_OrderDetail { get; set; }
    //    public virtual ICollection<CW_OptionRule> CW_OptionRule { get; set; }
    //    public virtual ICollection<CW_Reviews> CW_Reviews { get; set; }

    //    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    //    {
    //        if (Price < PriceSaleOff)
    //        {
    //            yield return new ValidationResult("Giá khuyến mãi phải nhỏ hơn giá gốc !");
    //        }
    //    }
    //}

    ////ảnh sản phẩm
    //[Table("CW_ProductImages")]
    //public class CW_ProductImages
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int ID { get; set; }

    //    [Required(ErrorMessage = "Bắt buộc phải chọn!")]
    //    [Display(Name = "Sản phẩm")]
    //    public int ProductID { get; set; }

    //    [StringLength(300, ErrorMessage = "Bạn chỉ có thể nhập tối đa 300 ký tự !")]
    //    public string Image { get; set; } // anh nho

    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [Display(Name = "Ảnh sản phẩm")]
    //    [StringLength(300, ErrorMessage = "Bạn chỉ có thể nhập tối đa 300 ký tự !")]
    //    public string Images { get; set; }// anh lon

    //    [Display(Name = "Chọn ảnh hiện thị mặc định")]
    //    public bool IsDefault { get; set; }// chon anh hien thi mac dinh

    //    public DateTime CreatedDate { get; set; }

    //    public virtual CW_Product CW_Product { get; set; }
    //}

    ////Nhóm tùy chọn
    //[Table("CW_ProductOption")]
    //public class CW_ProductOption
    //{
    //    public CW_ProductOption()
    //    {
    //        this.CW_Product = new HashSet<CW_Product>();
    //        this.CW_Product_Option_OptionSet = new HashSet<CW_Product_Option_OptionSet>();
    //    }

    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int ProductOptionID { get; set; }

    //    [Display(Name = "Nhóm tùy chọn")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [StringLength(200, ErrorMessage = "Bạn chỉ có thể nhập tối đa 100 ký tự !")]
    //    public string ProductOptionName { get; set; }

    //    [Display(Name = "Ngôn ngữ")]
    //    [StringLength(10, ErrorMessage = "Bạn chỉ có thể nhập tối đa 10 ký tự !")]
    //    public string LanguageCode { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    public virtual ICollection<CW_Product> CW_Product { get; set; }
    //    public virtual ICollection<CW_Product_Option_OptionSet> CW_Product_Option_OptionSet { get; set; }

    //}

    ////Tùy chọn
    //[Table("CW_ProductOptionSet")]
    //public class CW_ProductOptionSet
    //{
    //    public CW_ProductOptionSet()
    //    {
    //        this.CW_Product_Option_OptionSet = new HashSet<CW_Product_Option_OptionSet>();
    //        this.CW_ProductOptionSetValue = new HashSet<CW_ProductOptionSetValue>();
    //    }

    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int ProductOptionSetID { get; set; }

    //    [Display(Name = "Tùy chọn")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [StringLength(200, ErrorMessage = "Bạn chỉ có thể nhập tối đa 200 ký tự !")]
    //    public string ProductOptionSetName { get; set; }

    //    [Display(Name = "Kiểu tùy chọn")]
    //    [RegularExpression(@"[0-9]*$", ErrorMessage = "Bạn phải nhập kiểu số (1->9) ")]
    //    public Int16 Datatype { get; set; } // 1. là kiểu tùy chọn thông thường    2. là kiểu tùy chọn màu sắc

    //    [Display(Name = "Kiểu hiển thị")]
    //    [RegularExpression(@"[0-9]*$", ErrorMessage = "Bạn phải nhập kiểu số (1->9) ")]
    //    public Int16? DisplayType { get; set; } // 1. Rectangle (hình chữ nhật)    2. Radio Box   3. Select Box

    //    [Display(Name = "Ngôn ngữ")]
    //    [StringLength(10, ErrorMessage = "Bạn chỉ có thể nhập tối đa 10 ký tự !")]
    //    public string LanguageCode { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    public virtual ICollection<CW_Product_Option_OptionSet> CW_Product_Option_OptionSet { get; set; }
    //    public virtual ICollection<CW_ProductOptionSetValue> CW_ProductOptionSetValue { get; set; }

    //}

    ////Bảng kết nối giữa CW_ProductOptionSet và CW_ProductOption
    //[Table("CW_Product_Option_OptionSet")]
    //public class CW_Product_Option_OptionSet
    //{
    //    [Key, Column(Order = 0)]
    //    public int ProductOptionID { get; set; }

    //    [Key, Column(Order = 1)]
    //    public int ProductOptionSetID { get; set; }

    //    public virtual CW_ProductOption CW_ProductOption { get; set; }

    //    public virtual CW_ProductOptionSet CW_ProductOptionSet { get; set; }
    //}

    ////bảng giá trị tùy chọn
    //[Table("CW_ProductOptionSetValue")]
    //public class CW_ProductOptionSetValue
    //{
    //    public CW_ProductOptionSetValue()
    //    {
    //        this.CW_Option_Rule_SetValue = new HashSet<CW_Option_Rule_SetValue>();
    //    }


    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int ProductOptionSetValueID { get; set; }

    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [RegularExpression(@"[0-9]*$", ErrorMessage = "Bạn phải nhập kiểu số (1->9) ")]
    //    public int ProductOptionSetID { get; set; }

    //    [Display(Name = "Tên hiển thị")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [StringLength(200, ErrorMessage = "Bạn chỉ có thể nhập tối đa 200 ký tự !")]
    //    public string ProductOptionSetValueName { get; set; }

    //    [Display(Name = "Kiểu giá trị")]
    //    [RegularExpression(@"[0-9]*$", ErrorMessage = "Bạn phải nhập kiểu số (1->9) ")]
    //    public Int16? ProductOptionSetType { get; set; } // 1. là kiểu màu sắc    2. là kiểu ảnh hiên thị

    //    [Display(Name = "Giá trị")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [StringLength(200, ErrorMessage = "Bạn chỉ có thể nhập tối đa 200 ký tự !")]
    //    public string ProductOptionSetValue { get; set; }

    //    [Display(Name = "Ngôn ngữ")]
    //    [StringLength(10, ErrorMessage = "Bạn chỉ có thể nhập tối đa 10 ký tự !")]
    //    public string LanguageCode { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    public virtual CW_ProductOptionSet CW_ProductOptionSet { get; set; }
    //    public virtual ICollection<CW_Option_Rule_SetValue> CW_Option_Rule_SetValue { get; set; }

    //}

    ////nhà sản xuất
    //[Table("CW_Vendor")]
    //public class CW_Vendor
    //{
    //    public CW_Vendor()
    //    {
    //        this.CW_Product = new HashSet<CW_Product>();
    //    }

    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int VendorID { get; set; }

    //    [Display(Name = "Nhà sản xuất")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [StringLength(200, ErrorMessage = "Bạn chỉ có thể nhập tối đa 200 ký tự !")]
    //    public string VendorName { get; set; }

    //    [Display(Name = "Fiiter name")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [StringLength(200, ErrorMessage = "Bạn chỉ có thể nhập tối đa 200 ký tự !")]
    //    public string FilterTitle { get; set; }

    //    [Display(Name = "Logo")]
    //    [StringLength(200, ErrorMessage = "Bạn chỉ có thể nhập tối đa 200 ký tự !")]
    //    public string Logo { get; set; }

    //    [Display(Name = "Số điện thoại")]
    //    [StringLength(12, ErrorMessage = "Bạn chỉ có thể nhập tối đa 12 ký tự !")]
    //    public string Phone { get; set; }

    //    [Display(Name = "Địa chỉ")]
    //    [StringLength(300, ErrorMessage = "Bạn chỉ có thể nhập tối đa 300 ký tự !")]
    //    public string Address { get; set; }

    //    [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email không đúng định dạng")]
    //    [Display(Name = "Email")]
    //    [DataType(DataType.EmailAddress)]
    //    [StringLength(100, ErrorMessage = "Bạn chỉ có thể nhập tối đa 100 ký tự !")]
    //    public string Email { get; set; }

    //    [Display(Name = "Mô tả")]
    //    [StringLength(300, ErrorMessage = "Bạn chỉ có thể nhập tối đa 300 ký tự !")]
    //    public string Description { get; set; }

    //    [Display(Name = "Ngôn ngữ")]
    //    [StringLength(10, ErrorMessage = "Bạn chỉ có thể nhập tối đa 10 ký tự !")]
    //    public string LanguageCode { get; set; }

    //    [Display(Name = "Hiển thị")]
    //    public bool IsActive { get; set; }

    //    [Display(Name = "Thứ tự")]
    //    public int SortOrder { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    public virtual ICollection<CW_Product> CW_Product { get; set; }

    //}

    //[Table("CW_FQAProduct")]
    //public class CW_FQAProduct
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int FQAID { get; set; }

    //    [Required(ErrorMessage = "Bắt buộc phải chọn!")]
    //    [Display(Name = "Sản phẩm")]
    //    public int ProductID { get; set; }

    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [Display(Name = "Họ tên")]
    //    [StringLength(100, ErrorMessage = "Bạn chỉ có thể nhập tối đa 100 ký tự !")]
    //    public string FullName { get; set; }

    //    [DataType(DataType.EmailAddress)]
    //    [Required(ErrorMessage = "Email không được để trống !")]
    //    [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email không đúng định dạng!")]
    //    [Display(Name = "Email")]
    //    [StringLength(100, ErrorMessage = "Bạn chỉ có thể nhập tối đa 100 ký tự !")]
    //    public string Email { get; set; }

    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [Display(Name = "Câu hỏi")]
    //    [StringLength(300, ErrorMessage = "Bạn chỉ có thể nhập tối đa 300 ký tự !")]
    //    public string Question { get; set; }

    //    [Display(Name = "Câu trả lời")]
    //    [StringLength(500, ErrorMessage = "Bạn chỉ có thể nhập tối đa 500 ký tự !")]
    //    public string Answer { get; set; }

    //    [Display(Name = "Hiển thị ra ngoài trang")]
    //    public bool IsActive { get; set; }

    //    public bool IsRead { get; set; }// Đã xem câu hỏi hay chưa

    //    public DateTime QuestionDate { get; set; }

    //    public DateTime AnswerDate { get; set; }

    //    [Display(Name = "Full text search")]
    //    [StringLength(500, ErrorMessage = "Bạn chỉ có thể nhập tối đa 500 ký tự !")]
    //    public string SearchKey { get; set; }

    //    public virtual CW_Product CW_Product { get; set; }
    //}

    ////thông tin tùy chọn sản phẩm
    //[Table("CW_ProductField")]
    //public class CW_ProductField
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int FieldID { get; set; }

    //    [Required(ErrorMessage = "Bắt buộc phải chọn!")]
    //    [Display(Name = "Sản phẩm")]
    //    public int ProductID { get; set; }

    //    [Display(Name = "Tên")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [StringLength(100, ErrorMessage = "Bạn chỉ có thể nhập tối đa 100 ký tự !")]
    //    public string FieldName { get; set; } // anh nho

    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [Display(Name = "Giá trị")]
    //    [StringLength(200, ErrorMessage = "Bạn chỉ có thể nhập tối đa 200 ký tự !")]
    //    public string FieldValue { get; set; }// anh lon

    //    public DateTime CreatedDate { get; set; }

    //    public virtual CW_Product CW_Product { get; set; }
    //}

    ////Tab thông tin sản phẩm
    //[Table("CW_ProductTab")]
    //public class CW_ProductTab
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int ProductTabID { get; set; }

    //    [Required(ErrorMessage = "Bắt buộc phải chọn!")]
    //    [Display(Name = "Sản phẩm")]
    //    public int ProductID { get; set; }

    //    [Display(Name = "Tên tab hiển thị")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [StringLength(100, ErrorMessage = "Bạn chỉ có thể nhập tối đa 100 ký tự !")]
    //    public string TabName { get; set; }

    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [Display(Name = "Thông tin hiển thị")]
    //    [AllowHtml]
    //    public string TabValue { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    public virtual CW_Product CW_Product { get; set; }
    //}

    ////Bảng nhóm quy tắc áp dụng cho nhóm tùy chọn của sản phẩm
    //[Table("CW_OptionRule")]
    //public class CW_OptionRule
    //{
    //    public CW_OptionRule()
    //    {
    //        this.CW_Option_Rule_Value = new HashSet<CW_Option_Rule_Value>();
    //        this.CW_Option_Rule_SetValue = new HashSet<CW_Option_Rule_SetValue>();
    //    }

    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int OptionRuleID { get; set; }

    //    [Required(ErrorMessage = "Bắt buộc phải chọn!")]
    //    [Display(Name = "Sản phẩm")]
    //    public int ProductID { get; set; }

    //    [Display(Name = "Sử dụng")]
    //    public bool IsUse { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    public virtual CW_Product CW_Product { get; set; }

    //    public virtual ICollection<CW_Option_Rule_Value> CW_Option_Rule_Value { get; set; }
    //    public virtual ICollection<CW_Option_Rule_SetValue> CW_Option_Rule_SetValue { get; set; }
    //}

    ////Bảng liên kết giữa CW_OptionRule và CW_ProductOptionSetValue
    //[Table("CW_Option_Rule_SetValue")]
    //public class CW_Option_Rule_SetValue
    //{
    //    [Key, Column(Order = 0)]
    //    public int ProductOptionSetValueID { get; set; }

    //    [Key, Column(Order = 1)]
    //    public int OptionRuleID { get; set; }

    //    public virtual CW_ProductOptionSetValue CW_ProductOptionSetValue { get; set; }

    //    public virtual CW_OptionRule CW_OptionRule { get; set; }
    //}

    ////Bảng chứa giá trị quy tắc
    //[Table("CW_OptionRuleValue")]
    //public class CW_OptionRuleValue
    //{
    //    public CW_OptionRuleValue()
    //    {
    //        this.CW_Option_Rule_Value = new HashSet<CW_Option_Rule_Value>();
    //    }

    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int OptionRuleValueID { get; set; }

    //    [Display(Name = "Tên quy tắc")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [StringLength(100, ErrorMessage = "Bạn chỉ có thể nhập tối đa 100 ký tự !")]
    //    public string OptionRuleValue { get; set; }

    //    [Display(Name = "Loại quy tắc")]
    //    public int OptionRuleType { get; set; }  // 1. kiểu text nhập   2. kiểu ảnh.

    //    public DateTime CreatedDate { get; set; }

    //    public virtual ICollection<CW_Option_Rule_Value> CW_Option_Rule_Value { get; set; }

    //}

    ////Bảng liên kết giữa bảng CW_OptionRuleValue và CW_OptionRule
    //[Table("CW_Option_Rule_Value")]
    //public class CW_Option_Rule_Value
    //{
    //    [Key, Column(Order = 0)]
    //    public int OptionRuleValueID { get; set; }

    //    [Key, Column(Order = 1)]
    //    public int OptionRuleID { get; set; }

    //    [Display(Name = "Giá trị")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [StringLength(150, ErrorMessage = "Bạn chỉ có thể nhập tối đa 150 ký tự !")]
    //    public string SaveOptionRuleValue { get; set; }

    //    public virtual CW_OptionRuleValue CW_OptionRuleValue { get; set; }

    //    public virtual CW_OptionRule CW_OptionRule { get; set; }

    //}

    ////cập nhật giá
    //[Table("CW_UpdatePrice")]
    //public class CW_UpdatePrice
    //{
    //    public CW_UpdatePrice()
    //    {
    //        this.CW_Category_UpdatePrice = new HashSet<CW_Category_UpdatePrice>();
    //    }

    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int UpdatePriceID { get; set; }

    //    [Display(Name = "Kiểu cập nhật giá")]
    //    public int UpdatePriceType { get; set; } //tăng hoặc giảm giá

    //    [Display(Name = "Kiểu giá")]
    //    public string Kind { get; set; } // VNĐ hoặc %

    //    [Display(Name = "Giá trị thay đổi")]
    //    public decimal PriceNew { get; set; }

    //    [Display(Name = "Giá trị thay đổi")]
    //    public DateTime CreatedDate { get; set; }

    //    public virtual ICollection<CW_Category_UpdatePrice> CW_Category_UpdatePrice { get; set; }
    //}

    //[Table("CW_Category_UpdatePrice")]
    //public class CW_Category_UpdatePrice
    //{
    //    [Key, Column(Order = 0)]
    //    public int UpdatePriceID { get; set; }

    //    [Key, Column(Order = 1)]
    //    public int CategoryID { get; set; }

    //    public virtual CW_Category Category { get; set; }

    //    public virtual CW_UpdatePrice CW_UpdatePrice { get; set; }

    //}

    ////tin nhắn đơn hàng
    //[Table("CW_Message")]
    //public class CW_Message
    //{
    //    public CW_Message()
    //    {
    //        this.CW_MessageReply = new HashSet<CW_MessageReply>();
    //    }

    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int MessageID { get; set; }

    //    [Display(Name = "Đơn hàng")]
    //    [Required(ErrorMessage = "Bắt buộc phải chọn !")]
    //    public int OrderID { get; set; }

    //    [Display(Name = "Tải khoản")]
    //    [Required(ErrorMessage = "Bắt buộc phải chọn !")]
    //    public int UserId { get; set; }

    //    [Display(Name = "Tiêu đề")]
    //    [Required(ErrorMessage = "Yêu cầu nhập tiêu đề !")]
    //    [StringLength(100, ErrorMessage = "Chỉ được nhập tối đa 100 ký tự !")]
    //    public string Title { get; set; }

    //    [Display(Name = "Nội dung")]
    //    [Required(ErrorMessage = "Yêu cầu nhập nội dung !")]
    //    [StringLength(1000, ErrorMessage = "Chỉ được nhập tối đa 1000 ký tự !")]
    //    public string Content { get; set; }

    //    public bool IsShowed { get; set; }

    //    public bool IsRead { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    public virtual CW_Order CW_Order { get; set; }
    //    public virtual CW_Customers CW_Customers { get; set; }
    //    public virtual ICollection<CW_MessageReply> CW_MessageReply { get; set; }
    //}

    ////Trả lời tin nhắn đơn hàng
    //[Table("CW_MessageReply")]
    //public class CW_MessageReply
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int ReplyMessageID { get; set; }

    //    [Display(Name = "Tin nhắn")]
    //    [Required(ErrorMessage = "Bắt buộc phải chọn !")]
    //    public int MessageID { get; set; }

    //    [Display(Name = "Tiêu đề")]
    //    [Required(ErrorMessage = "Yêu cầu nhập tiêu đề !")]
    //    [StringLength(100, ErrorMessage = "Chỉ được nhập tối đa 100 ký tự !")]
    //    public string Title { get; set; }

    //    [Display(Name = "Nội dung")]
    //    [Required(ErrorMessage = "Yêu cầu nhập nội dung !")]
    //    [StringLength(1000, ErrorMessage = "Chỉ được nhập tối đa 1000 ký tự !")]
    //    public string Content { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    public virtual CW_Message CW_Message { get; set; }
    //}

    ////bảng quản lý phương thức vận chuyển
    //[Table("CW_ShippingMethods")]
    //public class CW_ShippingMethods
    //{
    //    public CW_ShippingMethods()
    //    {
    //        this.CW_ShippingValues = new HashSet<CW_ShippingValues>();
    //    }

    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int ShippingMethodsID { get; set; }

    //    [Display(Name = "Phương thức vận chuyển")]
    //    [Required(ErrorMessage = "Bắt buộc phải chọn !")]
    //    public int ShppingMethods { get; set; } //1. Miễn phí vận chuyển, 2. Phí cố định, 3. Phí cố định trên một đơn vị sản phẩm, 4. Phí theo giá trị đơn hàng

    //    [Display(Name = "Tên hiển thị")]
    //    [Required(ErrorMessage = "Bắt buộc phải chọn !")]
    //    [StringLength(100, ErrorMessage = "Chỉ được nhập tối đa 100 ký tự !")]
    //    public string NameView { get; set; }

    //    [Display(Name = "Thời gian vận chuyển")]
    //    [StringLength(100, ErrorMessage = "Chỉ được nhập tối đa 100 ký tự !")]
    //    public string TimeShipping { get; set; }

    //    [Display(Name = "Bật chức năng này")]
    //    public bool IsEnable { get; set; }

    //    [Display(Name = "Thứ tự")]
    //    public int SortOrder { get; set; }

    //    [Display(Name = "Phí vận chuyển")]
    //    public decimal PriceShipping { get; set; }

    //    public virtual ICollection<CW_ShippingValues> CW_ShippingValues { get; set; }

    //}

    ////bẳng lưu giá trị khi phương thức vận chuyển được chọn là 4
    //[Table("CW_ShippingValues")]
    //public class CW_ShippingValues
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int ShippingValuesID { get; set; }

    //    [Required]
    //    public int ShippingMethodsID { get; set; }

    //    [Display(Name = "Giá mặc định")]
    //    public decimal DefaultPrice { get; set; }

    //    [Display(Name = "Giá đơn hàng nhỏ")]
    //    public decimal LowerRangePriceOrder { get; set; } // giá đơn hàng nhỏ

    //    [Display(Name = "Giá đơn hàng lớn")]
    //    public decimal UpperRangePriceOrder { get; set; } // giá đơn hàng lớn

    //    [Display(Name = "Gía vận chuyển")]
    //    public decimal PriceShippingValue { get; set; }

    //    public virtual CW_ShippingMethods CW_ShippingMethods { get; set; }
    //}

    //[Table("CW_SettingCurrency")]
    //public class CW_SettingCurrency
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int SettingCurrencyID { get; set; }

    //    [Display(Name = "Tiền tệ")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập !")]
    //    [StringLength(50, ErrorMessage = "Chỉ được nhập tối đa 50 ký tự !")]
    //    public string CurrencyName { get; set; }

    //    [Display(Name = "Mã tiền tệ ")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập !")]
    //    [StringLength(50, ErrorMessage = "Chỉ được nhập tối đa 50 ký tự !")]
    //    public string CurrencyCode { get; set; }

    //    [Display(Name = "Tỷ giá ")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập !")]
    //    public string ExchangeRate { get; set; }

    //    [Display(Name = "Ký tự hiển thị ")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập !")]
    //    [StringLength(50, ErrorMessage = "Chỉ được nhập tối đa 50 ký tự !")]
    //    public string CurrencyString { get; set; }

    //    [Display(Name = "Vị trí ")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập !")]
    //    [StringLength(50, ErrorMessage = "Chỉ được nhập tối đa 50 ký tự !")]
    //    public string Position { get; set; } // trái phải

    //    [Display(Name = "Mặc định ")]
    //    public bool IsDefault { get; set; } // mặc định là false

    //    [Display(Name = "Kích hoạt sử dụng ")]
    //    public bool IsActive { get; set; } // mặc định là false

    //    [Display(Name = "Ngày cập nhật ")]
    //    public DateTime UpdatedOn { get; set; }

    //    [Display(Name = "Cập nhật từ hệ thống ")]
    //    public bool IsUpdateFromSystem { get; set; } // mặc định là true
    //}

    ////Đánh giá sản phẩm
    //[Table("CW_Reviews")]
    //public class CW_Reviews
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int ReviewsID { get; set; }

    //    [Display(Name = "Sản phẩm")]
    //    [Required(ErrorMessage = "Bắt buộc phải chọn !")]
    //    public int ProductID { get; set; }

    //    [Display(Name = "Họ và tên")]
    //    [Required(ErrorMessage = "Yêu cầu nhập họ và tên !")]
    //    [StringLength(100, ErrorMessage = "Chỉ được nhập tối đa 100 ký tự !")]
    //    public string YourName { get; set; }

    //    [Display(Name = "Viết đánh giá")]
    //    [Required(ErrorMessage = "Yêu cầu nhập đánh giá !")]
    //    [StringLength(1000, ErrorMessage = "Chỉ được nhập tối đa 1000 ký tự !")]
    //    public string YourReview { get; set; }

    //    [Display(Name = "Đánh giá")]
    //    public int Rated { get; set; } //1-> 5

    //    [Display(Name = "Hiện / Ẩn")]
    //    public bool IsEnable { get; set; }

    //    public bool IsRead { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    public virtual CW_Product CW_Product { get; set; }
    //}

    //#endregion

    //#region "setting payment methods"

    //// bảng cấu hình chung thanh toán
    //[Table("CW_SettingCommonPayment")]
    //public class CW_SettingCommonPayment
    //{
    //    public CW_SettingCommonPayment()
    //    {
    //        this.CW_SettingCommonPayment_PaymentMethods = new HashSet<CW_SettingCommonPayment_PaymentMethods>();
    //    }

    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int SettingCommonPaymentID { get; set; }

    //    [Display(Name = "Nội dung thông báo đặt hàng thành công")]
    //    [StringLength(1000, ErrorMessage = "Chỉ được nhập tối đa 1000 ký tự !")]
    //    [AllowHtml]
    //    public string OrderCompletedNotifications { get; set; }

    //    [Display(Name = "Ưu tiên giao hàng đến địa chỉ khác")]
    //    [StringLength(10, ErrorMessage = "Chỉ được nhập tối đa 10 ký tự !")]
    //    public string AnotherShippingAddressAllow { get; set; } // yes or no

    //    [Display(Name = "Sử dụng quy trình thanh toán rút gọn")]
    //    [StringLength(10, ErrorMessage = "Chỉ được nhập tối đa 10 ký tự !")]
    //    public string QuickPayment { get; set; } // yes or no

    //    public DateTime CreatedDate { get; set; }

    //    public virtual ICollection<CW_SettingCommonPayment_PaymentMethods> CW_SettingCommonPayment_PaymentMethods { get; set; }
    //}

    ////bảng nối bảng cấu hình thanh toán và bảng phương thức thanh toán
    //[Table("CW_SettingCommonPayment_PaymentMethods")]
    //public class CW_SettingCommonPayment_PaymentMethods
    //{

    //    [Key, Column(Order = 0)]
    //    public int SettingCommonPaymentID { get; set; }

    //    [Key, Column(Order = 1)]
    //    public int PaymentMethodsID { get; set; }

    //    public virtual CW_SettingCommonPayment CW_SettingCommonPayment { get; set; }

    //    public virtual CW_PaymentMethods CW_PaymentMethods { get; set; }

    //}

    //// bảng chứa các phương thức thanh toán
    //[Table("CW_PaymentMethods")]
    //public class CW_PaymentMethods
    //{
    //    public CW_PaymentMethods()
    //    {
    //        this.CW_SettingCommonPayment_PaymentMethods = new HashSet<CW_SettingCommonPayment_PaymentMethods>();
    //    }

    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int PaymentMethodsID { get; set; }

    //    [Display(Name = "Tên phương thức thanh toán")]
    //    [StringLength(100, ErrorMessage = "Chỉ được nhập tối đa 100 ký tự !")]
    //    public string PaymentMethodsName { get; set; }

    //    public virtual ICollection<CW_SettingCommonPayment_PaymentMethods> CW_SettingCommonPayment_PaymentMethods { get; set; }
    //}

    //// bảng chứa cấu hình thanh toán không có cấu hình phức tạp
    ////3. Thanh toán tại cửa hàng
    ////4. Thanh toán khi nhận được hàng
    ////9. Hình thức thanh toán riêng
    ////8. Thanh toán qua tài khoản ngân hàng
    //[Table("CW_PaymentAtShop")]
    //public class CW_PaymentAtShop
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int PaymentAtShopID { get; set; }

    //    [Display(Name = "Tên hiển thị ")]
    //    [StringLength(200, ErrorMessage = "Chỉ được nhập tối đa 200 ký tự !")]
    //    [Required(ErrorMessage = "Yêu cầu nhập tên hiển thị !")]
    //    public string DisplayName { get; set; }

    //    [Display(Name = "Chỉ dẫn thanh toán ")]
    //    [StringLength(500, ErrorMessage = "Bạn chỉ được nhập tối đa 500 ký tự !")]
    //    [AllowHtml]
    //    public string Instruction { get; set; }

    //    [Display(Name = "Loại thanh toán ")]
    //    public int TypePayment { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //}

    //// Tích hợp bảo kim merchant
    //[Table("CW_PaymentBaoKimMerchant")]
    //public class CW_PaymentBaoKimMerchant
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int PaymentBaoKimMerchantID { get; set; }

    //    [Display(Name = "Tên hiển thị ")]
    //    [StringLength(200, ErrorMessage = "Chỉ được nhập tối đa 200 ký tự !")]
    //    [Required(ErrorMessage = "Yêu cầu nhập tên hiển thị !")]
    //    public string DisplayName { get; set; }

    //    [Display(Name = "Email nhận thanh toán ")]
    //    [StringLength(200, ErrorMessage = "Chỉ được nhập tối đa 200 ký tự !")]
    //    [Required(ErrorMessage = "Yêu cầu nhập email thanh toán !")]
    //    [DataType(DataType.EmailAddress)]
    //    [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email không đúng định dạng!")]
    //    public string Email { get; set; }

    //    [Display(Name = "Mã website tích hợp ")]
    //    [StringLength(200, ErrorMessage = "Chỉ được nhập tối đa 200 ký tự !")]
    //    [Required(ErrorMessage = "Yêu cầu nhập trường này !")]
    //    public string MerchantId { get; set; }

    //    [Display(Name = "Mã bảo mật ")]
    //    [StringLength(100, ErrorMessage = "Chỉ được nhập tối đa 100 ký tự !")]
    //    [Required(ErrorMessage = "Yêu cầu nhập trường này !")]
    //    public string SecurePass { get; set; }

    //    [Display(Name = "Chế độ ")]
    //    public int TestMode { get; set; } //1. chạy thật  2. chạy thử

    //    [Display(Name = "Chỉ dẫn thanh toán ")]
    //    [StringLength(500, ErrorMessage = "Bạn chỉ được nhập tối đa 500 ký tự !")]
    //    [AllowHtml]
    //    public string Instruction { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //}

    //// Tích hợp Ngân Lượng nâng cao
    //[Table("CW_PaymentNganLuongMerchant")]
    //public class CW_PaymentNganLuongMerchant
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int PaymentNganLuongMerchantID { get; set; }

    //    [Display(Name = "Tên hiển thị ")]
    //    [StringLength(200, ErrorMessage = "Chỉ được nhập tối đa 200 ký tự !")]
    //    [Required(ErrorMessage = "Yêu cầu nhập tên hiển thị !")]
    //    public string DisplayName { get; set; }

    //    [Display(Name = "Email nhận thanh toán ")]
    //    [StringLength(200, ErrorMessage = "Chỉ được nhập tối đa 200 ký tự !")]
    //    [Required(ErrorMessage = "Yêu cầu nhập email thanh toán !")]
    //    [DataType(DataType.EmailAddress)]
    //    [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email không đúng định dạng!")]
    //    public string Email { get; set; }

    //    [Display(Name = "Mã website tích hợp ")]
    //    [StringLength(200, ErrorMessage = "Chỉ được nhập tối đa 200 ký tự !")]
    //    [Required(ErrorMessage = "Yêu cầu nhập trường này !")]
    //    public string MerchantId { get; set; }

    //    [Display(Name = "Mã bảo mật ")]
    //    [StringLength(100, ErrorMessage = "Chỉ được nhập tối đa 100 ký tự !")]
    //    [Required(ErrorMessage = "Yêu cầu nhập trường này !")]
    //    public string SecurePass { get; set; }

    //    [Display(Name = "Chế độ ")]
    //    public int TestMode { get; set; } //1. chạy thật  2. chạy thử

    //    [Display(Name = "Chỉ dẫn thanh toán ")]
    //    [StringLength(500, ErrorMessage = "Bạn chỉ được nhập tối đa 500 ký tự !")]
    //    [AllowHtml]
    //    public string Instruction { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //}

    //// Thanh toán qua paypal
    //[Table("CW_PaymentPayPal")]
    //public class CW_PaymentPayPal
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int PaymentPayPalID { get; set; }

    //    [Display(Name = "Tên hiển thị ")]
    //    [StringLength(200, ErrorMessage = "Chỉ được nhập tối đa 200 ký tự !")]
    //    [Required(ErrorMessage = "Yêu cầu nhập tên hiển thị !")]
    //    public string DisplayName { get; set; }

    //    [Display(Name = "Tài khoản nhận thanh toán ")]
    //    [StringLength(200, ErrorMessage = "Chỉ được nhập tối đa 200 ký tự !")]
    //    [Required(ErrorMessage = "Yêu cầu nhập tài khoản thanh toán !")]
    //    //[DataType(DataType.EmailAddress)]
    //    //[RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email không đúng định dạng!")]
    //    public string Email { get; set; }

    //    [Display(Name = "Mã bảo mật ")]
    //    [StringLength(100, ErrorMessage = "Chỉ được nhập tối đa 100 ký tự !")]
    //    [Required(ErrorMessage = "Yêu cầu nhập trường này !")]
    //    public string SecurePass { get; set; }

    //    [Display(Name = "Chuỗi chữ ký ")]
    //    [StringLength(100, ErrorMessage = "Chỉ được nhập tối đa 100 ký tự !")]
    //    [Required(ErrorMessage = "Yêu cầu nhập trường này !")]
    //    public string Signature { get; set; }

    //    [Display(Name = "Chế độ ")]
    //    public int TestMode { get; set; } //1. chạy thật  2. chạy thử

    //    [Display(Name = "Chỉ dẫn thanh toán ")]
    //    [StringLength(500, ErrorMessage = "Bạn chỉ được nhập tối đa 500 ký tự !")]
    //    [AllowHtml]
    //    public string Instruction { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //}

    //// Tích hợp thanh toán OnePay
    //[Table("CW_PaymentOnePay")]
    //public class CW_PaymentOnePay
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int OnePayID { get; set; }

    //    [Display(Name = "Tên hiển thị ")]
    //    [StringLength(200, ErrorMessage = "Chỉ được nhập tối đa 200 ký tự !")]
    //    [Required(ErrorMessage = "Yêu cầu nhập tên hiển thị !")]
    //    public string DisplayName { get; set; }

    //    [Display(Name = "Hashcode (SECURE_SECRET)")]
    //    [StringLength(100, ErrorMessage = "Chỉ được nhập tối đa 100 ký tự !")]
    //    [Required(ErrorMessage = "Yêu cầu nhập mã  Hashcode!")]
    //    public string Hashcode { get; set; }

    //    [Display(Name = "AccessCode")]
    //    [StringLength(100, ErrorMessage = "Chỉ được nhập tối đa 100 ký tự !")]
    //    [Required(ErrorMessage = "Yêu cầu nhập trường này !")]
    //    public string AccessCode { get; set; }

    //    [Display(Name = "Tài khoản Merchant ")]
    //    [StringLength(200, ErrorMessage = "Chỉ được nhập tối đa 200 ký tự !")]
    //    [Required(ErrorMessage = "Yêu cầu nhập trường này !")]
    //    public string MerchantId { get; set; }

    //    [Display(Name = "Chế độ ")]
    //    public int TestMode { get; set; } //1. chạy thật  2. chạy thử

    //    [Display(Name = "Chỉ dẫn thanh toán ")]
    //    [StringLength(500, ErrorMessage = "Bạn chỉ được nhập tối đa 500 ký tự !")]
    //    [AllowHtml]
    //    public string Instruction { get; set; }

    //    [Display(Name = "Loại thanh toán")]
    //    public int TypePayment { get; set; } // 1. Thanh toán qua thẻ  ATM  2. Thanh toán qua thẻ visa, Master,...

    //    public DateTime CreatedDate { get; set; }

    //}

    //#endregion

    //#region "common model"

    //[Table("CW_Category")]
    //public class CW_Category
    //{
    //    public CW_Category()
    //    {
    //        this.CW_menu_category = new HashSet<CW_Menu_Category>();
    //        this.CW_articles = new HashSet<CW_Article>();
    //        this.CW_news = new HashSet<CW_News>();
    //        //this.Contents = new HashSet<Content>();
    //        this.CW_products = new HashSet<CW_Product>();
    //        this.CW_files = new HashSet<CW_File>();
    //        this.CW_videoclip = new HashSet<CW_VideoClip>();
    //        this.CW_album = new HashSet<CW_Album>();
    //        this.CW_Category_UpdatePrice = new HashSet<CW_Category_UpdatePrice>();
    //    }

    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int ID { get; set; }

    //    [Display(Name = "Tiêu đề")]
    //    [Required(ErrorMessage = "Yêu cầu nhập tiêu đề !")]
    //    [StringLength(300, ErrorMessage = "Chỉ được nhập tối đa 300 ký tự !")]
    //    public string Title
    //    {
    //        get;
    //        set;
    //    }

    //    [Display(Name = "Kiểu danh mục")]
    //    [Required(ErrorMessage = "Yêu cầu nhập kiểu danh mục !")]
    //    [StringLength(100, ErrorMessage = "Chỉ được nhập tối đa 100 ký tự !")]
    //    public string TypeCode
    //    {
    //        get;
    //        set;
    //    }

    //    [Display(Name = "Mã danh mục")]
    //    [Required(ErrorMessage = "Yêu cầu nhập trường này !")]
    //    [StringLength(400, ErrorMessage = "Chỉ được nhập tối đa 400 ký tự !")]
    //    public string CategoryCode { get; set; }

    //    [Display(Name = "Mô tả")]
    //    [StringLength(1000, ErrorMessage = "Số ký tự cho phép tối đa là 1000!")]
    //    public string Description { get; set; }

    //    [Display(Name = "Danh mục cha")]
    //    public int? ParentID { get; set; }

    //    [Display(Name = "Thứ tự")]
    //    [Range(0, int.MaxValue, ErrorMessage = "Thứ tự nhập vào phải là số dương")]
    //    public int? Order { get; set; }

    //    [Display(Name = "MetaTitle")]
    //    [StringLength(400, ErrorMessage = "Chỉ được nhập tối đa 400 ký tự !")]
    //    public string MetaTitle { get; set; }

    //    [StringLength(200, ErrorMessage = "Bạn chỉ có thể nhập tối đa 200 ký tự !")]
    //    public string MetaKeywords { get; set; }

    //    [Display(Name = "MetaDescription")]
    //    [StringLength(700, ErrorMessage = "Chỉ được nhập tối đa 700 ký tự !")]
    //    public string MetaDescription { get; set; }

    //    [Display(Name = "Liên kết")]
    //    [StringLength(200, ErrorMessage = "Chỉ được nhập tối đa 200 ký tự !")]
    //    public string Link { get; set; }

    //    [Display(Name = "Ảnh đại diện")]
    //    [StringLength(200, ErrorMessage = "Chỉ được nhập tối đa 200 ký tự !")]
    //    public string Icon { get; set; }

    //    [Display(Name = "Kiểu liên kết")]
    //    [StringLength(50, ErrorMessage = "Chỉ được nhập tối đa 50 ký tự !")]
    //    public string Target { get; set; }

    //    [Display(Name = "Kích hoạt")]
    //    public bool IsActive { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    [Display(Name = "Ngôn ngữ")]
    //    [StringLength(10, ErrorMessage = "Chỉ được nhập tối đa 10 ký tự !")]
    //    public string LanguageCode { get; set; }

    //    [ForeignKey("ParentID")]
    //    public virtual ICollection<CW_Category> SubCategories { get; set; }

    //    [StringLength(300, ErrorMessage = "Chỉ được nhập tối đa 300 ký tự !")]
    //    public string KeySearch { get; set; }

    //    public virtual ICollection<CW_Article> CW_articles { get; set; }
    //    public virtual ICollection<CW_News> CW_news { get; set; }
    //    //public virtual ICollection<Content> Contents { get; set; }
    //    public virtual ICollection<CW_Product> CW_products { get; set; }
    //    public virtual ICollection<CW_File> CW_files { get; set; }
    //    public virtual ICollection<CW_VideoClip> CW_videoclip { get; set; }
    //    public virtual ICollection<CW_Album> CW_album { get; set; }
    //    public virtual ICollection<CW_Menu_Category> CW_menu_category { get; set; }
    //    public virtual ICollection<CW_Category_UpdatePrice> CW_Category_UpdatePrice { get; set; }
    //    public virtual CW_Language CW_Language { get; set; }
    //}

    //[Table("CW_News")]
    //public class CW_News
    //{
    //    public CW_News()
    //    {
    //        this.CW_newscomment = new HashSet<CW_NewsComment>();
    //    }

    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int ID { get; set; }

    //    [Display(Name = "Tiêu đề")]
    //    [Required(ErrorMessage = "Yêu cầu nhập tiêu đề !")]
    //    [StringLength(400, ErrorMessage = "Chỉ được nhập tối đa 400 ký tự !")]
    //    public string Title
    //    {
    //        get;
    //        set;
    //    }

    //    [Display(Name = "Filter title")]
    //    [Required(ErrorMessage = "Yêu cầu nhập trường này !")]
    //    public string FilterTitle
    //    {
    //        get;
    //        set;
    //    }

    //    [Display(Name = "Ảnh đại diện")]
    //    [StringLength(200, ErrorMessage = "Chỉ được nhập tối đa 200 ký tự !")]
    //    public string Image { get; set; }

    //    [Display(Name = "Mô tả")]
    //    [StringLength(1000)]
    //    public string Description { get; set; }

    //    [Display(Name = "Chi tiết tin")]
    //    [AllowHtml]
    //    public string Content { get; set; }

    //    [Display(Name = "Chú thích ảnh")]
    //    [StringLength(200, ErrorMessage = "Chỉ được nhập tối đa 200 ký tự !")]
    //    public string ImageNotes { get; set; }

    //    [Display(Name = "Số lượng người đọc")]
    //    public int Read { get; set; }

    //    [Display(Name = "Kích hoạt")]
    //    public bool IsActive { get; set; }

    //    [Display(Name = "Trang chủ")]
    //    public bool IsHome { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    [Display(Name = "Thứ tự")]
    //    [Range(0, int.MaxValue, ErrorMessage = "Chỉ được nhập số dương!")]
    //    [RegularExpression(@"[0-9]*$", ErrorMessage = "Bạn phải nhập kiểu số (1->9) ")]
    //    public int Order { get; set; }

    //    [Display(Name = "Danh mục")]
    //    [Required(ErrorMessage = "Cần phải chọn danh mục !")]
    //    public int CategoryID { get; set; }

    //    [Display(Name = "Ngôn ngữ")]
    //    [StringLength(10, ErrorMessage = "Chỉ được nhập tối đa 10 ký tự !")]
    //    public string LanguageCode { get; set; }

    //    [StringLength(400, ErrorMessage = "Chỉ được nhập tối đa 400 ký tự !")]
    //    public string MetaTitle { get; set; }

    //    [StringLength(200, ErrorMessage = "Bạn chỉ có thể nhập tối đa 200 ký tự !")]
    //    public string MetaKeywords { get; set; }

    //    [StringLength(600, ErrorMessage = "Chỉ được nhập tối đa 600 ký tự !")]
    //    public string MetaDescription { get; set; }

    //    public virtual CW_Category Category { get; set; }
    //    public virtual ICollection<CW_NewsComment> CW_newscomment { get; set; }
    //    public virtual CW_Language CW_Language { get; set; }
    //}

    //[Table("CW_NewsComment")]
    //public class CW_NewsComment
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int CommentID { get; set; }

    //    [Display(Name = "Tin tức")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập trường này !")]
    //    public int ID { get; set; }

    //    [Display(Name = "Bình luận")]
    //    [AllowHtml]
    //    public string Content { get; set; }

    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [Display(Name = "Họ tên")]
    //    [StringLength(70, ErrorMessage = "Bạn chỉ được nhập tối đa 70 ký tự !")]
    //    public string FullName { get; set; }

    //    [DataType(DataType.EmailAddress)]
    //    [Required(ErrorMessage = "Email không được để trống !")]
    //    [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email không đúng định dạng!")]
    //    [Display(Name = "Email")]
    //    [StringLength(100, ErrorMessage = "Bạn chỉ được nhập tối đa 100 ký tự !")]
    //    public string Email { get; set; }

    //    [Display(Name = "Kích hoạt hiển thị")]
    //    public bool IsActive { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    public virtual CW_News CW_News { get; set; }
    //}

    //[Table("CW_Article")]
    //public class CW_Article
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int ID { get; set; }

    //    [Display(Name = "Tiêu đề")]
    //    [Required(ErrorMessage = "Yêu cầu nhập tiêu đề !")]
    //    [StringLength(300, ErrorMessage = "Bạn chỉ được nhập tối đa 300 ký tự !")]
    //    public string Title
    //    {
    //        get;
    //        set;
    //    }

    //    [Display(Name = "Filter title")]
    //    [Required(ErrorMessage = "Yêu cầu nhập trường này !")]
    //    public string FilterTitle
    //    {
    //        get;
    //        set;
    //    }

    //    [Display(Name = "Mô tả")]
    //    [StringLength(1000, ErrorMessage = "Bạn chỉ được nhập tối đa 1000 ký tự")]
    //    public string Description { get; set; }

    //    [Display(Name = "Chi tiết bài viết")]
    //    [AllowHtml]
    //    public string Body { get; set; }

    //    [Display(Name = "Danh mục")]
    //    [Required(ErrorMessage = "Bắt buộc phải chọn danh mục")]
    //    public int CategoryID { get; set; }

    //    [Display(Name = "Thứ tự")]
    //    [Range(0, int.MaxValue, ErrorMessage = "Chỉ được nhập số dương !")]
    //    [RegularExpression(@"[0-9]*$", ErrorMessage = "Bạn phải nhập kiểu số (1->9) ")]
    //    public int Order { get; set; }

    //    [Display(Name = "Ngôn ngữ")]
    //    [StringLength(10, ErrorMessage = "Bạn chỉ được nhập tối đa 10 ký tự !")]
    //    public string LanguageCode { get; set; }

    //    [Display(Name = "Kích hoạt")]
    //    public bool IsActive { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    [StringLength(400, ErrorMessage = "Bạn chỉ được nhập tối đa 400 ký tự !")]
    //    public string MetaTitle { get; set; }

    //    [StringLength(200, ErrorMessage = "Bạn chỉ có thể nhập tối đa 200 ký tự !")]
    //    public string MetaKeywords { get; set; }

    //    [StringLength(500, ErrorMessage = "Bạn chỉ được nhập tối đa 500 ký tự !")]
    //    public string MetaDescription { get; set; }

    //    public virtual CW_Category Category { get; set; }
    //    public virtual CW_Language CW_Language { get; set; }
    //}

    //[Table("CW_Adv")]
    //public class CW_Adv
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int ID { get; set; }

    //    [Display(Name = "Tiêu đề")]
    //    [Required(ErrorMessage = "Yêu cầu nhập tiêu đề !")]
    //    [StringLength(400, ErrorMessage = "Bạn chỉ được nhập tối đa 400 ký tự !")]
    //    public string Title
    //    {
    //        get;
    //        set;
    //    }

    //    [Display(Name = "Ảnh")]
    //    [Required(ErrorMessage = "Yêu cầu tải ảnh !")]
    //    [StringLength(200, ErrorMessage = "Bạn chỉ được nhập tối đa 200 ký tự !")]
    //    public string Image { get; set; }

    //    [Display(Name = "Liên kết")]
    //    [StringLength(200, ErrorMessage = "Bạn chỉ được nhập tối đa 200 ký tự !")]
    //    public string Link { get; set; }

    //    [Display(Name = "Mô tả")]
    //    [StringLength(500, ErrorMessage = "Bạn chỉ được nhập tối đa 500 ký tự !")]
    //    [AllowHtml]
    //    public string Description { get; set; }

    //    [Display(Name = "Chiểu cao")]
    //    [Range(0, int.MaxValue, ErrorMessage = "Chỉ được nhập số dương !")]
    //    [RegularExpression(@"[0-9]*$", ErrorMessage = "Bạn phải nhập kiểu số (1->9) ")]
    //    public int Height { get; set; }

    //    [Display(Name = "Chiều rộng")]
    //    [Range(0, int.MaxValue, ErrorMessage = "Chỉ được nhập số dương !")]
    //    [RegularExpression(@"[0-9]*$", ErrorMessage = "Bạn phải nhập kiểu số (1->9) ")]
    //    public int Width { get; set; }

    //    [Display(Name = "Vị trí hiển thị")]
    //    [Required(ErrorMessage = "Cần phải chọn vị trí hiển thị !")]
    //    public int Position { get; set; }

    //    [Display(Name = "Kiểu liên kết")]
    //    [StringLength(30, ErrorMessage = "Bạn chỉ được nhập tối đa 30 ký tự !")]
    //    public string Target { get; set; }

    //    [Display(Name = "Kiểu flash")]
    //    public bool IsFlash { get; set; }

    //    [Display(Name = "Kích hoạt")]
    //    public bool IsActive { get; set; }

    //    [Display(Name = "Thứ tự")]
    //    [Range(0, int.MaxValue)]
    //    [RegularExpression(@"[0-9]*$", ErrorMessage = "Bạn phải nhập kiểu số (1->9) ")]
    //    public int Order { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    [StringLength(400, ErrorMessage = "Bạn chỉ được nhập tối đa 500 ký tự !")]
    //    public string MetaTitle { get; set; }

    //    [StringLength(500, ErrorMessage = "Bạn chỉ được nhập tối đa 500 ký tự !")]
    //    public string MetaDescription { get; set; }

    //    [Display(Name = "Ngôn ngữ")]
    //    [StringLength(10, ErrorMessage = "Bạn chỉ được nhập tối đa 10 ký tự !")]
    //    public string LanguageCode { get; set; }

    //    public virtual CW_Language CW_Language { get; set; }

    //}

    //[Table("CW_Contact")]
    //public class CW_Contact
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int ID { get; set; }

    //    [Required(ErrorMessage = "Yêu cầu nhập họ tên !")]
    //    [Display(Name = "Họ tên")]
    //    [StringLength(100, ErrorMessage = "Bạn chỉ được nhập tối đa 100 ký tự !")]
    //    public string FullName { get; set; }

    //    [Display(Name = "Tên công ty")]
    //    [StringLength(150, ErrorMessage = "Bạn chỉ được nhập tối đa 150 ký tự !")]
    //    public string Company { get; set; }

    //    [Display(Name = "Điện thoại")]
    //    [StringLength(12, ErrorMessage = "Bạn chỉ được nhập tối đa 12 ký tự !")]
    //    [DataType(DataType.PhoneNumber)]
    //    public string Phone { get; set; }

    //    [DataType(DataType.EmailAddress)]
    //    [Required(ErrorMessage = "Email không được để trống !")]
    //    [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email không đúng định dạng!")]
    //    [Display(Name = "Email")]
    //    [StringLength(100, ErrorMessage = "Bạn chỉ được nhập tối đa 100 ký tự !")]
    //    public string Email { get; set; }

    //    [Required(ErrorMessage = "Yêu cầu nhập tiêu đề!")]
    //    [Display(Name = "Tiêu đề")]
    //    [StringLength(200, ErrorMessage = "Bạn chỉ được nhập tối đa 200 ký tự !")]
    //    public string Title { get; set; }

    //    [Display(Name = "Nội dung")]
    //    [AllowHtml]
    //    [StringLength(1500, ErrorMessage = "Bạn chỉ được nhập tối đa 1500 ký tự !")]
    //    public string Content { get; set; }

    //    public bool IsRead { get; set; }

    //    public DateTime CreatedDate { get; set; }
    //}

    //[Table("CW_Menu")]
    //public class CW_Menu
    //{
    //    public CW_Menu()
    //    {
    //        this.CW_menu_category = new HashSet<CW_Menu_Category>();
    //    }
    //    [Key]
    //    public string MenuCode { get; set; }

    //    [Required]
    //    [StringLength(100, ErrorMessage = "Bạn chỉ được nhập tối đa 100 ký tự !")]
    //    public string Title
    //    {
    //        get;
    //        set;
    //    }

    //    [Range(0, int.MaxValue)]
    //    [RegularExpression(@"[0-9]*$", ErrorMessage = "Bạn phải nhập kiểu số (1->9) ")]
    //    public int Order { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    public virtual ICollection<CW_Menu_Category> CW_menu_category { get; set; }
    //}

    //[Table("CW_Support")]
    //public class CW_Support
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int ID { get; set; }

    //    [Display(Name = "Nick yahoo")]
    //    [StringLength(100, ErrorMessage = "Bạn chỉ được nhập tối đa 100 ký tự !")]
    //    public string NickYahoo
    //    {
    //        get;
    //        set;
    //    }

    //    [Display(Name = "Nick skyper")]
    //    [StringLength(100, ErrorMessage = "Bạn chỉ được nhập tối đa 100 ký tự !")]
    //    public string NickSkyper { get; set; }

    //    [Display(Name = "Tiêu đề")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [StringLength(100, ErrorMessage = "Bạn chỉ được nhập tối đa 100 ký tự !")]
    //    public string Title { get; set; }

    //    [Display(Name = "Điện thoại")]
    //    [StringLength(12, ErrorMessage = "Bạn chỉ được nhập tối đa 12 ký tự !")]
    //    [DataType(DataType.PhoneNumber)]
    //    public string Phone { get; set; }

    //    [Display(Name = "Mô tả")]
    //    [StringLength(200, ErrorMessage = "Bạn chỉ được nhập tối đa 200 ký tự !")]
    //    public string Description { get; set; }

    //    [Display(Name = "Thứ tự")]
    //    [Range(0, int.MaxValue, ErrorMessage = "Chỉ được nhập số dương !")]
    //    [RegularExpression(@"[0-9]*$", ErrorMessage = "Bạn phải nhập kiểu số (1->9) ")]
    //    public int Order { get; set; }

    //    [Display(Name = "Kích hoạt")]
    //    public bool IsActive { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    [Display(Name = "Ngôn ngữ")]
    //    [StringLength(10, ErrorMessage = "Bạn chỉ được nhập tối đa 10 ký tự !")]
    //    public string LanguageCode { get; set; }

    //    public virtual CW_Language CW_Language { get; set; }
    //}

    //[Table("CW_Setting")]
    //public class CW_Setting
    //{
    //    [Key]
    //    public string SettingKey { get; set; }

    //    [AllowHtml]
    //    public string SettingValue { get; set; }

    //    [StringLength(100, ErrorMessage = "Bạn chỉ được nhập tối đa 100 ký tự !")]
    //    public string SettingGroup { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    [StringLength(200, ErrorMessage = "Bạn chỉ được nhập tối đa 200 ký tự !")]
    //    public string SettingComment { get; set; }

    //    [Display(Name = "Ngôn ngữ")]
    //    [StringLength(10, ErrorMessage = "Bạn chỉ được nhập tối đa 10 ký tự !")]
    //    public string LanguageCode { get; set; }

    //    public virtual CW_Language CW_Language { get; set; }
    //}

    //[Table("CW_Menu_Category")]
    //public class CW_Menu_Category
    //{
    //    //đây là bảng nhiều, mình cần viết kết nối đến bảng 1 như: public virtual Category Category { get; set; }
    //    [Key, Column(Order = 0)]
    //    public string MenuCode { get; set; }

    //    [Key, Column(Order = 1)]
    //    public int CategoryID { get; set; }

    //    //[RegularExpression(@"[0-9]*$", ErrorMessage = "Bạn phải nhập kiểu số (1->9) ")]
    //    public int SortOrder { get; set; }

    //    public virtual CW_Category Category { get; set; }

    //    public virtual CW_Menu CW_Menu { get; set; }

    //}

    //[Table("CW_File")]
    //public class CW_File
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int ID { get; set; }

    //    [Display(Name = "Danh  mục")]
    //    [Required(ErrorMessage = "Bạn bắt buộc phải chọn danh mục!")]
    //    public int CategoryID { get; set; }

    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [Display(Name = "Tiêu đề")]
    //    [StringLength(300, ErrorMessage = "Bạn chỉ có thể nhập tối đa 300 ký tự !")]
    //    public string Title { get; set; }

    //    [Display(Name = "Filter title")]
    //    [Required(ErrorMessage = "Yêu cầu nhập trường này !")]
    //    public string FilterTitle
    //    {
    //        get;
    //        set;
    //    }

    //    [Display(Name = "Link file")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [StringLength(300, ErrorMessage = "Bạn chỉ có thể nhập tối đa 300 ký tự !")]
    //    public string PathFile { get; set; }

    //    [Display(Name = "Ảnh đại diện")]
    //    [StringLength(300, ErrorMessage = "Bạn chỉ có thể nhập tối đa 300 ký tự !")]
    //    public string Images { get; set; }

    //    [Display(Name = "Mô tả")]
    //    [StringLength(1000, ErrorMessage = "Bạn chỉ có thể nhập tối đa 1000 ký tự !")]
    //    public string Description { get; set; }

    //    [Display(Name = "Chi tiết")]
    //    [AllowHtml]
    //    public string Content { get; set; }

    //    [Display(Name = "Số lượt download")]
    //    public int CountDownload { get; set; }

    //    [Display(Name = "Kích hoạt")]
    //    public bool IsActive { get; set; }

    //    [Range(0, int.MaxValue, ErrorMessage = "Chỉ được nhập số dương !")]
    //    [Display(Name = "Thứ tự")]
    //    [RegularExpression(@"[0-9]*$", ErrorMessage = "Bạn phải nhập kiểu số (1->9) ")]
    //    public int SortOrder { get; set; }

    //    [Display(Name = "Ngôn ngữ")]
    //    [StringLength(10, ErrorMessage = "Bạn chỉ có thể nhập tối đa 10 ký tự !")]
    //    public string LanguageCode { get; set; }

    //    public virtual CW_Language CW_Language { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    public virtual CW_Category Category { get; set; }
    //}

    //[Table("CW_VideoClip")]
    //public class CW_VideoClip
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int ItemID { get; set; }

    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [Display(Name = "Tiêu đề")]
    //    [StringLength(300, ErrorMessage = "Bạn chỉ có thể nhập tối đa 300 ký tự !")]
    //    public string ClipName { get; set; }

    //    [Display(Name = "Filter title")]
    //    [Required(ErrorMessage = "Yêu cầu nhập trường này !")]
    //    public string FilterTitle
    //    {
    //        get;
    //        set;
    //    }

    //    [Display(Name = "Danh  mục")]
    //    [Required(ErrorMessage = "Bạn bắt buộc phải nhập trường này !")]
    //    public int CategoryID { get; set; }

    //    [Display(Name = "Link video")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [StringLength(300, ErrorMessage = "Bạn chỉ có thể nhập tối đa 300 ký tự !")]
    //    [AllowHtml]
    //    public string ClipLink { get; set; }

    //    [Display(Name = "Kích hoạt")]
    //    public bool IsActive { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    [Range(0, int.MaxValue)]
    //    [Display(Name = "Thứ tự")]
    //    [RegularExpression(@"[0-9]*$", ErrorMessage = "Bạn phải nhập kiểu số (1->9) ")]
    //    public int SortOrder { get; set; }

    //    [Display(Name = "Nguồn video")]
    //    public string ClipSource { get; set; }

    //    [Display(Name = "Ảnh đại diện")]
    //    //[RegularExpression(@"\w+\.(gif|jpg|png)$")]
    //    public string ClipImage { get; set; }

    //    [Display(Name = "Mô tả")]
    //    [AllowHtml]
    //    public string Description { get; set; }

    //    [Display(Name = "Số lượt xem")]
    //    public int ViewCount { get; set; }

    //    [Display(Name = "Loại video")]
    //    public string Extentsion { get; set; }

    //    [Display(Name = "Kiểu video")]
    //    public string TypeVideo { get; set; }

    //    [Display(Name = "Dung lượng")]
    //    [StringLength(10, ErrorMessage = "Bạn chỉ có thể nhập tối đa 10 ký tự !")]
    //    public string VideoSize { get; set; }

    //    public virtual CW_Category Category { get; set; }

    //    [Display(Name = "Ngôn ngữ")]
    //    [StringLength(10, ErrorMessage = "Bạn chỉ có thể nhập tối đa 10 ký tự !")]
    //    public string LanguageCode { get; set; }

    //    public virtual CW_Language CW_Language { get; set; }
    //}

    //[Table("CW_Album")]
    //public class CW_Album
    //{
    //    public CW_Album()
    //    {
    //        this.CW_AlbumImages = new HashSet<CW_AlbumImages>();
    //    }
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int AlbumID { get; set; }

    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [Display(Name = "Tiêu đề")]
    //    [StringLength(300, ErrorMessage = "Bạn chỉ có thể nhập tối đa 300 ký tự !")]
    //    public string AlbumName { get; set; }

    //    [Display(Name = "Filter title")]
    //    [Required(ErrorMessage = "Yêu cầu nhập trường này !")]
    //    public string FilterTitle
    //    {
    //        get;
    //        set;
    //    }

    //    [Display(Name = "Danh  mục")]
    //    [Required(ErrorMessage = "Bắt buộc phải chọn danh mục !")]
    //    public int CategoryID { get; set; }

    //    [Range(0, int.MaxValue, ErrorMessage = "Chỉ được nhập số dương !")]
    //    [Display(Name = "Thứ tự")]
    //    [RegularExpression(@"[0-9]*$", ErrorMessage = "Bạn phải nhập kiểu số (1->9) ")]
    //    public int SortOrder { get; set; }

    //    [Display(Name = "Kích hoạt")]
    //    public bool IsActive { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    [Display(Name = "Chi tiết thư viện ảnh")]
    //    [AllowHtml]
    //    [StringLength(300, ErrorMessage = "Bạn chỉ có thể nhập tối đa 300 ký tự !")]
    //    public string Description { get; set; }

    //    [Display(Name = "Ngôn ngữ")]
    //    [StringLength(10, ErrorMessage = "Bạn chỉ có thể nhập tối đa 10 ký tự !")]
    //    public string LanguageCode { get; set; }

    //    public virtual CW_Language CW_Language { get; set; }

    //    public virtual CW_Category Category { get; set; }

    //    public virtual ICollection<CW_AlbumImages> CW_AlbumImages { get; set; }
    //}

    //[Table("CW_AlbumImages")]
    //public class CW_AlbumImages
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int ID { get; set; }

    //    [Required(ErrorMessage = "Bắt buộc phải chọn!")]
    //    [Display(Name = "Album")]
    //    public int AlbumID { get; set; }

    //    [StringLength(200, ErrorMessage = "Bạn chỉ có thể nhập tối đa 200 ký tự !")]
    //    public string Image { get; set; } // anh nho

    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [StringLength(200, ErrorMessage = "Bạn chỉ có thể nhập tối đa 200 ký tự !")]
    //    [Display(Name = "Ảnh album")]
    //    public string Images { get; set; }// anh lon

    //    [Display(Name = "Chọn ảnh hiện thị mặc định")]
    //    public bool IsDefault { get; set; }// chon anh hien thi mac dinh

    //    public DateTime CreatedDate { get; set; }

    //    public virtual CW_Album CW_Album { get; set; }
    //}

    //[Table("CW_Language")]
    //public class CW_Language
    //{
    //    [Key]
    //    public string LanguageCode { get; set; }

    //    public string Title { get; set; }

    //    public virtual ICollection<CW_Category> Category { get; set; }
    //    public virtual ICollection<CW_Adv> CW_Adv { get; set; }
    //    public virtual ICollection<CW_Album> CW_Album { get; set; }
    //    public virtual ICollection<CW_Article> CW_Article { get; set; }
    //    public virtual ICollection<CW_File> CW_File { get; set; }
    //    public virtual ICollection<CW_News> CW_News { get; set; }
    //    public virtual ICollection<CW_Product> CW_Product { get; set; }
    //    public virtual ICollection<CW_Support> CW_Support { get; set; }
    //    public virtual ICollection<CW_VideoClip> CW_VideoClip { get; set; }
    //    public virtual ICollection<CW_OpinionAboutUs> CW_OpinionAboutUs { get; set; }
    //}

    //[Table("CW_OpinionAboutUs")]
    //public class CW_OpinionAboutUs
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int OpinionAboutUsID { get; set; }

    //    [Required(ErrorMessage = "Bắt buộc phải nhập trường này!")]
    //    [Display(Name = "Ý kiến")]
    //    [StringLength(300, ErrorMessage = "Bạn chỉ có thể nhập tối đa 300 ký tự !")]
    //    public string Title { get; set; }

    //    [Required(ErrorMessage = "Bắt buộc phải nhập trường này!")]
    //    [Display(Name = "Ý kiến của")]
    //    [StringLength(100, ErrorMessage = "Bạn chỉ có thể nhập tối đa 100 ký tự !")]
    //    public string ByPost { get; set; }

    //    [Display(Name = "Kích hoạt hiển thị")]
    //    public bool IsActive { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    public string LanguageCode { get; set; }

    //    public virtual CW_Language CW_Language { get; set; }

    //}

    //[Table("CW_Email")]
    //public class CW_Email
    //{

    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int EmailID { get; set; }

    //    [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email không đúng định dạng")]
    //    [Display(Name = "Email")]
    //    [DataType(DataType.EmailAddress)]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    public string Email { get; set; }
    //    public DateTime CreatedDate { get; set; }
    //}

    //#endregion

    //#region "user model"

    //[Table("webpages_Roles")]
    //public class WebRole
    //{
    //    private string _roleName = string.Empty;
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int RoleId { get; set; }

    //    [Required(ErrorMessage = "Yêu cầu nhập tên nhóm")]
    //    [Display(Name = "Nhóm quyền")]
    //    [StringLength(50, ErrorMessage = "Bạn chỉ được nhập tối đa 50 ký tự !")]
    //    public string RoleName
    //    {
    //        get { return _roleName.Trim(); }
    //        set { _roleName = value.Trim(); }
    //    }

    //    [Display(Name = "Mô tả")]
    //    [StringLength(440, ErrorMessage = "Bạn chỉ được nhập tối đa 440 ký tự !")]
    //    public string Description { get; set; }
    //}

    //[Table("UserProfile")]
    //public class UserProfile
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int UserId { get; set; }

    //    //[RegularExpression(@"^[a-zA-Z][a-zA-Z0-9]{2,255}$", ErrorMessage = "Định dạng tài khoản không hợp lệ.")]
    //    [Display(Name = "Tài khoản")]
    //    [StringLength(50, ErrorMessage = "Bạn chỉ được nhập tối đa 50 ký tự !")]
    //    public string UserName { get; set; }

    //    [Display(Name = "Họ và tên")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [StringLength(70, ErrorMessage = "Bạn chỉ được nhập tối đa 70 ký tự !")]
    //    public string FullName { get; set; }

    //    [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email không đúng định dạng")]
    //    [Display(Name = "Email")]
    //    //[Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [StringLength(70, ErrorMessage = "Bạn chỉ được nhập tối đa 70 ký tự !")]
    //    [DataType(DataType.EmailAddress)]
    //    public string Email { get; set; }

    //    [Display(Name = "Địa chỉ")]
    //    [StringLength(200, ErrorMessage = "Bạn chỉ được nhập tối đa 200 ký tự !")]
    //    public string Address { get; set; }

    //    [Display(Name = "Điện thoại")]
    //    [StringLength(12, ErrorMessage = "Bạn chỉ được nhập tối đa 12 ký tự !")]
    //    [DataType(DataType.PhoneNumber)]
    //    public string Mobile { get; set; }

    //    [Display(Name = "Khóa tài khoản")]
    //    public bool IsLock { get; set; }

    //    public virtual ICollection<CW_Order> CW_Order { get; set; }
    //}

    ////dùng cho thành viên đăng ký 
    //[Table("CW_Customers")]
    //public class CW_Customers
    //{
    //    [Key]
    //    [ForeignKey("UserProfile")]
    //    [HiddenInput(DisplayValue = false)]
    //    public int UserId { get; set; }

    //    [Display(Name = "Tài khoản (Email)")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    [StringLength(70, ErrorMessage = "Bạn chỉ được nhập tối đa 70 ký tự !")]
    //    [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email không đúng định dạng")]
    //    [DataType(DataType.EmailAddress)]
    //    public string UserNameCustomer { get; set; }

    //    [Display(Name = "Yahoo")]
    //    [StringLength(50, ErrorMessage = "Bạn chỉ được nhập tối đa 50 ký tự !")]
    //    public string NickYahoo { get; set; }

    //    [Display(Name = "Skype")]
    //    [StringLength(50, ErrorMessage = "Bạn chỉ được nhập tối đa 50 ký tự !")]
    //    public string NickSkype { get; set; }

    //    [Display(Name = "Facebook")]
    //    [StringLength(100, ErrorMessage = "Bạn chỉ được nhập tối đa 100 ký tự !")]
    //    public string Facebook { get; set; }

    //    [Display(Name = "Nhóm khách hàng")]
    //    public int? CustomerGroupsID { get; set; }

    //    [Display(Name = "Tham gia")]
    //    public DateTime CreatedDate { get; set; }

    //    public virtual UserProfile UserProfile { get; set; }
    //    public virtual CW_CustomerGroups CW_CustomerGroups { get; set; }
    //    public virtual ICollection<CW_Message> CW_Message { get; set; }
    //}

    ////nhóm khách hàng
    //[Table("CW_CustomerGroups")]
    //public class CW_CustomerGroups
    //{
    //    public CW_CustomerGroups()
    //    {
    //        this.CW_Customers = new HashSet<CW_Customers>();
    //    }

    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int CustomerGroupsID { get; set; }

    //    [StringLength(100, ErrorMessage = "Bạn chỉ có thể nhập tối đa 100 ký tự !")]
    //    [Display(Name = "Tên nhóm")]
    //    [Required(ErrorMessage = "Bắt buộc phải nhập!")]
    //    public string CustomerGroupName { get; set; }

    //    [Display(Name = "Nhóm mặc định")]
    //    public bool IsDefault { get; set; }

    //    public DateTime CreatedDate { get; set; }

    //    public virtual ICollection<CW_Customers> CW_Customers { get; set; }
    //}

    //dùng cho việc thêm mới khách hàng
    public class RegisterCustomersModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Tài khoản có tố thiểu {2} ký tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("Password", ErrorMessage = "Nhập lại mật khẩu không trùng với mật khẩu.")]
        public string ConfirmPassword { get; set; }

        public CW_Customers CW_Customers { get; set; }
    }

    //[Table("webpages_Membership")]
    //public class webpages_Membership
    //{
    //    [Key]
    //    public int UserId { get; set; }
    //    public DateTime CreateDate { get; set; }
    //    public string ConfirmationToken { get; set; }
    //    public bool IsConfirmed { get; set; }
    //    public DateTime LastPasswordFailureDate { get; set; }
    //    public int PasswordFailuresSinceLastSuccess { get; set; }
    //    public string Password { get; set; }
    //    public DateTime PasswordChangeDate { get; set; }
    //    public string PasswordSalt { get; set; }
    //    public string PasswordVerificationToken { get; set; }
    //    public DateTime PasswordVerificationTokenExpirationDate { get; set; }
    //}

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu hiện tại")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Mật khẩu có tối thiểu 6 ký tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu mới")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu mới")]
        [System.Web.Mvc.Compare("NewPassword", ErrorMessage = "Mật khẩu nhập lại không khớp với mật khẩu mới.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required(ErrorMessage = "Bắt buộc phải nhập tài khoản.")]
        [Display(Name = "Tài khoản")]
        [StringLength(70, ErrorMessage = "Bạn chỉ được nhập tối đa 70 ký tự !")]
        //[RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Tài khoản không đúng định dạng email!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bắt buộc phải nhập mật khẩu.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "Mật khẩu có tối thiểu 6 ký tự.", MinimumLength = 6)]
        public string Password { get; set; }

        [Display(Name = "Nhớ đăng nhập?")]
        public bool RememberMe { get; set; }

        public string LanguageCode { get; set; }
    }

    public class RegisterModel
    {
        [Required(ErrorMessage = "Bắt buộc phải nhập tài khoản.")]
        [Display(Name = "Tài khoản")]
        [StringLength(70, ErrorMessage = "Bạn chỉ được nhập tối đa 70 ký tự !")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bắt buộc phải nhập mật khẩu.")]
        [StringLength(100, ErrorMessage = "Mật khẩu có tố thiểu {2} ký tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu")]
        [System.Web.Mvc.Compare("Password", ErrorMessage = "Nhập lại mật khẩu không trùng với mật khẩu.")]
        public string ConfirmPassword { get; set; }

        public UserProfile UserProfile { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }

    //#endregion

}