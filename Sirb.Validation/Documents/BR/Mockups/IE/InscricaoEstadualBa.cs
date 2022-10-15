using System;
using System.Collections.Generic;
using System.Linq;

namespace Sirb.Validation.Documents.BR.Mockups.IE
{
    internal sealed class InscricaoEstadualBa : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            List<int> generatedNumbers = new List<int>();

            int length = GetRandomLength(Random);
            int totalLastDigit = 0;
            int totalBeforeLastDigit = 0;
            for (int i = 0; i < length - 2; i++)
            {
                generatedNumbers.Add(Random.Next(10));
                totalLastDigit += generatedNumbers[generatedNumbers.Count - 1] * CalculateBeforeLastWeight(i, length);
                totalBeforeLastDigit += generatedNumbers[generatedNumbers.Count - 1] * CalculateLastWeight(i, length);
            }

            int moduleValue = GetModuloValue(generatedNumbers.ToArray(), length);
            int lastDigit = GetDigitValue(totalLastDigit, moduleValue);
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
            int digitIndex = length == 9 ? 1 : 0;
            return validationDigits.Contains(values[digitIndex]) ? 11 : 10;
        }

        private int GetDigitValue(int summantionValue, int moduleValue)
        {
            int remainder = summantionValue % moduleValue;
            return remainder == 0 || (moduleValue == 11 && remainder == 1) ? 0 : moduleValue - remainder;
        }
    }
}
