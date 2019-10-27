using System;
using System.Text.RegularExpressions;

namespace RegularExpression
{
    public static class Formatter
    {
        public static string ReformatPhoneNumber(string phoneNumber)
        {
            if (!Validator.IsValidPhoneNumber(phoneNumber))
            {
                throw new ArgumentException($"The provided phone number '{phoneNumber}' is invalid.");
            }

            var match = Regex.Match(phoneNumber, Validator.PhoneNumberPattern);
            var groups = match.Groups;

            return $"({groups[1]}) {groups[2]}-{groups[3]}";
        }
    }
}
