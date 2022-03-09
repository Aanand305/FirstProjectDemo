using FirstProjectDemo.Models.Repository.Interface;
using FirstProjectDemo.Utils.Enum;
using FirstProjectDemo.ViewModel;

namespace FirstProjectDemo.Models.Repository.Services
{
    public class AccountService : IUsers
    {
        private ProjectDbContext context;
        public AccountService()
        {
            context=new ProjectDbContext();
           
        }
        public SignInEnums SignIn(SignInModel model)
        {
            throw new System.NotImplementedException();
        }

        public SignUpEnums SignUp(SignUpModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
