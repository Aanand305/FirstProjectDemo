using FirstProjectDemo.Utils.Enums;
using FirstProjectDemo.ViewModel;

namespace FirstProjectDemo.Models.Repository.Interface
{
    public interface IUsers
    {
        SignInEnum SignIn(SignInModel model);
        SignUpEnum SignUp(SignUpModel model);
    }
}
