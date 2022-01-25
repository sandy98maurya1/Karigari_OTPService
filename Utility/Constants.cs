using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Utility
{
    public static class Constants
    {
        public static int invalidLoginAttemptsCount { get; set; } = 0;
        public static int MaxLoginAttempts = 3;

        public static string ImagesPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName.ToString() + "\\API\\Assets\\Images\\";

        public const string GRANT_TYPE = "grant_type";
        public const string USER_NAME = "username";
        public const string PASSWORD = "password";
        public const string UserId = "UserId";

        public const string ClaimTypeId = "Id";
        public const string ClaimTypeFullName = "FullName";
        public const string ClaimTypeLastName = "LastName";
        public const string ClaimTypeEmail = "Email";
        public const string ClaimContact = "Contact";
        public const string TokenType = "Bearer";

        public const string AlphaChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string AlphaNumericChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    }
}
