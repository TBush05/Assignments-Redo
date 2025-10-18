using System;
using System.Linq;

namespace PasswordStrength
{
    public static class PasswordStrength
    {
        public enum StrengthLevel
        {
            INELIGABLE,
            WEAK,
            MEDIUM,
            STRONG
        }

        public static StrengthLevel CheckPasswordStrength(string password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));

            bool hasUpper = password.Any(char.IsUpper);
            bool hasLower = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSymbol = password.Any(ch => !char.IsLetterOrDigit(ch));

            int criteriaMet = 0;
            if (hasUpper) criteriaMet++;
            if (hasLower) criteriaMet++;
            if (hasDigit) criteriaMet++;
            if (hasSymbol) criteriaMet++;

            return criteriaMet switch
            {
                0 => StrengthLevel.INELIGABLE,
                1 => StrengthLevel.WEAK,
                2 or 3 => StrengthLevel.MEDIUM,
                4 => StrengthLevel.STRONG,
                _ => StrengthLevel.INELIGABLE,
            };
        }
    }
}
