using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DELFOS.JWT.SSO.MODELS
{
    [Table("AppPortifolio")]
    public partial class AppPortifolio
    {
        //public AppPortifolio()
        //{
        //    this.TbEnrollmentModels = new HashSet<EnrollmentModel>();
        //}

        [Key]
        [Column("AppId", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "App Id is required")]
        [Display(Name = "App Id")]
        public virtual long AppId { get; set; } // bigint, not null

        [Column("ApplicationName", TypeName = "nvarchar")]
        [MaxLength(150)]
        [StringLength(150)]
        [Display(Name = "Application Name")]
        public string? ApplicationName { get; set; } // nvarchar(150), null

        [Column("IsActive", TypeName = "bit")]
        [Display(Name = "Is Active")]
        public bool? IsActive { get; set; } // bit, null

        [InverseProperty("AppPortifolioApp")]
        public virtual EnrollmentModel TbEnrollmentModel { get; set; } = null!;
    }
}
