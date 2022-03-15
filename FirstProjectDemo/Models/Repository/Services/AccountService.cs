using FirstProjectDemo.Models.Repository.Interface;
using FirstProjectDemo.Utils.Enums;
using FirstProjectDemo.ViewModel;
using System;
using System.Linq;
using System.Net.Mail;

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
            if (dbContext.Tbl_Users.Any(e => e.Email == model.Email))
            {
                return SignUpEnum.EmailExist;
            }
            else
            {
                var user = new Tbl_User()
                {
                    Fname = model.Fname,
                    Lname = model.Lname,
                    Email = model.Email,
                    Password = model.ConfirmPassword,
                    Gender = model.Gender,
                };
                dbContext.Tbl_Users.Add(user);
                dbContext.SaveChanges();
            }
            
        }

        private void SendMail(string to, string otp)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress("");
            mail.Subject = "Verify Your Account";
            string Body = $"your otp is<b>{otp}</b> <br/> thanks for choosing us";
            mail.Body = Body;
            mail.IsBodyHtml= true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "";
            smtp.Port = 587;
            smtp.UseDefaultCredentials=false;
            smtp.Credentials = new System.Net.NetworkCredential("demo3400@gmail.com", "your password");
            smtp.EnableSsl = true;
            smtp.Send(mail);

        }

        private string GenerateOTP()
        {
            var chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var random = new Random();
            var list = new Enumerable.Repeat(0, 8).select(x => chars[random.next(chars.length)]);
            var r = string.Join("", list);
        }
    }
}
