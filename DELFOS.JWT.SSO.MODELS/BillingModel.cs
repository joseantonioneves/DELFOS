using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DELFOS.JWT.SSO.MODELS
{
    [Table("Tb_BillModel")]
    public partial class BillModel
    {
        //public BillModel()
        //{
        //    this.TbSignatureModels = new HashSet<SignatureModel>();
        //}

        [Key]
        [Column("BillId", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Bill Id is required")]
        [Display(Name = "Bill Id")]
        public long BillId { get; set; } // bigint, not null

        /// <summary>
        /// Tipo do meio de pagamento:
        /// 
        /// - Pix (PIX)
        /// - CC (Cartão de Crédito)
        /// - DEB (Cartão de Débito)
        /// - BLT (Boleto)
        /// </summary>
                [Column("Tipo", TypeName = "nvarchar")]
        [MaxLength(3)]
        [StringLength(3)]
        [Display(Name = "Tipo")]
        [Description("Tipo do meio de pagamento:Pix(PIX), CC(Cartão de Crédito), DEB(Cartão de Débito), BLT(Boleto)")]
        public virtual string? Tipo { get; set; } // nvarchar(3), null

        [Column("UrlAPI", TypeName = "nvarchar")]
        [MaxLength(255)]
        [StringLength(255)]
        [Display(Name = "Url API")]
        public virtual string? UrlAPI { get; set; } // nvarchar(255), null

        [InverseProperty("BillModelBill")]
        public virtual SignatureModel TbSignatureModel { get; set; } = null!;
    }
}
