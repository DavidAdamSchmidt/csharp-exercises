using System.Text.RegularExpressions;

namespace RegularExpression
{
    public static class Validator
    {
        public static bool IsValidName(string name)
        {
            const string letters = "[a-zA-Z]";
            const string whitespace = @"\s";

            var pattern = $"^({letters}+{whitespace}*)+$";

            return Regex.IsMatch(name, pattern);
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            const string threeDigits = @"(\d{3})";
            const string fourDigits = @"(\d{4})";
            const string separators = @"[\s\-]";

            var pattern = $@"^\(?{threeDigits}\)?{separators}?{threeDigits}\-?{fourDigits}$";

            return Regex.IsMatch(phoneNumber, pattern);
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
