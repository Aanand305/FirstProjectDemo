using FirstProjectDemo.Utils.Enum;
using FirstProjectDemo.ViewModel;

namespace FirstProjectDemo.Models.Repository.Interface
{
    public interface IUsers
    {
        SignInEnums SignIn(SignInModel model);
        SignUpEnums SignUp(SignUpModel model);
    }
}
