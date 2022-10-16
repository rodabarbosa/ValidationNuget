using System;
using System.Collections.Generic;
using System.Linq;

namespace Sirb.Validation.Documents.BR.Mockups.Ie
{
    internal sealed class InscricaoEstadualAl : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            var generatedNumbers = new List<int> { 2, 4, GetValidThirdDigit(Random) };

            var total = 50 + generatedNumbers[generatedNumbers.Count - 1] * 7;

            for (var i = 0; i < 5; i++)
            {
                generatedNumbers.Add(Random.Next(10));

                var index = generatedNumbers.Count - 1;
                total += generatedNumbers[index] * CalculateWeight(i);
            }

            generatedNumbers.Add(CalculateLastDigit(total));

            return generatedNumbers.ToArray();
        }

        private static int GetValidThirdDigit(Random random)
        {
            int[] thirdDigitAllowed = { 0, 3, 5, 7, 8 };

            int value;
            do
            {
                value = random.Next(10);
            } while (!thirdDigitAllowed.Contains(value));

            return value;
        }

        private static int CalculateWeight(int index)
        {
            return CalculateWeight(6, index);
        }

        protected override int CalculateLastDigit(int summationValue)
        {
            var remainder = summationValue * 10 % 11;
            return remainder == 10 ? 0 : remainder;
        }
    }
}
