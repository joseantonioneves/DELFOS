using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace DELFOS.JWT.SSO.MODELS
{
    [Table("Tb_OrganizationModel")]
    [Index(nameof(CityModelCityId), Name = "OrganizationModel__IDX", IsUnique = true)]
    public partial class OrganizationModel
    {
        //public OrganizationModel()
        //{
        //    this.TbSignatureModels = new HashSet<SignatureModel>();
        //}

        [Key]
        [Column("OrganizationId", TypeName = "bigint", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Organization Id is required")]
        [Display(Name = "Organization Id")]
        public long OrganizationId { get; set; } // bigint, not null

        [Column("Razao", TypeName = "nvarchar")]
        [MaxLength(250)]
        [StringLength(250)]
        [Display(Name = "Razao")]
        public string Razao { get; set; } = null!; // nvarchar(250), null

        
        [Column("CNPJ", TypeName = "nvarchar", Order = 2)]
        [MaxLength(15)]
        [StringLength(15)]
        [Required(ErrorMessage = "CNPJ is required")]
        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; } = null!; // nvarchar(15), not null

        [Column("IsActive", TypeName = "bit")]
        [Display(Name = "Is Active")]
        public bool? IsActive { get; set; } // bit, null

        [Column("Address", TypeName = "nvarchar")]
        [MaxLength(250)]
        [StringLength(250)]
        [Display(Name = "Address")]
        public string Address { get; set; } = null!; // nvarchar(250), null

        [Column("NumberAddr", TypeName = "nvarchar")]
        [MaxLength(6)]
        [StringLength(6)]
        [Display(Name = "Number Addr")]
        public string NumberAddr { get; set; } = null!; // nvarchar(6), null

        [Column("ZipCode", TypeName = "nvarchar")]
        [MaxLength(8)]
        [StringLength(8)]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; } = null!; // nvarchar(8), null

        [Column("District", TypeName = "nvarchar")]
        [MaxLength(150)]
        [StringLength(150)]
        [Display(Name = "District")]
        public string District { get; set; } = null!; // nvarchar(150), null

        [Column("CreditCardNumber", TypeName = "nvarchar")]
        [MaxLength(16)]
        [StringLength(16)]
        [Display(Name = "Credit Card Number")]
        public string CreditCardNumber { get; set; } = null!; // nvarchar(16), null

        /// <summary>
        /// código de verificação do cartão de crédito
        /// </summary>
        [Column("CV", TypeName = "nvarchar")]
        [MaxLength(3)]
        [StringLength(3)]
        [Display(Name = "CV")]
        [Description("código de verificação do cartão de crédito")]
        public string CV { get; set; } = null!; // nvarchar(3), null

        [Column("EmailContact", TypeName = "nvarchar")]
        [MaxLength(255)]
        [StringLength(255)]
        [Display(Name = "Email Contact")]
        public string EmailContact { get; set; } = null!; // nvarchar(255), null

        [Column("CityModel_CityId", TypeName = "bigint")]
        [Required(ErrorMessage = "City Model City Id is required")]
        [Display(Name = "City Model City Id")]
        public long CityModelCityId { get; set; } // bigint, not null

        [ForeignKey(nameof(CityModelCityId))]
        [InverseProperty(nameof(CityModel.TbOrganizationModel))]
        public virtual CityModel CityModelCity { get; set; } = null!;
        [InverseProperty("OrganizationModel")]
        public virtual SignatureModel TbSignatureModel { get; set; } = null!;
    }
}