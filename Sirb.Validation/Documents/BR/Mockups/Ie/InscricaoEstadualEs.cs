using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups.Ie
{
    internal sealed class InscricaoEstadualEs : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            var generatedNumbers = new List<int>();

            var total = 0;
            for (var i = 0; i < 8; i++)
            {
                generatedNumbers.Add(Random.Next(10));
                total += generatedNumbers[generatedNumbers.Count - 1] * CalcultateWeight(i);
            }

            generatedNumbers.Add(CalculateLastDigit(total));

            return generatedNumbers.ToArray();
        }

        private static int CalcultateWeight(int index)
        {
            return 9 - index;
        }

        protected override int CalculateLastDigit(int summationValue)
        {
            var remainder = summationValue % 11;
            return remainder > 1 ? 11 - remainder : 0;
        }
    }
}
