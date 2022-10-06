using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DELFOS.JWT.SSO.API.Models
{
    public class AppPortifolio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? ApplicationName { get; set; }

        public string? Status { get; set; } 

        public OrganizationModel? Organization { get; set; }
        public UserModel? User { get; set; }    

    }
}