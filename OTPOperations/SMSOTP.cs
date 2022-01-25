using System;
using System.Collections.Generic;
using System.Text;

namespace OTPGenerator
{
    public static class SMSOTP
    {
        public static string GenerateSMSOtp(string contact)
        {
            try
            {
                string otp = UtilitFunctions.GenerateRandomNo(100001,999999).ToString();

                // Find your Account Sid and Auth Token at twilio.com/user/account  
                const string accountSid = "AXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
                const string authToken = "6XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
                
                return otp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
