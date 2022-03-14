using FirstProjectDemo.Models.Repository.Interface;
using FirstProjectDemo.Utils.Enums;
using FirstProjectDemo.ViewModel;
using System.Linq;

namespace FirstProjectDemo.Models.Repository.Services
{
    public class AccountService : IUsers
    {
        private ProjectDbContext dbContext;
        public AccountService()
        {
            dbContext = new ProjectDbContext();

        }
        public SignInEnum SignIn(SignInModel model)
        {
            var user = dbContext.Tbl_Users.SingleOrDefault(e => e.Email == model.Email && e.Password == model.Password);
            if(user!=null)
            {
                if(user.IsVarified)
                {
                    if(user.IsActive)
                    {
                        return SignInEnum.Success;
                    }
                    else
                    {
                        return SignInEnum.InActive;
                    }
                }
                else
                {
                    return SignInEnum.NotVarified;
                }
            }
            else
            {
                return SignInEnum.WrongCrendentials;
            }
        }

        public SignUpEnum SignUp(SignUpModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
