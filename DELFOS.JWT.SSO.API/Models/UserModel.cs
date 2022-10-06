using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DELFOS.JWT.SSO.API.Models
{
    public class UserModel
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(Order = 1), StringLength(150)]
        public string? UserName { get; set; }

        [Column(Order = 2), StringLength(250)]
        public string? Password { get; set; }

        [Column(Order = 3), StringLength(150)]
        public string? EmailAddress { get; set; }

        [Column(Order = 4), StringLength(100)]
        public string? Role { get; set; }

        [Column(Order = 5), StringLength(150)]
        public string? Surname { get; set; }

        [Column(Order = 6), StringLength(150)]
        public string? GivenName { get; set; }

        [Column(Order = 7)]
        public int OrganizationId { get; set; }

        public OrganizationModel? Organization { get; set; }
        public ICollection<AppPortifolio> Apps { get; set; } = null!;
    }
}
