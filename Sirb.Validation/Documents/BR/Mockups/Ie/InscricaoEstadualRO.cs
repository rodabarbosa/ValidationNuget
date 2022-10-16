using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups.Ie
{
    internal class InscricaoEstadualRO : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            var generatedNumbers = new List<int>();

            var sum = 0;
            for (var i = 0; i < 13; i++)
            {
                generatedNumbers.Add(Random.Next(10));
                sum += generatedNumbers[generatedNumbers.Count - 1] * CalculateWeight(i);
            }

            generatedNumbers.Add(CalculateLastDigit(sum));

            return generatedNumbers.ToArray();
        }

        private int CalculateWeight(int index)
        {
            return (index < 5 ? 6 : 14) - index;
        }

        protected override int CalculateLastDigit(int summationValue)
        {
            var remainder = summationValue % 11;
            var value = 11 - remainder;

            if (value == 11 || value == 10)
                value -= 10;

            return value;
        }
    }
}
