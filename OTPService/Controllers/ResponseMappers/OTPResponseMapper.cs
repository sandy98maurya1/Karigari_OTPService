using Models;
using System;
using Utility;

namespace OTPService.Controllers.ResponseMappers
{
    public static class OTPResponseMapper
    {
        public static OTPResponse GetOtpResponse(this OTPResponse response)
        {
            if(response != null)
            {
                return new OTPResponse
                {
                    Id = response.Id,
                    Contact = response.Contact,
                    IsOtpVerified = response.IsOtpVerified,
                };
            }
            return new OTPResponse();
        }

        public static OTPResponse ValidateRequest(this OtpRequest request)
        {
            if (request == null)
            {
                return new OTPResponse()
                {
                    IsOtpVerified = false,
                    Contact = request.ContactNo,
                    ErrorMessage = Messages.BadRequest,
                };
            }

            if (request.ContactNo == null)
            {
                return new OTPResponse()
                {
                    IsOtpVerified = false,
                    Contact = request.ContactNo,
                    ErrorMessage = string.Format(Messages.RequiredData, "Contact Number ")
                };
            }

            return new OTPResponse();
        }

        public static OTPResponse OTPExpireResponse(this OtpRequest request)
        {
            return new OTPResponse()
            {
                IsOtpVerified = false,
                Contact = request.ContactNo,
                ErrorMessage = Messages.OTPExpired,
            };
        }

        public static string CacheExceptionResponse(this Exception ex)
        {
            return ex.Message;
        }
    }
}
