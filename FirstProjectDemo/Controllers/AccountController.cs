using FirstProjectDemo.Models.Repository.Interface;
using FirstProjectDemo.Utils.Enums;
using FirstProjectDemo.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;


namespace FirstProjectDemo.Controllers
{
    public class AccountController : Controller
    {
        private IUsers userservice;
        public AccountController(IUsers users)
        {
            this.userservice = users; 

        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(SignInModel model)
        {
            if(ModelState.IsValid)
            {
                var result = userservice.SignIn(model);
                if(result==SignInEnum.Success)
                {
                    //A claim is a statement about a subject by an issuer and    
                    //represent attributes of the subject that are useful in the context of authentication and authorization operations.    
                    var claims = new List<Claim>() 
                    {
                    new Claim(ClaimTypes.Name,model.Email),
                      
                    };
                    //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                    var principal = new ClaimsPrincipal(identity);
                    //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                    {
                        IsPersistent = model.RememberMe
                    }) ;
                    return RedirectToAction("Index", "Home");

                }
                else if(result==SignInEnum.NotVarified)
                {
                    ModelState.AddModelError(string.Empty, "Account is not Varified");

                }
                else if(result==SignInEnum.WrongCrendentials)
                {
                    ModelState.AddModelError(string.Empty, "Wrong Crendentials");

                }
                else if(result==SignInEnum.InActive)
                {
                    ModelState.AddModelError(string.Empty, "Account is InActive");

                }

            }
            return View(model);

        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(SignUpModel model)
        {
            if(ModelState.IsValid)
            {
                var result = userservice.SignUp(model);
                if(result==SignUpEnum.Success)
                {
                    return RedirectToAction("VarifyAccount");
                }
                else if(result==SignUpEnum.EmailExist)
                {
                    ModelState.AddModelError(string.Empty, "Email already Exist, please use another Email !!");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Something Went Wrong");
                }

            }
            return View(model);

        }

        public IActionResult VarifyAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VarifyAccount(string otp)
        {
            if(otp!=null)
            {
                if(userservice.VarifyAccount(otp))
                {
                    return RedirectToAction("Login");

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Please Enter Correct OTP !");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Please Enter OTP !");
            }
            return View();
        }

    }
}
