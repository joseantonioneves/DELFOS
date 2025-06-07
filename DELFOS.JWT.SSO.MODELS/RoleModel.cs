
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DELFOS.JWT.SSO.MODELS
{
    [Table("Tb_RoleModel")]
    public partial class RoleModel
    {
        public RoleModel()
        {
            this.TbUserModels = new HashSet<UserModel>();
        }

        [Key]
        [Column("RoleId", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Role Id is required")]
        [Display(Name = "Role Id")]
        public long RoleId { get; set; } // bigint, not null

        [Column("RoleName", TypeName = "nvarchar")]
        [MaxLength(100)]
        [StringLength(100)]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; } = null!; // nvarchar(100), null

        [InverseProperty(nameof(UserModel.RoleModelRole))]
        public virtual ICollection<UserModel> TbUserModels { get; set; }
    }
}
