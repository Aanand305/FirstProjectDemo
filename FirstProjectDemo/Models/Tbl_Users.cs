using System;

namespace FirstProjectDemo.Models
{
    public class Tbl_User
    {
        public int id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Profile_img { get; set; }
        public bool IsActive { get; set; }
        public bool IsVarified { get; set; }
        public DateTime Created_On { get; set; }
        public DateTime Updated_On { get; set; }
    }
}
