using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Model.EF
{
    [Table("CW_Setting")]
    public class CW_Setting
    {
        [Key]
        public string SettingKey { get; set; }

        [AllowHtml]
        public string SettingValue { get; set; }

        [StringLength(100, ErrorMessage = "Bạn chỉ được nhập tối đa 100 ký tự !")]
        public string SettingGroup { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(200, ErrorMessage = "Bạn chỉ được nhập tối đa 200 ký tự !")]
        public string SettingComment { get; set; }

        [Display(Name = "Ngôn ngữ")]
        [StringLength(10, ErrorMessage = "Bạn chỉ được nhập tối đa 10 ký tự !")]
        public string LanguageCode { get; set; }

        public virtual CW_Language CW_Language { get; set; }
    }
}
