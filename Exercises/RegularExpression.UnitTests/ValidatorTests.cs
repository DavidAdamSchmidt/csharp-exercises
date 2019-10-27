using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RegularExpression.UnitTests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void IsValidName_MixedCaseEnglishLetters_ReturnsTrue()
        {
            const string input = "abcDEfgHiJKLmnOpQrSTUvwxYz";

            var result = Validator.IsValidName(input);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidName_ContainsWhiteSpaces_ReturnsTrue()
        {
            const string input = "ab cdefgh ijklmnopq\trstuvwxyz";

            var result = Validator.IsValidName(input);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidName_StartsWithWhiteSpace_ReturnsFalse()
        {
            const string input = " abcdefghijklmnopqrstuvwxyz";

            var result = Validator.IsValidName(input);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidName_ContainsNonEnglishLetter_ReturnsFalse()
        {
            const string input = "abcdeéfg";

            var result = Validator.IsValidName(input);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidName_ContainsDigit_ReturnsFalse()
        {
            const string input = "abcdefgh123ijk";

            var result = Validator.IsValidName(input);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidPhoneNumber_10Digits_ReturnsTrue()
        {
            const string input = "0123456789";

            var result = Validator.IsValidPhoneNumber(input);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidPhoneNumber_10DigitsHyphenAfter3rdAnd6th_ReturnsTrue()
        {
            const string input = "012-345-6789";

            var result = Validator.IsValidPhoneNumber(input);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidPhoneNumber_10DigitsSpaceAfter3rdHyphenAfter6th_ReturnsTrue()
        {
            const string input = "012 345-6789";

            var result = Validator.IsValidPhoneNumber(input);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidPhoneNumber_10DigitsSpaceAfter3rdAnd6th_ReturnsFalse()
        {
            const string input = "012 345 6789";

            var result = Validator.IsValidPhoneNumber(input);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidPhoneNumber_11Digits_ReturnsFalse()
        {
            const string input = "01234567890";

            var result = Validator.IsValidPhoneNumber(input);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidEmailAddress_LocalContainsUnderscore_ReturnsTrue()
        {
            const string input = "mentor_007@example.com";

            var result = Validator.IsValidEmailAddress(input);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidEmailAddress_DomainContainsMultipleDots_ReturnsTrue()
        {
            const string input = "BugsBunny@looney.toons.io";

            var result = Validator.IsValidEmailAddress(input);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidEmailAddress_MissingAtSign_ReturnsFalse()
        {
            const string input = "missing_at_sign.example.com";

            var result = Validator.IsValidEmailAddress(input);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidEmailAddress_LocalContainsDot_ReturnsFalse()
        {
            const string input = "duffy.duck@withperiod.com";

            var result = Validator.IsValidEmailAddress(input);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidEmailAddress_EndOfDomainIsTooLong_ReturnsFalse()
        {
            const string input = "elmer_fudd@long.domain";

            var result = Validator.IsValidEmailAddress(input);

            Assert.IsFalse(result);
        }
    }
}
