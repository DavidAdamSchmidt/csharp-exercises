using System.Text.RegularExpressions;

namespace RegularExpression
{
    public static class Validator
    {
        public static string PhoneNumberPattern
        {
            get
            {
                const string threeDigits = @"(\d{3})";
                const string fourDigits = @"(\d{4})";
                const string separators = @"[\s\-]";

                return $@"^\(?{threeDigits}\)?{separators}?{threeDigits}\-?{fourDigits}$";
            }
        }

        public static bool IsValidName(string name)
        {
            const string letters = "[a-zA-Z]";
            const string whitespace = @"\s";

            var pattern = $"^({letters}+{whitespace}*)+$";

            return Regex.IsMatch(name, pattern);
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, PhoneNumberPattern);
        }

        public static bool IsValidEmailAddress(string emailAddress)
        {
            const string local = @"[\w]+";
            const string domain = @"(\w*\.)+[a-z]{2,3}";

            var pattern = $"^{local}@{domain}$";

            return Regex.IsMatch(emailAddress, pattern);
        }
    }
}
