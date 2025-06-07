namespace DELFOS.JWT.SSO.MODELS
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() {UserId=1, UserName="José_Admin", EmailAddress="jose.neves@msxserver.com",
                Password="MinhaSenha#01",GivenName="José",Surname="Neto",RoleName="Administrador"},
            new UserModel() {UserId=2, UserName="João_Vendedor", EmailAddress="joao.silva@msxserver.com",
                Password="SenhaDoJoao#01",GivenName="João",Surname="Silva",RoleName="Vendedor"}
        };
    }
}
