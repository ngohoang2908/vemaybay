using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Model.EF
{
    [Table("CW_Language")]
    public class CW_Language
    {
        [Key]
        public string LanguageCode { get; set; }

        public string Title { get; set; }

        public virtual ICollection<CW_Category> Category { get; set; }
        public virtual ICollection<CW_Adv> CW_Adv { get; set; }
        public virtual ICollection<CW_Article> CW_Article { get; set; }
        public virtual ICollection<CW_News> CW_News { get; set; }
        public virtual ICollection<CW_Support> CW_Support { get; set; }
    }
}
