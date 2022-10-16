using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups.Ie
{
    internal class InscricaoEstadualSC : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            var generatedNumbers = new List<int>();

            var sum = 0;
            for (var i = 0; i < 8; i++)
            {
                generatedNumbers.Add(Random.Next(10));
                sum += generatedNumbers[generatedNumbers.Count - 1] * CalculateWeight(i);
            }

            generatedNumbers.Add(CalculateLastDigit(sum));

            return generatedNumbers.ToArray();
        }

        private int CalculateWeight(int index)
        {
            return 9 - index;
        }

        protected override int CalculateLastDigit(int summationValue)
        {
            var remainder = summationValue % 11;

            if (remainder == 0 || remainder == 1)
                return 0;

            return 11 - remainder;
        }
    }
}
