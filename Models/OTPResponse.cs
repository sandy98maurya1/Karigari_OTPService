using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OTPResponse
    {
        public int Id { get; set; }
        public string Contact { get; set; }
        public bool IsOtpVerified { get; set; }
        public DateTime OtpCreationDate { get; set; }  
        public string ErrorMessage { get; set; }
    }
}

