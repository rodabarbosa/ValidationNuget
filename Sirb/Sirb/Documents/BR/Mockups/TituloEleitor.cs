using System;
using System.Collections.Generic;
using Sirb.Extensions;

namespace Sirb.Documents.BR.Mockups
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
            int[] generatedNumbers = GenerateNumbers();
            return generatedNumbers.ConvertToString();
        }

        private static int[] GenerateNumbers()
        {
            List<int> generatedNumbers = new List<int>();
            Random random = new Random();

            int total = 0;
            for (int i = 0; i < 8; i++)
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
            bool validDigits = false;
            int ninethDigit = 0;
            int tenthDigit = 0;
            int eleventhDigit = GetDigitValue(total);
            int twelfth = 0;
            int stateDigit;
            while (!validDigits)
            {
                ninethDigit = random.Next(10);
                tenthDigit = random.Next(10);
                stateDigit = int.Parse($"{ninethDigit}{tenthDigit}");
                if (!(stateDigit > 0 && stateDigit < 29))
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
            int remainder = valueSummation % 11;
            return remainder > 9 ? 0 : remainder;
        }
    }
}
