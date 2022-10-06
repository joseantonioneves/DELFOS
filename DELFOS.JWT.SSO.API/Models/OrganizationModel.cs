using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DELFOS.JWT.SSO.API.Models
{
    public class OrganizationModel
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, Column(Order =1), StringLength(150)]
        public string? Razao { get; set; }

        [Required, Column(Order =2), StringLength(15)]
        public string?CNPJ { get; set; }

        [Required,Column(Order =3)]
        public bool? Status { get; set; }

        [Column(Order =4), StringLength(150)]
        public string? Address { get; set; }

        [Column(Order =5), StringLength(5)]
        public string? NumberAddr { get; set; }

        [Column(Order =6), StringLength(9)]
        public string? ZipCode { get; set; }

        [Column(Order =7), StringLength(50)]
        public string? District { get; set; } //bairro

        [Column(Order =8), StringLength(100)]
        public string? CityId { get; set; }

        [Column(Order =9)]
        public int StateId { get; set; }

        [Column(Order =10)]
        public int CountryId { get; set; }

        public CountryModel? Country { get; set; } 
        public StateModel? State { get; set; }
        public CityModel? City { get; set; }

    }
}
