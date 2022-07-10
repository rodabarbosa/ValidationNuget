using System;
using System.Collections.Generic;
using Sirb.Documents.BR.Rules;
using Sirb.Extensions;

namespace Sirb.Documents.BR.Mockups
{
    /// <summary>
    /// Gerador de número PIS
    /// </summary>
    public static class Pis
    {
        private static readonly Random _random = new Random();

        /// <summary>
        /// Gera número PIS
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

            int total = 0;
            for (int i = 0; i < 10; i++)
            {
                generatedNumbers.Add(_random.Next(10));
                total += generatedNumbers[generatedNumbers.Count - 1] * PisRule.CalculateWeight(i);
            }

            generatedNumbers.Add(PisRule.CalculateLastDigit(total));

            return generatedNumbers.ToArray();
        }
    }
}
