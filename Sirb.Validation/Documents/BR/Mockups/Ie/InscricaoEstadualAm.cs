using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups.Ie
{
    internal sealed class InscricaoEstadualAm : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            var generatedNumbers = new List<int>();

            var total = 0;
            for (var i = 0; i < 8; i++)
            {
                generatedNumbers.Add(Random.Next(10));
                var weight = CalculateWeight(9, i);
                total += generatedNumbers[generatedNumbers.Count - 1] * weight;
            }

            generatedNumbers.Add(CalculateLastDigit(total));

            return generatedNumbers.ToArray();
        }

        protected override int CalculateLastDigit(int summationValue)
        {
            var aux = summationValue < 11 ? summationValue : summationValue % 11;
            return aux > 1 ? 11 - aux : 0;
        }
    }
}
