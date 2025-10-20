namespace PasswordValidationTest
{
    public class PasswordChecker
    {
        public static bool IsValidPassword(string password)
        {
            if (password == null)
                return false;

            return password.Length >= 8;
        }
    }
}
