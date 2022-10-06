using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DELFOS.JWT.SSO.API.Models
{
    public class StateModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required,StringLength(50)]
        public string? Name { get; set; }

        [Required]
        public int CountryId { get; set; }

        public CountryModel? CountryName { get; set; }
        public ICollection<CityModel> Cities { get; set; } = null!;
    }
}