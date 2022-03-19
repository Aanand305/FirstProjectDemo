using System;

namespace FirstProjectDemo.Models
{
    public class VarifyAccount
    {
        public int id { get; set; }
        public string Otp { get; set; }
        public string UserId { get; set; }
        public DateTime? Sendtime { get; set; }
    }
}
