using System;
using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups.IE
{
    internal sealed class InscricaoEstadualRn : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            List<int> generatedNumbers = new List<int> { 2, 0 };

            int length = GetRandomLength(Random);
            int value = length + 1;
            int total = TotalBase(length);
            for (int i = 0; i < length; i++)
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
            int value = summationValue * 10;
            int remainder = value % 11;
            return remainder == 10 ? 0 : remainder;
        }
    }
}