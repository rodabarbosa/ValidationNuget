using Sirb.Validation.Documents.BR.Rules;
using Sirb.Validation.Extensions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sirb.Validation.Documents.BR.Validation
{
    /// <summary>
    /// CPF
    /// </summary>
    public static class CpfValidation
    {
        /// <summary>
        /// Validador de CPF
        /// </summary>
        /// <param name="value">CPF</param>
        /// <returns></returns>
        public static bool IsValid(string value)
        {
            var onlyNumbersValue = value.RemoveMask();
            if (!HasValidParams(onlyNumbersValue))
                return false;

            var tenthDigit = GetTenthDigit(onlyNumbersValue);
            var eleventh = GetEleventhDigit(onlyNumbersValue);
            var sums = GetSum(onlyNumbersValue);

            var tenthDigitComparison = GetModulusForDigitComparison(sums[0]);
            var eleventhDigitComparison = GetModulusForDigitComparison(sums[1]);

            return tenthDigitComparison == tenthDigit && eleventhDigitComparison == eleventh;
        }

        private static bool HasValidParams(string value)
        {
            var invalidNumbers = new List<string>
            {
                "00000000000",
                "11111111111",
                "22222222222",
                "33333333333",
                "44444444444",
                "55555555555",
                "66666666666",
                "77777777777",
                "88888888888",
                "99999999999"
                //"01234567890"
            };

            return !(string.IsNullOrEmpty(value) || value.Length != 11 || invalidNumbers.Contains(value));
        }

        private static int GetTenthDigit(string onlyNumbersValue)
        {
            return int.Parse(onlyNumbersValue.Substring(9, 1));
        }

        private static int GetEleventhDigit(string onlyNumbersValue)
        {
            return int.Parse(onlyNumbersValue.Substring(10));
        }

        private static int GetModulusForDigitComparison(int summationValue)
        {
            var value = summationValue * 10 % 11;
            if (value == 10)
                value = 0;

            return value;
        }

        private static int[] GetSum(string onlyNumbersValue)
        {
            int[] sums = { 0, 0 };
            for (var i = 0; i < 9; i++)
            {
                var value = int.Parse(onlyNumbersValue[i].ToString());
                sums[0] += value * CpfRule.CalculateBeforeLastDigitWeight(i);
                sums[1] += value * CpfRule.CalculateLastDigitWeight(i);
            }

            sums[1] += GetTenthDigit(onlyNumbersValue) * 2;

            return sums;
        }

        /// <summary>
        /// Adiciona mascara no CPF
        /// </summary>
        /// <param name="value">CPF</param>
        /// <returns></returns>
        public static string PlaceMask(string value)
        {
            if (string.IsNullOrEmpty(value?.Trim()))
                return default;

            return Regex.Replace(value.RemoveMask(), @"(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3-$4");
        }

        /// <summary>
        /// Obtém estado emissor do CPF
        /// </summary>
        /// <param name="value">CPF</param>
        /// <exception cref="InvalidOperationException">CPF deve ser valido</exception>
        /// <returns></returns>
        public static string GetIssuingState(string value)
        {
            if (!IsValid(value))
                throw new InvalidOperationException("Invalid number");

            var aux = value.RemoveMask();
            switch (int.Parse(aux.Substring(8, 1)))
            {
                case 0: return "RS";
                case 1: return "DF, GO, MS, TO";
                case 2: return "AC, AP, AM, PA, RO, RR";
                case 3: return "CE, MA, PI ";
                case 4: return "PE, RN, PB, AL";
                case 5: return "BA, SE";
                case 6: return "MG";
                case 7: return "RJ, ES";
                case 8: return "SP";
                case 9: return "PR, SC";
                default: return "Unknown";
            }
        }
    }
}
