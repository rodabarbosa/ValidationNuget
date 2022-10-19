using Sirb.Validation.Documents.BR.Rules;
using Sirb.Validation.Extensions;
using System.Text.RegularExpressions;

namespace Sirb.Validation.Documents.BR.Validation
{
    /// <summary>
    /// PIS
    /// </summary>
    public static class PisValidation
    {
        /// <summary>
        /// Validador de PIS
        /// </summary>
        /// <param name="value">PIS</param>
        /// <returns></returns>
        public static bool IsValid(string value)
        {
            var aux = RemoveMask(value);
            if (string.IsNullOrEmpty(aux) || aux.Length != 11)
                return false;

            var sum = GetSum(aux);
            var lastDigit = PisRule.CalculateLastDigit(sum);
            return value.EndsWith(lastDigit.ToString());
        }

        private static int GetSum(string value)
        {
            var sum = 0;
            for (var i = 0; i < 10; i++)
            {
                sum += int.Parse(value[i].ToString()) * PisRule.CalculateWeight(i);
            }

            return sum;
        }

        /// <summary>
        /// Remove mascara do PIS
        /// </summary>
        /// <param name="value">PIS</param>
        /// <returns></returns>
        public static string RemoveMask(string value)
        {
            return value?.OnlyNumbers();
        }

        /// <summary>
        /// Adiciona mascara no PIS
        /// </summary>
        /// <param name="value">PIS</param>
        /// <returns></returns>
        public static string PlaceMask(string value)
        {
            if (string.IsNullOrEmpty(value?.Trim()))
                return default;

            return Regex.Replace(RemoveMask(value), @"(\d{3})(\d{5})(\d{2})(\d{1})", "$1.$2.$3/$4");
        }
    }
}
