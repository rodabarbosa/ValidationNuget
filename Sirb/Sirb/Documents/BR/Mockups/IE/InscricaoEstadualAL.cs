using System;
using System.Collections.Generic;
using System.Linq;

namespace Sirb.Documents.BR.Mockups.IE
{
    internal class InscricaoEstadualAL : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            List<int> generatedNumbers = new List<int> { 2, 4, GetValidThirdDigit(_random) };

            int total = 50 + generatedNumbers[generatedNumbers.Count - 1] * 7;

            for (int i = 0; i < 5; i++)
            {
                generatedNumbers.Add(_random.Next(10));
                total += generatedNumbers[generatedNumbers.Count - 1] * CalculateWeight(i);
            }

            generatedNumbers.Add(CalculateLastDigit(total));

            return generatedNumbers.ToArray();
        }

        private static int GetValidThirdDigit(Random random)
        {
            int[] thirdDigitAllowed = { 0, 3, 5, 7, 8 };
            int value = random.Next(10);
            while (!thirdDigitAllowed.Contains(value))
                value = random.Next(10);

            return value;
        }

        private static int CalculateWeight(int index)
        {
            return 6 - index;
        }

        protected override int CalculateLastDigit(int summationValue)
        {
            int remainder = summationValue * 10 % 11;
            return remainder == 10 ? 0 : remainder;
        }
    }
}
