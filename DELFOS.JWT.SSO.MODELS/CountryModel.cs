using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DELFOS.JWT.SSO.MODELS
{
    [Table("Tb_CountryModel")]
    public partial class CountryModel
    {
        //public CountryModel()
        //{
        //    this.TbStateModels = new HashSet<StateModel>();
        //}

        [Key]
        [Column("CountryId", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Country Id is required")]
        [Display(Name = "Country Id")]
        public long CountryId { get; set; } // bigint, not null

        [Column("Name", TypeName = "nvarchar")]
        [MaxLength(100)]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!; // nvarchar(100), null

        [Column("Codigo", TypeName = "nvarchar")]
        [MaxLength(3)]
        [StringLength(3)]
        [Display(Name = "Codigo")]
        public string Codigo { get; set; } = null!; // nvarchar(3), null

        [Column("Fone", TypeName = "nvarchar")]
        [MaxLength(4)]
        [StringLength(4)]
        [Display(Name = "Fone")]
        public string Fone { get; set; } = null!; // nvarchar(4), null

        [Column("ISO", TypeName = "nvarchar")]
        [MaxLength(2)]
        [StringLength(2)]
        [Display(Name = "ISO")]
        public string ISO { get; set; } = null!; // nvarchar(2), null

        [Column("ISO3", TypeName = "nvarchar")]
        [MaxLength(3)]
        [StringLength(3)]
        [Display(Name = "IS O3")]
        public string ISO3 { get; set; } = null!; // nvarchar(3), null

        [Column("NomeFormal", TypeName = "nvarchar")]
        [MaxLength(150)]
        [StringLength(150)]
        [Display(Name = "Formal Name")]
        public string NomeFormal { get; set; } = null!; // nvarchar(150), null

        [InverseProperty("CountryModelCountry")]
        public virtual StateModel TbStateModel { get; set; } = null!;
    }
}
