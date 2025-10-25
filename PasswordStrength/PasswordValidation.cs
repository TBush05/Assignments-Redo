using System;

namespace PasswordValidation
{
    public class PasswordChecker
    {
        // Method to check if the password is valid (minimum length 8)
        public static bool IsValidPassword(string password)
        {
            if (password == null)
                return false;

            return password.Length >= 8;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example passwords to test
            string[] testPasswords = {
                "Password123",   // Valid
                "Pass1",        // Invalid (too short)
                "SecureP@ssw0rd", // Valid
                "12345",        // Invalid (too short)
                "",             // Invalid (empty)
                null            // Invalid (null)
            };

            foreach (var pwd in testPasswords)
            {
                bool isValid = PasswordChecker.IsValidPassword(pwd);
                Console.WriteLine($"Password: {pwd ?? "null",-15} | Valid: {isValid}");
            }
        }
    }
}
