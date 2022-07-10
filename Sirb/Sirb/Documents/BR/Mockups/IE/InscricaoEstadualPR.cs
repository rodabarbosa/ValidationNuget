using System.Collections.Generic;

namespace Sirb.Documents.BR.Mockups.IE
{
    internal class InscricaoEstadualPR : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            List<int> generatedNumbers = new List<int>();

            int totalBeforeLastDigit = 0;
            int totalLastDigit = 0;
            for (int i = 0; i < 8; i++)
            {
                generatedNumbers.Add(_random.Next(10));
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
            return (index < 2 ? 3 : 9) - index;
        }

        private int CalculateLastWeight(int index)
        {
            return (index < 3 ? 4 : 10) - index;
        }

        protected override int CalculateLastDigit(int summationValue)
        {
            int remainder = summationValue % 11;

            if (remainder % 11 == 0 || remainder % 11 == 1)
                return 0;

            return 11 - remainder;
        }
    }
}
