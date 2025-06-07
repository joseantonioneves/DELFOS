using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DELFOS.JWT.SSO.API.Data.Migrations
{
    public partial class CriacaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppPortifolio",
                columns: table => new
                {
                    AppId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AppPortifolio_PK", x => x.AppId);
                });

            migrationBuilder.CreateTable(
                name: "Tb_BillModel",
                columns: table => new
                {
                    BillId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true, comment: "Tipo do meio de pagamento:\r\n\r\n- Pix (PIX)\r\n- CC (Cartão de Crédito)\r\n- DEB (Cartão de Débito)\r\n- BLT (Boleto)"),
                    UrlAPI = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BillModel_PK", x => x.BillId);
                });

            migrationBuilder.CreateTable(
                name: "Tb_CountryModel",
                columns: table => new
                {
                    CountryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Fone = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    ISO = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ISO3 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NomeFormal = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CountryModel_PK", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Tb_RoleModel",
                columns: table => new
                {
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("RoleModel_PK", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Tb_StateModel",
                columns: table => new
                {
                    StateId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    IBGECode = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    DDD = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CountryModel_CountryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("StateModel_PK", x => x.StateId);
                    table.ForeignKey(
                        name: "StateModel_CountryModel_FK",
                        column: x => x.CountryModel_CountryId,
                        principalTable: "Tb_CountryModel",
                        principalColumn: "CountryId");
                });

            migrationBuilder.CreateTable(
                name: "Tb_UserModel",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    GivenName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    RoleModel_RoleId = table.Column<long>(type: "bigint", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UserModel_PK", x => x.UserId);
                    table.ForeignKey(
                        name: "UserModel_RoleModel_FK",
                        column: x => x.RoleModel_RoleId,
                        principalTable: "Tb_RoleModel",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "Tb_CityModel",
                columns: table => new
                {
                    CityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "	"),
                    IBGE = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    StateModel_StateId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CityModel_PK", x => x.CityId);
                    table.ForeignKey(
                        name: "CityModel_StateModel_FK",
                        column: x => x.StateModel_StateId,
                        principalTable: "Tb_StateModel",
                        principalColumn: "StateId");
                });

            migrationBuilder.CreateTable(
                name: "Tb_UserLogin",
                columns: table => new
                {
                    UserLoginId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateLogin = table.Column<DateTime>(type: "datetime", nullable: true),
                    LogTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    AuthenticateResult = table.Column<bool>(type: "bit", nullable: true),
                    LOG = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserModel_UserId = table.Column<long>(type: "bigint", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UserLogin_PK", x => x.UserLoginId);
                    table.ForeignKey(
                        name: "UserLogin_UserModel_FK",
                        column: x => x.UserModel_UserId,
                        principalTable: "Tb_UserModel",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Tb_OrganizationModel",
                columns: table => new
                {
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Razao = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "																																								"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NumberAddr = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    District = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreditCardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    CV = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false, comment: "código de verificação do cartão de crédito"),
                    EmailContact = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CityModel_CityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("OrganizationModel_PK", x => new { x.OrganizationId, x.CNPJ });
                    table.ForeignKey(
                        name: "OrganizationModel_CityModel_FK",
                        column: x => x.CityModel_CityId,
                        principalTable: "Tb_CityModel",
                        principalColumn: "CityId");
                });

            migrationBuilder.CreateTable(
                name: "Tb_SignatureModel",
                columns: table => new
                {
                    SignatureId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeySignature = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    OrganizationModel_OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    BillModel_BillId = table.Column<long>(type: "bigint", nullable: false),
                    AppId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationModel_CNPJ = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SignatureModel_PK", x => x.SignatureId);
                    table.ForeignKey(
                        name: "SignatureModel_BillModel_FK",
                        column: x => x.BillModel_BillId,
                        principalTable: "Tb_BillModel",
                        principalColumn: "BillId");
                    table.ForeignKey(
                        name: "SignatureModel_OrganizationModel_FK",
                        columns: x => new { x.OrganizationModel_OrganizationId, x.OrganizationModel_CNPJ },
                        principalTable: "Tb_OrganizationModel",
                        principalColumns: new[] { "OrganizationId", "CNPJ" });
                });

            migrationBuilder.CreateTable(
                name: "Tb_EnrollmentModel",
                columns: table => new
                {
                    EnrollmentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserModel_UserId = table.Column<long>(type: "bigint", nullable: false),
                    AppPortifolio_AppId = table.Column<long>(type: "bigint", nullable: false),
                    SignatureModel_SignatureId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("EnrollmentModel_PK", x => new { x.EnrollmentId, x.UserModel_UserId });
                    table.ForeignKey(
                        name: "EnrollmentModel_AppPortifolio_FK",
                        column: x => x.AppPortifolio_AppId,
                        principalTable: "AppPortifolio",
                        principalColumn: "AppId");
                    table.ForeignKey(
                        name: "EnrollmentModel_SignatureModel_FK",
                        column: x => x.SignatureModel_SignatureId,
                        principalTable: "Tb_SignatureModel",
                        principalColumn: "SignatureId");
                    table.ForeignKey(
                        name: "EnrollmentModel_UserModel_FK",
                        column: x => x.UserModel_UserId,
                        principalTable: "Tb_UserModel",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "CityModel__IDX",
                table: "Tb_CityModel",
                column: "StateModel_StateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EnrollmentModel__IDX",
                table: "Tb_EnrollmentModel",
                column: "AppPortifolio_AppId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EnrollmentModel__IDXv1",
                table: "Tb_EnrollmentModel",
                column: "SignatureModel_SignatureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_EnrollmentModel_UserModel_UserId",
                table: "Tb_EnrollmentModel",
                column: "UserModel_UserId");

            migrationBuilder.CreateIndex(
                name: "OrganizationModel__IDX",
                table: "Tb_OrganizationModel",
                column: "CityModel_CityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "SignatureModel__IDX",
                table: "Tb_SignatureModel",
                column: "BillModel_BillId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "SignatureModel__IDXv1",
                table: "Tb_SignatureModel",
                columns: new[] { "OrganizationModel_OrganizationId", "OrganizationModel_CNPJ" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_StateModel_CountryModel_CountryId",
                table: "Tb_StateModel",
                column: "CountryModel_CountryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_UserLogin_UserModel_UserId",
                table: "Tb_UserLogin",
                column: "UserModel_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_UserModel_RoleModel_RoleId",
                table: "Tb_UserModel",
                column: "RoleModel_RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_EnrollmentModel");

            migrationBuilder.DropTable(
                name: "Tb_UserLogin");

            migrationBuilder.DropTable(
                name: "AppPortifolio");

            migrationBuilder.DropTable(
                name: "Tb_SignatureModel");

            migrationBuilder.DropTable(
                name: "Tb_UserModel");

            migrationBuilder.DropTable(
                name: "Tb_BillModel");

            migrationBuilder.DropTable(
                name: "Tb_OrganizationModel");

            migrationBuilder.DropTable(
                name: "Tb_RoleModel");

            migrationBuilder.DropTable(
                name: "Tb_CityModel");

            migrationBuilder.DropTable(
                name: "Tb_StateModel");

            migrationBuilder.DropTable(
                name: "Tb_CountryModel");
        }
    }
}
