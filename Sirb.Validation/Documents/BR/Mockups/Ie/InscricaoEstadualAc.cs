using System;
using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups.Ie
{
    internal sealed class InscricaoEstadualAc : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            var generatedNumbers = new List<int> { 0, 1 };

            var totalForLasDigits = GetTotalForLastDigits(generatedNumbers, Random);

            var beforeLastDigit = GetBeforeLastDigit(totalForLasDigits[0]);
            generatedNumbers.Add(beforeLastDigit);

            var index = generatedNumbers.Count - 1;
            var lastDigit = GetLastDigit(totalForLasDigits[1], generatedNumbers[index]);

            generatedNumbers.Add(lastDigit);

            return generatedNumbers.ToArray();
        }

        private static int[] GetTotalForLastDigits(IList<int> numbers, Random rnd)
        {
            var totalBeforeLastDigit = 3;
            var totalLastDigit = 4;

            for (var i = 0; i < 9; i++)
            {
                numbers.Add(rnd.Next(10));

                var index = numbers.Count - 1;
                totalBeforeLastDigit += numbers[index] * CalculateBeforeLastWeight(i);
                totalLastDigit += numbers[index] * CalculateLastWeight(i);
            }

            return new[] { totalBeforeLastDigit, totalLastDigit };
        }

        private int GetBeforeLastDigit(int totalForBeforeLastDigit)
        {
            return CalculateLastDigit(totalForBeforeLastDigit);
        }

        private int GetLastDigit(int totalForLasDigit, int lastGeneratedNumber)
        {
            var value = totalForLasDigit + (lastGeneratedNumber * 2);

            return CalculateLastDigit(value);
        }

        private static int CalculateBeforeLastWeight(int index)
        {
            switch (index)
            {
                case 0:
                    return 2;

                case 1:
                    return 9;

                default:
                    return CalculateWeight(10, index);
            }
        }

        private static int CalculateLastWeight(int index)
        {
            switch (index)
            {
                case 0:
                    return 3;

                case 1:
                    return 2;

                default:
                    return CalculateWeight(11, index);
            }
        }
    }
}
