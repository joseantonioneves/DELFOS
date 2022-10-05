namespace DELFOS.JWT.SSO.API.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() {Id=1, UserName="José_Admin", EmailAddress="jose.neves@msxserver.com",
                Password="MinhaSenha#01",GivenName="José",Surname="Neto",Role="Administrador"},
            new UserModel() {Id=2, UserName="João_Vendedor", EmailAddress="joao.silva@msxserver.com",
                Password="SenhaDoJoao#01",GivenName="João",Surname="Silva",Role="Vendedor"}
        };
    }
}
