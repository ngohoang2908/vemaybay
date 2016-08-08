using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Model.EF
{
    [Table("CW_Adv")]
    public class CW_Adv
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Title", ResourceType = typeof(StaticResources.Resources))]
        [Required(ErrorMessageResourceName = "EntryRequirementstitle",ErrorMessageResourceType = typeof(StaticResources.Resources))]
        [StringLength(400, ErrorMessageResourceName = "Error_400",ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string Title
        {
            get;
            set;
        }

        [Display(Name = "Image", ResourceType = typeof(StaticResources.Resources))]
        [Required(ErrorMessageResourceName = "Error_Imageenter", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        [StringLength(200, ErrorMessageResourceName = "Error_200", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string Image { get; set; }

        [Display(Name = "Link", ResourceType = typeof(StaticResources.Resources))]
        [StringLength(200, ErrorMessageResourceName = "Error_200", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string Link { get; set; }

        [Display(Name = "Description", ResourceType = typeof(StaticResources.Resources))]
        [StringLength(500, ErrorMessageResourceName = "Error_500", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        [AllowHtml]
        public string Description { get; set; }

        [Display(Name = "Height", ResourceType = typeof(StaticResources.Resources))]
        [Range(0, int.MaxValue, ErrorMessageResourceName = "Error_Number_positive", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        [RegularExpression(@"[0-9]*$", ErrorMessageResourceName = "Number_1_9", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public int Height { get; set; }

        [Display(Name = "Width", ResourceType = typeof(StaticResources.Resources))]
        [Range(0, int.MaxValue, ErrorMessageResourceName = "Error_Number_positive", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        [RegularExpression(@"[0-9]*$", ErrorMessageResourceName = "Number_1_9", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public int Width { get; set; }

        [Display(Name = "Position", ResourceType = typeof(StaticResources.Resources))]
        [Range(0, int.MaxValue, ErrorMessageResourceName = "Error_Number_positive", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        [RegularExpression(@"[0-9]*$", ErrorMessageResourceName = "Number_1_9", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public int Position { get; set; }

        [Display(Name = "Linktype", ResourceType = typeof(StaticResources.Resources))]
        [StringLength(30, ErrorMessageResourceName = "Error_position", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string Target { get; set; }

        [Display(Name = "Flashtype", ResourceType = typeof(StaticResources.Resources))]
        public bool IsFlash { get; set; }

        [Display(Name = "Active", ResourceType = typeof(StaticResources.Resources))]
        public bool IsActive { get; set; }

        [Display(Name = "Orders", ResourceType = typeof(StaticResources.Resources))]
        [Range(0, int.MaxValue)]
        [RegularExpression(@"[0-9]*$", ErrorMessageResourceName = "Number_1_9", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public int Order { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(400, ErrorMessageResourceName = "Error_400", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string MetaTitle { get; set; }

        [StringLength(500, ErrorMessageResourceName = "Error_500", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string MetaDescription { get; set; }

        [Display(Name = "Language", ResourceType = typeof(StaticResources.Resources))]
        [StringLength(10, ErrorMessageResourceName = "Error_10", ErrorMessageResourceType = typeof(StaticResources.Resources))]
        public string LanguageCode { get; set; }

        public virtual CW_Language CW_Language { get; set; }

    }
}
