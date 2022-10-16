using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups.Ie
{
    internal class InscricaoEstadualMS : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            var generatedNumbers = new List<int>();

            var total = 0;
            for (var i = 0; i < 8; i++)
            {
                if (i > 1)
                    generatedNumbers.Add(Random.Next(10));
                else
                    generatedNumbers.Add(i == 1 ? 8 : 2);

                total += generatedNumbers[generatedNumbers.Count - 1] * CalculateWeight(i);
            }

            generatedNumbers.Add(CalculateLastDigit(total));

            return generatedNumbers.ToArray();
        }

        private int CalculateWeight(int index)
        {
            return 9 - index;
        }

        protected override int CalculateLastDigit(int summationValue)
        {
            var remainder = summationValue % 11;
            return remainder > 0 && remainder < 10 ? 11 - remainder : 0;
        }
    }
}
