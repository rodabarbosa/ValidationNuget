using Sirb.Validation.Documents.BR.Rules;
using Sirb.Validation.Extensions;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sirb.Validation.Documents.BR.Validation
{
    /// <summary>
    /// CNPJ
    /// </summary>
    public static class CnpjValidation
    {
        /// <summary>
        /// Validador de CNPJ
        /// </summary>
        /// <param name="value">CNPJ</param>
        /// <returns></returns>
        public static bool IsValid(string value)
        {
            var aux = value.RemoveMask();
            if (!HasValidParams(aux))
                return false;

            var sums = GetSum(aux);

            var beforeLastDigit = CnpjRule.CalculateDigitValue(sums[0]);
            var lastDigit = CnpjRule.CalculateDigitValue(sums[1]);

            var lastTwoDigits = beforeLastDigit + lastDigit.ToString();
            return aux.EndsWith(lastTwoDigits);
        }

        private static bool HasValidParams(string value)
        {
            var invalidNumbers = new List<string>
            {
                "00000000000000",
                "11111111111111",
                "22222222222222",
                "33333333333333",
                "44444444444444",
                "55555555555555",
                "66666666666666",
                "77777777777777",
                "88888888888888",
                "99999999999999"
            };

            return !(string.IsNullOrEmpty(value) || value.Length != 14 || invalidNumbers.Contains(value));
        }

        private static int[] GetSum(string value)
        {
            int[] sums = { 0, 0 };

            for (var i = 0; i < 12; i++)
            {
                sums[0] += int.Parse(value[i].ToString()) * CnpjRule.CalculateBeforeLastDigitWeight(i);
                sums[1] += int.Parse(value[i].ToString()) * CnpjRule.CalculateLastDigitWeight(i);
            }

            sums[1] += int.Parse(value[12].ToString()) * 2;

            return sums;
        }

        /// <summary>
        /// Adiciona mascara ao CNPJ
        /// </summary>
        /// <param name="value">CNPJ number</param>
        /// <returns></returns>
        public static string PlaceMask(string value)
        {
            return string.IsNullOrEmpty(value?.Trim())
                ? default
                : Regex.Replace(value.RemoveMask(), @"(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})", "$1.$2.$3/$4-$5");
        }
    }
}
