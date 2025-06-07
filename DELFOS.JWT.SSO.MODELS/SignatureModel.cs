using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DELFOS.JWT.SSO.MODELS
{
    [Table("Tb_SignatureModel")]
    [Index(nameof(BillModelBillId), Name = "SignatureModel__IDX", IsUnique = true)]
    [Index(nameof(OrganizationModelOrganizationId), nameof(OrganizationModelCnpj), Name = "SignatureModel__IDXv1", IsUnique = true)]
    public partial class SignatureModel
    {
        //public SignatureModel()
        //{
        //    this.TbEnrollmentModels = new HashSet<EnrollmentModel>();
        //}

        [Key]
        [Column("SignatureId", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Signature Id is required")]
        [Display(Name = "Signature Id")]
        public long SignatureId { get; set; } // bigint, not null

        [Column("KeySignature", TypeName = "nvarchar")]
        [MaxLength(128)]
        [StringLength(128)]
        [Display(Name = "Key Signature")]
        public string KeySignature { get; set; } = null!;// nvarchar(128), null

        [Column("IsActive", TypeName = "bit")]
        [Display(Name = "Is Active")]
        public bool? IsActive { get; set; }// bit, null

        [Column("OrganizationModel_OrganizationId", TypeName = "bigint")]
        [Required(ErrorMessage = "Organization Model Organization Id is required")]
        [Display(Name = "Organization Model Organization Id")]
        public long OrganizationModelOrganizationId { get; set; } // bigint, not null

        [Column("BillModel_BillId", TypeName = "bigint")]
        [Required(ErrorMessage = "Bill Model Bill Id is required")]
        [Display(Name = "Bill Model Bill Id")]
        public long BillModelBillId { get; set; } // bigint, not null

        [Column("AppId", TypeName = "bigint")]
        [Required(ErrorMessage = "App Id is required")]
        [Display(Name = "App Id")]
        public long AppId { get; set; } // bigint, not null

        [Column("OrganizationModel_CNPJ", TypeName = "nvarchar")]
        [MaxLength(15)]
        [StringLength(15)]
        [Required(ErrorMessage = "Organization Model CNPJ is required")]
        [Display(Name = "Organization Model CNPJ")]
        public string OrganizationModelCnpj { get; set; } = null!;// nvarchar(15), not null

        [ForeignKey(nameof(BillModelBillId))]
        [InverseProperty(nameof(BillModel.TbSignatureModel))]
        public virtual BillModel BillModelBill { get; set; } = null!;
        [ForeignKey("OrganizationModelOrganizationId,OrganizationModelCnpj")]
        [InverseProperty(nameof(MODELS.OrganizationModel.TbSignatureModel))]
        public virtual OrganizationModel OrganizationModel { get; set; } = null!;
        [InverseProperty("SignatureModelSignature")]
        public virtual EnrollmentModel TbEnrollmentModel { get; set; } = null!;
    }
}
