using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DELFOS.JWT.SSO.MODELS
{
    [Table("Tb_StateModel")]
    public partial class StateModel
    {
        [Key]
        [Column("StateId", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "State Id is required")]
        [Display(Name = "State Id")]
        public long StateId { get; set; } // bigint, not null

        [Column("Name", TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;// nvarchar(50), null

        [Column("UF", TypeName = "nvarchar")]
        [MaxLength(2)]
        [StringLength(2)]
        [Display(Name = "UF")]
        public string UF { get; set; } = null!; // nvarchar(2), null

        [Column("IBGECode", TypeName = "nvarchar")]
        [MaxLength(7)]
        [StringLength(7)]
        [Display(Name = "IBGE Code")]
        public string IBGECode { get; set; } = null!; // nvarchar(7), null

        [Column("DDD", TypeName = "nvarchar")]
        [MaxLength(3)]
        [StringLength(3)]
        [Display(Name = "DDD")]
        public string DDD { get; set; } = null!; // nvarchar(3), null

        [Column("CountryModel_CountryId", TypeName = "bigint")]
        [Required(ErrorMessage = "Country Model Country Id is required")]
        [Display(Name = "Country Model Country Id")]
        public long CountryModelCountryId { get; set; } // bigint, not null

        [ForeignKey(nameof(CountryModelCountryId))]
        [InverseProperty(nameof(CountryModel.TbStateModel))]
        public virtual CountryModel CountryModelCountry { get; set; } = null!;
        [InverseProperty("StateModelState")]
        public virtual CityModel TbCityModel { get; set; } = null!;
    }
}