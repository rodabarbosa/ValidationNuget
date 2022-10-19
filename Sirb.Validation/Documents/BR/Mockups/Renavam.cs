using Sirb.Validation.Documents.BR.Rules;
using Sirb.Validation.Extensions;
using System;
using System.Collections.Generic;

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
            var generatedNumbers = GenerateNumbers();
            return generatedNumbers.ConvertToString();
        }

        private static int[] GenerateNumbers()
        {
            var listInt = new List<int>();

            var length = 10;
            for (var i = 0; i < length; i++)
                listInt.Add(_random.Next(9));

            var reverseList = new List<int>();
            for (var i = length; i > 0; i--)
                reverseList.Add(listInt[i - 1]);

            var total = RenavanRules.GetSummationValue(reverseList);
            var calculatedValue = RenavanRules.CalculateastDigit(total);
            listInt.Add(calculatedValue);
            return listInt.ToArray();
        }
    }
}
