using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups.Ie
{
    internal class InscricaoEstadualMA : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            var generatedNumbers = new List<int> { 1, 2 };

            var total = 25;
            for (var i = 0; i < 6; i++)
            {
                generatedNumbers.Add(Random.Next(10));
                total += generatedNumbers[generatedNumbers.Count - 1] * CalculateWeight(i);
            }

            generatedNumbers.Add(CalculateLastDigit(total));

            return generatedNumbers.ToArray();
        }

        private static int CalculateWeight(int index)
        {
            return 7 - index;
        }

        protected override int CalculateLastDigit(int summationValue)
        {
            var digit = 11 - summationValue % 11;
            return summationValue % 11 < 2 ? 0 : digit;
        }
    }
}
