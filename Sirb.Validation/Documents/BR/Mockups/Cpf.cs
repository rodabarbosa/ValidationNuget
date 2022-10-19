using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Rules;
using Sirb.Validation.Extensions;
using System;
using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups
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
        public static string Generate(State? state = null)
        {
            if (state == null)
            {
                state = GetRandomState();
            }

            var generatedNumbers = GenerateNumbers(state.Value);
            return generatedNumbers.ConvertToString();
        }

        private static State GetRandomState()
        {
            return (State)_random.Next(10);
        }

        private static int[] GenerateNumbers(State state)
        {
            var generatedNumbers = new List<int>();

            var totalBeforeLastDigit = 0;
            var totalLastDigit = 0;
            for (var i = 0; i < 9; i++)
            {
                generatedNumbers.Add(i < 8 ? _random.Next(10) : (int)state);
                var index = generatedNumbers.Count - 1;

                totalBeforeLastDigit += generatedNumbers[index] * CpfRule.CalculateBeforeLastDigitWeight(i);
                totalLastDigit += generatedNumbers[index] * CpfRule.CalculateLastDigitWeight(i);
            }

            var beforeLastDigit = GetBeforeLastDigit(generatedNumbers, totalBeforeLastDigit);
            generatedNumbers.Add(beforeLastDigit);

            var lastDigit = GetLastDigit(generatedNumbers, totalLastDigit);
            generatedNumbers.Add(lastDigit);

            return generatedNumbers.ToArray();
        }

        private static int GetBeforeLastDigit(List<int> generatedNumbers, int total)
        {
            return CalculateDigitValue(total);
        }

        private static int CalculateDigitValue(int valueSummation)
        {
            var remainder = valueSummation % 11;
            var subtractionValue = remainder < 2 ? 0 : 11;
            return subtractionValue - remainder;
        }

        private static int GetLastDigit(List<int> generatedNumbers, int total)
        {
            var totalLastDigit = total + GetValueToSumForLasDigit(generatedNumbers);
            return CalculateDigitValue(totalLastDigit);
        }

        private static int GetValueToSumForLasDigit(List<int> generatedNumbers)
        {
            var indexLastDigit = generatedNumbers.Count - 1;
            return generatedNumbers[indexLastDigit] * 2;
        }
    }
}
