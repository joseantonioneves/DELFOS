using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace DELFOS.JWT.SSO.MODELS
{
    [Table("Tb_EnrollmentModel")]
    [Index(nameof(AppPortifolioAppId), Name = "EnrollmentModel__IDX", IsUnique = true)]
    [Index(nameof(SignatureModelSignatureId), Name = "EnrollmentModel__IDXv1", IsUnique = true)]
    public partial class EnrollmentModel
    {
        [Key]
        [Column("EnrollmentId", TypeName = "bigint", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Enrollment Id is required")]
        [Display(Name = "Enrollment Id")]
        public long EnrollmentId { get; set; } // bigint, not null

        [Column("AppPortifolio_AppId", TypeName = "bigint")]
        [Required(ErrorMessage = "App Portifolio App Id is required")]
        [Display(Name = "App Portifolio App Id")]
        public long AppPortifolioAppId { get; set; } // bigint, not null

        [Column("SignatureModel_SignatureId", TypeName = "bigint")]
        [Required(ErrorMessage = "Signature Model Signature Id is required")]
        [Display(Name = "Signature Model Signature Id")]
        public long SignatureModelSignatureId { get; set; } // bigint, not null

        
        [Column("UserModel_UserId", TypeName = "bigint", Order = 2)]
        [Required(ErrorMessage = "User Model User Id is required")]
        [Display(Name = "User Model User Id")]
        public virtual long UserModelUserId { get; set; } // bigint, not null

        [ForeignKey(nameof(AppPortifolioAppId))]
        [InverseProperty(nameof(AppPortifolio.TbEnrollmentModel))]
        public virtual AppPortifolio AppPortifolioApp { get; set; } = null!;
        [ForeignKey(nameof(SignatureModelSignatureId))]
        [InverseProperty(nameof(SignatureModel.TbEnrollmentModel))]
        public virtual SignatureModel SignatureModelSignature { get; set; } = null!;
        [ForeignKey(nameof(UserModelUserId))]
        [InverseProperty(nameof(UserModel.TbEnrollmentModels))]
        public virtual UserModel UserModelUser { get; set; } = null!;
    }
}