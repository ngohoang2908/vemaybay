using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Model.EF
{
    [Table("webpages_Roles")]
    public class WebRole
    {
        private string _roleName = string.Empty;
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập tên nhóm")]
        [Display(Name = "Nhóm quyền")]
        [StringLength(50, ErrorMessage = "Bạn chỉ được nhập tối đa 50 ký tự !")]
        public string RoleName
        {
            get { return _roleName.Trim(); }
            set { _roleName = value.Trim(); }
        }

        [Display(Name = "Mô tả")]
        [StringLength(440, ErrorMessage = "Bạn chỉ được nhập tối đa 440 ký tự !")]
        public string Description { get; set; }
    }
}
