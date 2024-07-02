using System.Text.RegularExpressions;

namespace App.Shared.Helper.Validations
{
    public class ValidationClass
    {
        public static bool IsValidId(int id)
        {
            if (id <= 0)
                return false;
            else
                return true;
        }

        public static bool IsValidString(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;
            else
                return true;
        }

        public static bool IsValidStringLength(string str, int length)
        {
            if (str.Length > length)
                return false;
            else
                return true;
        }

        public static bool IsValidHexCode(string code)
        {
            string pattern = @"^#([a-fA-F0-9]{6}|[a-fA-F0-9]{8})$";
            Regex regex = new(pattern);

            if (code.Length > 9)
                return false;

            if (!regex.IsMatch(code))
                return false;
            return true;
        }
    }
}