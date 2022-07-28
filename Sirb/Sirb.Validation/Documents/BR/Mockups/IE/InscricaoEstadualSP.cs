using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups.IE
{
    internal class InscricaoEstadualSP : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            List<int> generatedNumbers = new List<int>();

            int totalNinethDigit = 0;
            for (int i = 0; i < 8; i++)
            {
                generatedNumbers.Add(Random.Next(10));
                totalNinethDigit += generatedNumbers[generatedNumbers.Count - 1] * CalculateBeforeLastWeight(i);
            }

            generatedNumbers.Add(CalculateLastDigit(totalNinethDigit));

            for (int i = 0; i < 2; i++)
                generatedNumbers.Add(Random.Next(10));

            int totalLastDigit = CalculateSummationLastDigit(generatedNumbers);

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
            int total = 0;
            for (int i = 11; i >= 1; i--)
                total += partialGeneratedNumbers[i - 1] * CalculateLastDigitWeight(i);

            return total;
        }

        private int CalculateLastDigitWeight(int index)
        {
            int value = index <= 2 ? 2 : 11;
            return value - index + 2;
        }

        protected override int CalculateLastDigit(int summationValue)
        {
            int remainder = summationValue % 11;
            string remainderString = remainder.ToString();
            string digitString = remainderString[remainderString.Length - 1].ToString();

            return int.Parse(digitString);
        }
    }
}