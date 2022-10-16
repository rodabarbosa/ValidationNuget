using Sirb.Validation.Extensions;
using System;
using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups.Ie
{
    internal class InscricaoEstadualGO : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            var generatedNumbers = new List<int> { 1 };

            var total = 9 + GenerateSecondDigit(generatedNumbers, Random);
            for (var i = 0; i < 6; i++)
            {
                generatedNumbers.Add(Random.Next(10));
                total += generatedNumbers[generatedNumbers.Count - 1] * CaculateWeight(i);
            }

            generatedNumbers.Add(CalculateLastDigit(total, generatedNumbers.ToArray().ConvertToString()));

            return generatedNumbers.ToArray();
        }

        private static int GenerateSecondDigit(List<int> value, Random random)
        {
            switch (random.Next(3))
            {
                case 0:
                    value.Add(0);
                    return 0;

                case 1:
                    value.Add(1);
                    return 8;

                default:
                    value.Add(5);
                    return 40;
            }
        }

        private static int CaculateWeight(int index)
        {
            return 7 - index;
        }

        private static int CalculateLastDigit(int summationValue, string partialGeneratedNumber)
        {
            var remainder = summationValue % 11;
            var value = long.Parse(partialGeneratedNumber);

            if (remainder == 1)
                return value >= 10103105L && value <= 10119997L ? 1 : 0;
            if (remainder > 1)
                return 11 - remainder;

            return 0;
        }
    }
}
