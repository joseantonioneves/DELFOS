using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DELFOS.JWT.SSO.MODELS
{
    [Table("Tb_CityModel")]
    [Index(nameof(StateModelStateId), Name = "CityModel__IDX", IsUnique = true)]
    public partial class CityModel
    {
        //public CityModel()
        //{
        //    this.TbOrganizationModels = new HashSet<OrganizationModel>();
        //}

        [Key]
        [Column("CityId", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "City Id is required")]
        [Display(Name = "City Id")]
        public long CityId { get; set; } // bigint, not null

        [Column("Name", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Name")]
        [Description("	")]
        public string? Name { get; set; } // nvarchar(50), null

        [Column("IBGE", TypeName = "nvarchar")]
        [MaxLength(7)]
        [StringLength(7)]
        [Display(Name = "IBGE")]
        public string? IBGE { get; set; } // nvarchar(7), null

        [Column("StateModel_StateId", TypeName = "bigint")]
        [Required(ErrorMessage = "State Model State Id is required")]
        [Display(Name = "State Model State Id")]
        public long StateModelStateId { get; set; } // bigint, not null

        [ForeignKey(nameof(StateModelStateId))]
        [InverseProperty(nameof(StateModel.TbCityModel))]
        public virtual StateModel StateModelState { get; set; } = null!;
        [InverseProperty("CityModelCity")]
        public virtual OrganizationModel TbOrganizationModel { get; set; } = null!;
    }
}
