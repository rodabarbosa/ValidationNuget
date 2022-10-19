using Sirb.Validation.Documents.BR.Rules;
using Sirb.Validation.Extensions;

namespace Sirb.Validation.Documents.BR.Validation
{
    /// <summary>
    /// Renavam
    /// </summary>
    public static class RenavamValidation
    {
        /// <summary>
        /// Validador de renavam
        /// </summary>
        /// <param name="value"></param>
        public static bool IsValid(string value)
        {
            var aux = RemoveMask(value);
            if (!HasValidParam(aux))
                return false;

            var normalizedValue = NormalizeValue(aux);
            var workingValue = WorkValue(normalizedValue);
            var total = RenavanRules.GetSummationValue(workingValue);
            var calculatedValue = RenavanRules.CalculateastDigit(total);
            var lastDigit = normalizedValue[normalizedValue.Length - 1].ToString();
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
            var normalizedWithoutLastDigit = value.Substring(0, 10);
            return normalizedWithoutLastDigit.Reverse();
        }

        public static string RemoveMask(string value)
        {
            return value?.OnlyNumbers();
        }
    }
}
