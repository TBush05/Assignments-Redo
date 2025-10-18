using System;
using PasswordStrengthCheckerLib;
using Xunit;

namespace PasswordStrengthTest
{
    public class PasswordStrengthTests
    {
        [Theory]
        [InlineData(null)]
        public void CheckPasswordStrength_Null_ThrowsArgumentNullException(string password)
        {
            Assert.Throws<ArgumentNullException>(() => PasswordStrength.CheckPasswordStrength(password));
        }

        [Theory]
        [InlineData("", PasswordStrength.StrengthLevel.INELIGABLE)]
        [InlineData("123456", PasswordStrength.StrengthLevel.WEAK)] // only digits
        [InlineData("abcdef", PasswordStrength.StrengthLevel.WEAK)] // only lowercase
        [InlineData("ABCDEF", PasswordStrength.StrengthLevel.WEAK)] // only uppercase
        [InlineData("!@#$%", PasswordStrength.StrengthLevel.WEAK)] // only symbols
        [InlineData("abc123", PasswordStrength.StrengthLevel.MEDIUM)] // lowercase + digit
        [InlineData("ABC123", PasswordStrength.StrengthLevel.MEDIUM)] // uppercase + digit
        [InlineData("ABCdef", PasswordStrength.StrengthLevel.MEDIUM)] // uppercase + lowercase
        [InlineData("abc!@#", PasswordStrength.StrengthLevel.MEDIUM)] // lowercase + symbol
        [InlineData("123!@#", PasswordStrength.StrengthLevel.MEDIUM)] // digit + symbol
        [InlineData("Abc1", PasswordStrength.StrengthLevel.MEDIUM)] // upper + lower + digit
        [InlineData("Abc!", PasswordStrength.StrengthLevel.MEDIUM)] // upper + lower + symbol
        [InlineData("A1!", PasswordStrength.StrengthLevel.MEDIUM)] // upper + digit + symbol
        [InlineData("a1!", PasswordStrength.StrengthLevel.MEDIUM)] // lower + digit + symbol
        [InlineData("Abc1!", PasswordStrength.StrengthLevel.STRONG)] // all criteria
        public void CheckPasswordStrength_ReturnsExpectedStrength(string password, PasswordStrength.StrengthLevel expected)
        {
            var result = PasswordStrength.CheckPasswordStrength(password);
            Assert.Equal(expected, result);
        }
    }
}
