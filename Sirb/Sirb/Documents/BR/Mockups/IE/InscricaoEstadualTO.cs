using System;
using System.Collections.Generic;
using System.Linq;

namespace Sirb.Documents.BR.Mockups.IE
{
    internal class InscricaoEstadualTO : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            List<int> generatedNumbers = new List<int>();

            int total = 0;
            for (int i = 0; i < 8; i++)
            {
                generatedNumbers.Add(_random.Next(10));
                total += generatedNumbers[generatedNumbers.Count - 1] * (9 - i);

                if (i == 1)
                    IncludeBusinessNumberValidation(_random, generatedNumbers);
            }

            generatedNumbers.Add(CalculateLastDigit(total));

            return generatedNumbers.ToArray();
        }

        private void IncludeBusinessNumberValidation(Random random, List<int> partialGeneratedNumbers)
        {
            if (random.Next(10) != 9)
            {
                int[] allowedDigits = { 1, 2, 3 };

                int value = random.Next(4);
                while (!allowedDigits.Contains(value))
                    value = _random.Next(4);

                partialGeneratedNumbers.Add(0);
                partialGeneratedNumbers.Add(value);
            }
            else
            {
                partialGeneratedNumbers.Add(9);
                partialGeneratedNumbers.Add(9);
            }
        }

        protected override int CalculateLastDigit(int summationValue)
        {
            int remainder = summationValue % 11;

            if (remainder < 2)
                return 0;

            return 11 - remainder;
        }
    }
}
