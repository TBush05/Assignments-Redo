using Xunit;
using PasswordValidation;

namespace PasswordValidationTest
{
    public class PasswordCheckerTests
    {
        [Fact]
        public void Password_WithLengthGreaterThan8_ShouldBeValid()
        {
            Assert.True(PasswordChecker.IsValidPassword("Password123"));
        }

        [Fact]
        public void Password_WithLengthExactly8_ShouldBeValid()
        {
            Assert.True(PasswordChecker.IsValidPassword("12345678"));
        }

        [Fact]
        public void Password_WithLengthLessThan8_ShouldBeInvalid()
        {
            Assert.False(PasswordChecker.IsValidPassword("Pass1"));
        }

        [Fact]
        public void Password_WithEmptyString_ShouldBeInvalid()
        {
            Assert.False(PasswordChecker.IsValidPassword(""));
        }

        [Fact]
        public void Password_WithNull_ShouldBeInvalid()
        {
            Assert.False(PasswordChecker.IsValidPassword(null));
        }
    }
}
