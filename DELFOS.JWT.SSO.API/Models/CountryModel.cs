using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DELFOS.JWT.SSO.API.Models
{
    public class CountryModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required,StringLength(100)]
        public string? Country { get; set; }

        public ICollection<StateModel> States { get; set; } = null!;
        public ICollection<CityModel> Cities { get; set; } = null!;

    }
}