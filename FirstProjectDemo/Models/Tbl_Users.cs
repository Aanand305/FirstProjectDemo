using System;

namespace FirstProjectDemo.Models
{
    public class Tbl_Users
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
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
