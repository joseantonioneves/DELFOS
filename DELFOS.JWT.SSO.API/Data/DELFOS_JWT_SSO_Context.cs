using DELFOS.JWT.SSO.MODELS;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace DELFOS.JWT.SSO.API.Data
{
    public partial class DELFOS_JWT_SSO_Context:DbContext
    {
        public virtual DbSet<AppPortifolio> Tb_AppPortifolios { get; set; } = null!;
        public virtual DbSet<BillModel> Tb_BillModels { get; set; } = null!;
        public virtual DbSet<CityModel> Tb_CityModels { get; set; } = null!;
        public virtual DbSet<CountryModel> Tb_CountryModels { get; set; } = null!;
        public virtual DbSet<EnrollmentModel> Tb_EnrollmentModels { get; set; } = null!;
        public virtual DbSet<OrganizationModel> Tb_OrganizationModels { get; set; } = null!;
        public virtual DbSet<RoleModel> Tb_RoleModels { get; set; } = null!;
        public virtual DbSet<SignatureModel> Tb_SignatureModels { get; set; } = null!;
        public virtual DbSet<StateModel> Tb_StateModels { get; set; } = null!;
        public virtual DbSet<UserLogin> Tb_UserLogins { get; set; } = null!;
        public virtual DbSet<UserModel> Tb_UserModels { get; set; } = null!;

        private IConfiguration? Configuration;

        //public DELFOS_JWT_SSO_Context(DbContextOptions<DELFOS_JWT_SSO_Context> options) : base(options) 
        //{
            
        //}

        public DELFOS_JWT_SSO_Context(IConfiguration _configuration)
        {
            Configuration = _configuration ?? throw new ArgumentNullException(nameof(_configuration));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connStr = this.Configuration.GetConnectionString("ConnDev");
            optionsBuilder.UseSqlServer(@connStr);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppPortifolio>(entity =>
            {
                entity.HasKey(e => e.AppId)
                    .HasName("AppPortifolio_PK");
            });

            modelBuilder.Entity<BillModel>(entity =>
            {
                entity.HasKey(e => e.BillId)
                    .HasName("BillModel_PK");

                entity.Property(e => e.Tipo).HasComment("Tipo do meio de pagamento:\r\n\r\n- Pix (PIX)\r\n- CC (Cartão de Crédito)\r\n- DEB (Cartão de Débito)\r\n- BLT (Boleto)");
            });

            modelBuilder.Entity<CityModel>(entity =>
            {
                entity.HasKey(e => e.CityId)
                    .HasName("CityModel_PK");

                entity.Property(e => e.Name).HasComment("	");

                entity.HasOne(d => d.StateModelState)
                    .WithOne(p => p.TbCityModel)
                    .HasForeignKey<CityModel>(d => d.StateModelStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CityModel_StateModel_FK");
            });

            modelBuilder.Entity<CountryModel>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("CountryModel_PK");
            });

            modelBuilder.Entity<EnrollmentModel>(entity =>
            {
                entity.HasKey(e => new { e.EnrollmentId, e.UserModelUserId })
                    .HasName("EnrollmentModel_PK");

                entity.Property(e => e.EnrollmentId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.AppPortifolioApp)
                    .WithOne(p => p.TbEnrollmentModel)
                    .HasForeignKey<EnrollmentModel>(d => d.AppPortifolioAppId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EnrollmentModel_AppPortifolio_FK");

                entity.HasOne(d => d.SignatureModelSignature)
                    .WithOne(p => p.TbEnrollmentModel)
                    .HasForeignKey<EnrollmentModel>(d => d.SignatureModelSignatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EnrollmentModel_SignatureModel_FK");

                entity.HasOne(d => d.UserModelUser)
                    .WithMany(p => p.TbEnrollmentModels)
                    .HasForeignKey(d => d.UserModelUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EnrollmentModel_UserModel_FK");
            });

            modelBuilder.Entity<OrganizationModel>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.CNPJ })
                    .HasName("OrganizationModel_PK");

                entity.Property(e => e.OrganizationId).ValueGeneratedOnAdd();

                entity.Property(e => e.CV).HasComment("código de verificação do cartão de crédito");

                entity.Property(e => e.Razao).HasComment("																																								");

                entity.HasOne(d => d.CityModelCity)
                    .WithOne(p => p.TbOrganizationModel)
                    .HasForeignKey<OrganizationModel>(d => d.CityModelCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrganizationModel_CityModel_FK");
            });

            modelBuilder.Entity<RoleModel>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("RoleModel_PK");
            });

            modelBuilder.Entity<SignatureModel>(entity =>
            {
                entity.HasKey(e => e.SignatureId)
                    .HasName("SignatureModel_PK");

                entity.HasOne(d => d.BillModelBill)
                    .WithOne(p => p.TbSignatureModel)
                    .HasForeignKey<SignatureModel>(d => d.BillModelBillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SignatureModel_BillModel_FK");

                entity.HasOne(d => d.OrganizationModel)
                    .WithOne(p => p.TbSignatureModel)
                    .HasForeignKey<SignatureModel>(d => new { d.OrganizationModelOrganizationId, d.OrganizationModelCnpj })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SignatureModel_OrganizationModel_FK");
            });

            modelBuilder.Entity<StateModel>(entity =>
            {
                entity.HasKey(e => e.StateId)
                    .HasName("StateModel_PK");

                entity.HasOne(d => d.CountryModelCountry)
                    .WithOne(p => p.TbStateModel)
                    .HasForeignKey<StateModel>(d => d.CountryModelCountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StateModel_CountryModel_FK");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.UserLoginId)
                    .HasName("UserLogin_PK");

                entity.HasOne(d => d.UserModelUser)
                    .WithMany(p => p.TbUserLogins)
                    .HasForeignKey(d => d.UserModelUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserLogin_UserModel_FK");
            });

            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("UserModel_PK");

                entity.HasOne(d => d.RoleModelRole)
                    .WithMany(p => p.TbUserModels)
                    .HasForeignKey(d => d.RoleModelRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserModel_RoleModel_FK");
            });

            OnModelCreatingGeneratedProcedures(modelBuilder);
            OnModelCreatingGeneratedFunctions(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }
    }
}
