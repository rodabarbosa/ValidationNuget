using System;
using System.Collections.Generic;
using Sirb.Validation.Documents.BR.Rules;
using Sirb.Validation.Extensions;

namespace Sirb.Validation.Documents.BR.Mockups
{
    /// <summary>
    /// Generated Renavam  value
    /// </summary>
    public static class Renavam
    {
        private static readonly Random _random = new Random();

        /// <summary>
        /// Gera número Renavam
        /// </summary>
        /// <returns></returns>
        public static string Generate()
        {
            int[] generatedNumbers = GenerateNumbers();
            return generatedNumbers.ConvertToString();
        }

        private static int[] GenerateNumbers()
        {
            var listInt = new List<int>();

            int length = 10;
            for (int i = 0; i < length; i++)
                listInt.Add(_random.Next(9));

            var reverseList = new List<int>();
            for (int i = length; i > 0; i--)
                reverseList.Add(listInt[i - 1]);

            int total = RenavanRules.GetSummationValue(reverseList);
            int calculatedValue = RenavanRules.CalculateastDigit(total);
            listInt.Add(calculatedValue);
            return listInt.ToArray();
        }
    }
}