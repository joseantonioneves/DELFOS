using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DELFOS.JWT.SSO.MODELS
{
    [Table("Tb_UserModel")]
    public partial class UserModel
    {
        public UserModel()
        {
            TbEnrollmentModels = new HashSet<EnrollmentModel>();
            TbUserLogins = new HashSet<UserLogin>();
        }

        [Key]
        [Column("UserId", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "User Id is required")]
        [Display(Name = "User Id")]
        public long UserId { get; set; } // bigint, not null

        [Column("UserName", TypeName = "nvarchar")]
        [MaxLength(150)]
        [StringLength(150)]
        [Display(Name = "User Name")]
        public string UserName { get; set; } = null!; // nvarchar(150), null

        [Column("Password", TypeName = "nvarchar")]
        [MaxLength(250)]
        [StringLength(250)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!; // nvarchar(250), null

        [Column("EmailAddress", TypeName = "nvarchar")]
        [MaxLength(150)]
        [StringLength(150)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; } = null!; // nvarchar(150), null

        [Column("Role", TypeName = "nvarchar")]
        [MaxLength(100)]
        [StringLength(100)]
        [Display(Name = "Role")]
        public string Role { get; set; } = null!; // nvarchar(100), null

        [Column("Surname", TypeName = "nvarchar")]
        [MaxLength(150)]
        [StringLength(150)]
        [Display(Name = "Surname")]
        public string Surname { get; set; } = null!; // nvarchar(150), null

        [Column("GivenName", TypeName = "nvarchar")]
        [MaxLength(150)]
        [StringLength(150)]
        [Display(Name = "Given Name")]
        public string GivenName { get; set; } = null!; // nvarchar(150), null

        [Column("IsActive", TypeName = "bit")]
        [Display(Name = "Is Active")]
        public bool? IsActive { get; set; } // bit, null

        [Column("RoleModel_RoleId", TypeName = "bigint")]
        [Required(ErrorMessage = "Role Model Role Id is required")]
        [Display(Name = "Role Model Role Id")]
        public virtual long? RoleModelRoleId { get; set; } // bigint, not null

        [Column("RoleName", TypeName = "nvarchar")]
        [MaxLength(100)]
        [StringLength(100)]
        [Display(Name = "Role Name")]
        public virtual string RoleName { get; set; } = null!;

        [ForeignKey(nameof(RoleModelRoleId))]
        [InverseProperty(nameof(RoleModel.TbUserModels))]
        public virtual RoleModel RoleModelRole { get; set; } = null!;
        [InverseProperty(nameof(EnrollmentModel.UserModelUser))]
        public virtual ICollection<EnrollmentModel> TbEnrollmentModels { get; set; }
        [InverseProperty(nameof(UserLogin.UserModelUser))]
        public virtual ICollection<UserLogin> TbUserLogins { get; set; }
    }
}
