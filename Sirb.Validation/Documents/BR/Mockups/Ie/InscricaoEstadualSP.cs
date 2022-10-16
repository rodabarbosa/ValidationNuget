using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups.Ie
{
    internal class InscricaoEstadualSP : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            var generatedNumbers = new List<int>();

            var totalNinethDigit = 0;
            for (var i = 0; i < 8; i++)
            {
                generatedNumbers.Add(Random.Next(10));
                totalNinethDigit += generatedNumbers[generatedNumbers.Count - 1] * CalculateBeforeLastWeight(i);
            }

            generatedNumbers.Add(CalculateLastDigit(totalNinethDigit));

            for (var i = 0; i < 2; i++)
                generatedNumbers.Add(Random.Next(10));

            var totalLastDigit = CalculateSummationLastDigit(generatedNumbers);

            generatedNumbers.Add(CalculateLastDigit(totalLastDigit));

            return generatedNumbers.ToArray();
        }

        private int CalculateBeforeLastWeight(int index)
        {
            if (index == 0)
                return 1;

            return (index > 6 ? 3 : 2) + index;
        }

        private int CalculateSummationLastDigit(List<int> partialGeneratedNumbers)
        {
            var total = 0;
            for (var i = 11; i >= 1; i--)
                total += partialGeneratedNumbers[i - 1] * CalculateLastDigitWeight(i);

            return total;
        }

        private int CalculateLastDigitWeight(int index)
        {
            var value = index <= 2 ? 2 : 11;
            return value - index + 2;
        }

        protected override int CalculateLastDigit(int summationValue)
        {
            var remainder = summationValue % 11;
            var remainderString = remainder.ToString();
            var digitString = remainderString[remainderString.Length - 1].ToString();

            return int.Parse(digitString);
        }
    }
}
