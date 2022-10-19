using Sirb.Validation.Extensions;
using System;
using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups
{
    /// <summary>
    /// Gerador de número Título de Eleitor
    /// </summary>
    public static class TituloEleitor
    {
        /// <summary>
        /// Gera número Titulo de Eleitor
        /// </summary>
        /// <returns></returns>
        public static string Generate()
        {
            var generatedNumbers = GenerateNumbers();
            return generatedNumbers.ConvertToString();
        }

        private static int[] GenerateNumbers()
        {
            var generatedNumbers = new List<int>();
            var random = new Random();

            var total = 0;
            for (var i = 0; i < 8; i++)
            {
                generatedNumbers.Add(random.Next(10));
                total += generatedNumbers[generatedNumbers.Count - 1] * CalculateWeight(i);
            }

            GenerateAndIncludeCalculatedDigits(generatedNumbers, random, total);

            return generatedNumbers.ToArray();
        }

        private static int CalculateWeight(int index)
        {
            return index + 2;
        }

        private static void GenerateAndIncludeCalculatedDigits(List<int> generatedNumbers, Random random, int total)
        {
            var validDigits = false;
            var ninethDigit = 0;
            var tenthDigit = 0;
            var eleventhDigit = GetDigitValue(total);
            var twelfth = 0;
            while (!validDigits)
            {
                ninethDigit = random.Next(10);
                tenthDigit = random.Next(10);
                var stateDigit = int.Parse($"{ninethDigit}{tenthDigit}");
                var digitInValidRange = stateDigit >= 1 && stateDigit <= 28;
                if (!digitInValidRange)
                    continue;

                total = ninethDigit * 7 + tenthDigit * 8 + eleventhDigit * 9;
                twelfth = GetDigitValue(total);
                validDigits = true;
            }

            generatedNumbers.Add(ninethDigit);
            generatedNumbers.Add(tenthDigit);
            generatedNumbers.Add(eleventhDigit);
            generatedNumbers.Add(twelfth);
        }

        private static int GetDigitValue(int valueSummation)
        {
            var remainder = valueSummation % 11;
            return remainder > 9 ? 0 : remainder;
        }
    }
}
