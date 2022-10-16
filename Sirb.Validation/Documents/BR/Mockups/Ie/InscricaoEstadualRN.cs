using System;
using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups.Ie
{
    internal sealed class InscricaoEstadualRn : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            var generatedNumbers = new List<int> { 2, 0 };

            var length = GetRandomLength(Random);
            var value = length + 1;
            var total = TotalBase(length);
            for (var i = 0; i < length; i++)
            {
                generatedNumbers.Add(Random.Next(10));

                total += generatedNumbers[generatedNumbers.Count - 1] * CalculateWeight(value, i);
            }

            generatedNumbers.Add(CalculateLastDigit(total));

            return generatedNumbers.ToArray();
        }

        private int GetRandomLength(Random random)
        {
            return random.Next(2) == 0 ? 6 : 7;
        }

        private int TotalBase(int length)
        {
            return length == 6 ? 18 : 20;
        }

        protected override int CalculateLastDigit(int summationValue)
        {
            var value = summationValue * 10;
            var remainder = value % 11;
            return remainder == 10 ? 0 : remainder;
        }
    }
}
