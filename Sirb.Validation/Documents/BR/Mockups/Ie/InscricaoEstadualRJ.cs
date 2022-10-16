using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups.Ie
{
    internal class InscricaoEstadualRJ : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            var generatedNumbers = new List<int>();
            var total = 0;
            for (var i = 0; i < 7; i++)
            {
                generatedNumbers.Add(Random.Next(10));
                total += generatedNumbers[generatedNumbers.Count - 1] * CalculateWeight(i);
            }

            generatedNumbers.Add(CalculateLastDigit(total));

            return generatedNumbers.ToArray();
        }

        private int CalculateWeight(int index)
        {
            return (index == 0 ? 2 : 8) - index;
        }

        protected override int CalculateLastDigit(int summationValue)
        {
            var remainder = summationValue % 11;
            if (remainder <= 1)
                return 0;

            return 11 - remainder;
        }
    }
}
