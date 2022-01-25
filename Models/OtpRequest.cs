
namespace Models
{
    public class OtpRequest
    {
        public string ContactNo { get; set; }
        public string OTP { get; set; }
        public string? DeviceId { get; set; }
    }
}
