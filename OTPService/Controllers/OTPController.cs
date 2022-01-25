using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using OTPGenerator;
using OTPService.Controllers.ResponseMappers;
using System;
using Utility.LoggerService;

namespace OTPService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OTPController : ControllerBase
    {
        private readonly IOTP otp;
        private readonly ILoggerManager logger;

        public OTPController(IOTP _otp, ILoggerManager _logger)
        {
            otp = _otp;
            logger = _logger;
        }


        [HttpPost, Route("GetOTP")]
        public IActionResult GenerateOTP(OtpRequest request)
        {
            OTPResponse response = new OTPResponse();
            try
            {
                response = OTPResponseMapper.ValidateRequest(request);
                if(response.ErrorMessage != null)
                {
                    return Ok(response);
                }

                request.OTP = SMSOTP.GenerateSMSOtp(request.ContactNo);
                response = otp.SaveOTP(request).GetOtpResponse();

                //TODO: Send OTP via SMS
            }
            catch (Exception ex)
            {
                logger.LogInfo(ex.Message);
                response.ErrorMessage = ex.CacheExceptionResponse();
            }

            return Ok(response);
        }

        [HttpPost, Route("VerifyOTP")]
        public IActionResult VerifyOTP(OtpRequest request)
        {
            OTPResponse response = new OTPResponse();
            try
            {
                response = OTPResponseMapper.ValidateRequest(request);

                if (response.ErrorMessage != null)
                {
                    return Ok(response);
                }

                response = otp.ValidateOTP(request);
                
            }
            catch (Exception ex)
            {
                logger.LogInfo(ex.Message);
                response.ErrorMessage = ex.CacheExceptionResponse();
            }

            return Ok(response);
        }

        
    }
}
