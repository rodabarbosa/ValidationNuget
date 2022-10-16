using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups.Ie
{
    internal sealed class InscricaoEstadualDf : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            var generatedNumbers = new List<int>();

            var totalBeforeLastDigit = 0;
            var totalLastDigit = 0;
            for (var i = 0; i < 11; i++)
            {
                generatedNumbers.Add(Random.Next(10));
                totalBeforeLastDigit += generatedNumbers[generatedNumbers.Count - 1] * CalculateBeforeLastWeight(i);
                totalLastDigit += generatedNumbers[generatedNumbers.Count - 1] * CalculateLastWeight(i);
            }

            generatedNumbers.Add(CalculateLastDigit(totalBeforeLastDigit));

            totalLastDigit += generatedNumbers[generatedNumbers.Count - 1] * 2;
            generatedNumbers.Add(CalculateLastDigit(totalLastDigit));

            return generatedNumbers.ToArray();
        }

        private int CalculateBeforeLastWeight(int index)
        {
            var value = index < 3 ? 4 : 12;
            return value - index;
        }

        private int CalculateLastWeight(int index)
        {
            var value = index < 4 ? 5 : 13;
            return value - index;
        }
    }
}
