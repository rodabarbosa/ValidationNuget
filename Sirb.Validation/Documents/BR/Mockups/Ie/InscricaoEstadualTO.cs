using System;
using System.Collections.Generic;
using System.Linq;

namespace Sirb.Validation.Documents.BR.Mockups.Ie
{
    internal class InscricaoEstadualTO : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            var generatedNumbers = new List<int>();

            var total = 0;
            for (var i = 0; i < 8; i++)
            {
                generatedNumbers.Add(Random.Next(10));
                total += generatedNumbers[generatedNumbers.Count - 1] * (9 - i);

                if (i == 1)
                    IncludeBusinessNumberValidation(Random, generatedNumbers);
            }

            generatedNumbers.Add(CalculateLastDigit(total));

            return generatedNumbers.ToArray();
        }

        private void IncludeBusinessNumberValidation(Random random, List<int> partialGeneratedNumbers)
        {
            if (random.Next(10) != 9)
            {
                int[] allowedDigits = { 1, 2, 3 };

                var value = random.Next(4);
                while (!allowedDigits.Contains(value))
                    value = Random.Next(4);

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
            var remainder = summationValue % 11;

            if (remainder < 2)
                return 0;

            return 11 - remainder;
        }
    }
}
