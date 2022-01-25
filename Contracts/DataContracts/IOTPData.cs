using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataContracts
{
    public interface IOTPData
    {
        OTPResponse GetOtpByContact(string contact, string Otp);
        OTPResponse SaveOTP(OtpRequest model);
        OTPResponse UpdateOTP(OtpRequest model);

    }
}
