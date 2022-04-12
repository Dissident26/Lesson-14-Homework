using System.Text.RegularExpressions;

namespace RegExpValidator
{
    public class RegExpValidatorAttribute : Attribute
    {
        string regExp;

        public RegExpValidatorAttribute(string regEx)
        {
            regExp = regEx;
        }
        public bool IsValid(string? value)
        {
            if (value == null)
            {
                return false;
            }

            return Regex.IsMatch(value, regExp, RegexOptions.IgnoreCase);
        }
    }
}