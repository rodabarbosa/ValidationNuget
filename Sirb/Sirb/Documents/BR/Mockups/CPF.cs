using System;
using System.Collections.Generic;
using Sirb.Documents.BR.Enumeration;
using Sirb.Documents.BR.Rules;
using Sirb.Extensions;

namespace Sirb.Documents.BR.Mockups
{
    /// <summary>
    /// Gerador de número CPF
    /// </summary>
    public static class Cpf
    {
        private static readonly Random _random = new Random();

        /// <summary>
        /// Gera número CPF
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static string Generate(State? state = null)
        {
            if (state == null)
                state = GetRandomState();

            int[] generatedNumbers = GenerateNumbers(state.Value);
            return generatedNumbers.ConvertToString();
        }

        private static State GetRandomState()
        {
            return (State)_random.Next(10);
        }

        private static int[] GenerateNumbers(State state)
        {
            List<int> generatedNumbers = new List<int>();

            int totalBeforeLastDigit = 0;
            int totalLastDigit = 0;
            for (int i = 0; i < 9; i++)
            {
                generatedNumbers.Add(i < 8 ? _random.Next(10) : (int)state);
                totalBeforeLastDigit += generatedNumbers[generatedNumbers.Count - 1] * CpfRule.CalculateBeforeLastDigitWeight(i);
                totalLastDigit += generatedNumbers[generatedNumbers.Count - 1] * CpfRule.CalculateLastDigitWeight(i);
            }

            generatedNumbers.Add(CalculateDigitValue(totalBeforeLastDigit));
            totalLastDigit += generatedNumbers[generatedNumbers.Count - 1] * 2;

            generatedNumbers.Add(CalculateDigitValue(totalLastDigit));

            return generatedNumbers.ToArray();
        }

        private static int CalculateDigitValue(int valueSummation)
        {
            int remainder = valueSummation % 11;
            int subtractionValue = remainder < 2 ? 0 : 11;
            return subtractionValue - remainder;
        }
    }
}
