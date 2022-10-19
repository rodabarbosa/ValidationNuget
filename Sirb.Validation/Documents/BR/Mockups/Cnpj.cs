using Sirb.Validation.Documents.BR.Rules;
using Sirb.Validation.Extensions;
using System;
using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups
{
    /// <summary>
    /// Gerador de número CNPJ
    /// </summary>
    public static class Cnpj
    {
        private static readonly Random _random = new Random();

        /// <summary>
        /// Gera número CNPJ
        /// </summary>
        /// <returns></returns>
        public static string Generate()
        {
            var generatedNumbers = GenerateNumbers();
            return generatedNumbers.ConvertToString();
        }

        private static int[] GenerateNumbers()
        {
            var generatedNambers = new List<int>();

            var totalTBeforeLastDigit = 0;
            var totalLastDigit = 0;

            for (var i = 0; i < 12; i++)
            {
                generatedNambers.Add(_random.Next(10));
                var index = generatedNambers.Count - 1;

                totalTBeforeLastDigit += generatedNambers[index] * CnpjRule.CalculateBeforeLastDigitWeight(i);
                totalLastDigit += generatedNambers[index] * CnpjRule.CalculateLastDigitWeight(i);
            }

            generatedNambers.Add(CnpjRule.CalculateDigitValue(totalTBeforeLastDigit));
            var indexLastDigit = generatedNambers.Count - 1;
            totalLastDigit += generatedNambers[indexLastDigit] * 2;

            generatedNambers.Add(CnpjRule.CalculateDigitValue(totalLastDigit));

            return generatedNambers.ToArray();
        }
    }
}
