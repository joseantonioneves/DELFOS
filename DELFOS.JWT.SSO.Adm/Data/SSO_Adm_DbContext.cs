using Microsoft.EntityFrameworkCore;
using DELFOS.JWT.SSO.MODELS;
namespace DELFOS.JWT.SSO.Adm.Data
{
    public class SSO_Adm_DbContext:DbContext
    {
        public SSO_Adm_DbContext(DbContextOptions <SSO_Adm_DbContext> options):base(options) 
        {   }
        public DbSet<AppPortifolio> Tb_AppsPortifolio { get; set; } = null!;
        public DbSet<CityModel> Tb_Cities { get; set; } = null!;
        public DbSet<CountryModel> Tb_Countries { get; set; } = null!;
        public DbSet<OrganizationModel> Tb_Organizations { get; set; } = null!;
        public DbSet<StateModel> Tb_States { get; set; } = null!;
        public DbSet<UserLogin> Tb_UsersLogin { get; set; } = null!;
        public DbSet<UserModel> Tb_Users { get; set; } = null!;
    }
}
