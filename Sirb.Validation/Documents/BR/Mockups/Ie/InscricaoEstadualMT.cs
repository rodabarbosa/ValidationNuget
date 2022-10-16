using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups.Ie
{
    internal class InscricaoEstadualMT : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            var generatedNumbers = new List<int>();

            var total = 0;
            for (var i = 0; i < 10; i++)
            {
                generatedNumbers.Add(Random.Next(10));
                total += generatedNumbers[generatedNumbers.Count - 1] * CalculateWeight(i);
            }

            generatedNumbers.Add(CalculateLastDigit(total));

            return generatedNumbers.ToArray();
        }

        private static int CalculateWeight(int index)
        {
            return (index < 2 ? 3 : 11) - index;
        }

        protected override int CalculateLastDigit(int summationValue)
        {
            var digit = 11 - summationValue % 11;
            return summationValue % 11 < 2 ? 0 : digit;
        }
    }
}
