using System;
using System.Collections.Generic;
using System.Linq;

namespace Sirb.Validation.Documents.BR.Mockups.Ie
{
    internal sealed class InscricaoEstadualBa : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            var generatedNumbers = new List<int>();

            var length = GetRandomLength(Random);
            var totalLastDigit = 0;
            var totalBeforeLastDigit = 0;
            for (var i = 0; i < length - 2; i++)
            {
                generatedNumbers.Add(Random.Next(10));
                totalLastDigit += generatedNumbers[generatedNumbers.Count - 1] * CalculateBeforeLastWeight(i, length);
                totalBeforeLastDigit += generatedNumbers[generatedNumbers.Count - 1] * CalculateLastWeight(i, length);
            }

            var moduleValue = GetModuloValue(generatedNumbers.ToArray(), length);
            var lastDigit = GetDigitValue(totalLastDigit, moduleValue);
            totalBeforeLastDigit += lastDigit * 2;

            generatedNumbers.Add(GetDigitValue(totalBeforeLastDigit, moduleValue));
            generatedNumbers.Add(lastDigit);

            return generatedNumbers.ToArray();
        }

        private int GetRandomLength(Random random)
        {
            return random.Next(2) == 1 ? 9 : 8;
        }

        private int CalculateBeforeLastWeight(int index, int length)
        {
            var value = length == 8 ? 7 : 8;
            return CalculateWeight(value, index);
        }

        private int CalculateLastWeight(int index, int length)
        {
            var value = length == 8 ? 8 : 9;
            return CalculateWeight(value, index);
        }

        private int GetModuloValue(int[] values, int length)
        {
            int[] validationDigits = { 6, 7, 9 };
            var digitIndex = length == 9 ? 1 : 0;
            return validationDigits.Contains(values[digitIndex]) ? 11 : 10;
        }

        private int GetDigitValue(int summantionValue, int moduleValue)
        {
            var remainder = summantionValue % moduleValue;
            return remainder == 0 || (moduleValue == 11 && remainder == 1) ? 0 : moduleValue - remainder;
        }
    }
}
