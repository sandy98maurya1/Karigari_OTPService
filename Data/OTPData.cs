using Contracts.DataContracts;
using Dapper;
using Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class OTPData : IOTPData
    {
        IConfiguration _configuration;
        internal string connection { get; set; }

        public OTPData(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = GetConnection();
        }

        public OTPResponse GetOtpByContact(string contact, string Otp)
        {

            OTPResponse response = new OTPResponse();
            using (var dbConnection = new SqlConnection(connection))
            {
                try
                {
                    dbConnection.Open();
                    string sql = "Select Contact, OtpCreationDate, OTP, DeviceId from OTP Where Contact = @Contact AND OTP = @OTP";
                    response = dbConnection.Query<OTPResponse>(sql, new { @Contact = contact, @OTP = Otp }).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dbConnection.Close();
                }

                return response;
            }
        }

        public OTPResponse SaveOTP(OtpRequest model)
        {
            OTPResponse response = new OTPResponse();

            using (var dbConnection = new SqlConnection(connection))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    string sql = "Insert INTO OTP(Contact, OtpCreationDate,OTP, DeviceId) values (@Contact, @OtpCreationDate,@OTP, @DeviceId) ;";
                    var count = dbConnection.Execute(sql, new { @Contact = model.ContactNo, @OtpCreationDate = DateTime.Now, @OTP = model.OTP, @DeviceId = model.DeviceId }, transaction: transaction);
                    transaction.Commit();
                }
                response.Contact=model.ContactNo;
                response.Otp=model.OTP;
                response.DeviceId=model.DeviceId;
                response.OtpCreationDate=DateTime.Now;
            }

            return response;
        }

        public OTPResponse UpdateOTP(OtpRequest model)
        {
            OTPResponse response = new OTPResponse();

            using (var dbConnection = new SqlConnection(connection))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    string sql = " update OTP set Contact=@Contact, OtpCreationDate=@OtpCreationDate,OTP=@OTP, DeviceId=@DeviceId";
                    var count = dbConnection.Execute(sql, new { @Contact = model.ContactNo, @OtpCreationDate = DateTime.Now, @OTP = model.OTP, @DeviceId = model.DeviceId }, transaction: transaction);
                    transaction.Commit();
                }
                response.Contact = model.ContactNo;
                response.Otp = model.OTP;
                response.DeviceId = model.DeviceId;
                response.OtpCreationDate = DateTime.Now;
            }

            return response;
        }

        private string GetConnection()
        {
            return _configuration.GetSection("ConnectionStrings").GetSection("ProductContext").Value;

        }
    }
}
