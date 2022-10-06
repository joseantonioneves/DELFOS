using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DELFOS.JWT.SSO.API.Models
{
    public class CityModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string? Name { get; set; }

        public StateModel? State { get; set; }

    }
}