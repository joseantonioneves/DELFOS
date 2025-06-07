using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DELFOS.JWT.SSO.MODELS
{
    [Table("Tb_UserLogin")]
    public partial class UserLogin
    {
        [Key]
        [Column("UserLoginId", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "User Login Id is required")]
        [Display(Name = "User Login Id")]
        public long UserLoginId { get; set; } // bigint, not null

        [Column("CreateLogin", TypeName = "datetime")]
        [Display(Name = "Create Login")]
        public DateTime? CreateLogin { get; set; } // datetime, null

        [Column("LogTime", TypeName = "datetime")]
        [Display(Name = "Log Time")]
        public DateTime? LogTime { get; set; } // datetime, null

        [Column("AuthenticateResult", TypeName = "bit")]
        [Display(Name = "Authenticate Result")]
        public bool? AuthenticateResult { get; set; } // bit, null

        [Column("LOG", TypeName = "nvarchar")]
        [MaxLength(255)]
        [StringLength(255)]
        [Display(Name = "LOG")]
        public string LOG { get; set; } = null!;// nvarchar(255), null

        [Column("UserModel_UserId", TypeName = "bigint")]
        [Required(ErrorMessage = "User Model User Id is required")]
        [Display(Name = "User Model User Id")]
        public long? UserModelUserId { get; set; } // bigint, not null

        [Column("UserName", TypeName = "nvarchar")]
        [MaxLength(100)]
        [StringLength(100)]
        [Display(Name = "User Name")]
        public string UserName { get; set; } = null!;

        [Column("Password", TypeName = "nvarchar")]
        [MaxLength(250)]
        [StringLength(250)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!; // nvarchar(250), null

        [ForeignKey(nameof(UserModelUserId))]
        [InverseProperty(nameof(UserModel.TbUserLogins))]
        public virtual UserModel UserModelUser { get; set; } = null!;
    }
}
