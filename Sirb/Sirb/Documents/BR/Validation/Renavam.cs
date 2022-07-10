using Sirb.Documents.BR.Rules;
using Sirb.Extensions;

namespace Sirb.Documents.BR.Validation
{
    /// <summary>
    /// Renavam
    /// </summary>
    public static class Renavam
    {
        /// <summary>
        /// Validador de renavam
        /// </summary>
        /// <param name="value"></param>
        public static bool IsValid(string value)
        {
            string aux = RemoveMask(value);
            if (!HasValidParam(aux))
                return false;

            string normalizedValue = NormalizeValue(aux);
            string workingValue = WorkValue(normalizedValue);
            int total = RenavanRules.GetSummationValue(workingValue);
            int calculatedValue = RenavanRules.CalculateastDigit(total);
            string lastDigit = normalizedValue[normalizedValue.Length - 1].ToString();
            return lastDigit.Equals(calculatedValue.ToString());
        }

        private static bool HasValidParam(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            return value.Length == 9 || value.Length == 11;
        }

        private static string NormalizeValue(string value)
        {
            return value.PadLeft(11, '0');
        }

        private static string WorkValue(string value)
        {
            string normalizedWithoutLastDigit = value.Substring(0, 10);
            return normalizedWithoutLastDigit.Reverse();
        }

        public static string RemoveMask(string value)
        {
            return string.IsNullOrEmpty(value) ? value : value.OnlyNumbers();
        }
    }
}
