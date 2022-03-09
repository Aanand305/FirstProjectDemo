using System;

namespace FirstProjectDemo.Models
{
    public class VarifyAccount
    {
        public int id { get; set; }
        public string Otp { get; set; }
        public int UserId { get; set; }
        public DateTime SendTime { get; set; }
    }
}
