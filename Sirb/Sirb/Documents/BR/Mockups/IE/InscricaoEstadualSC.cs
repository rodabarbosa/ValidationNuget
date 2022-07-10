using System.Collections.Generic;

namespace Sirb.Documents.BR.Mockups.IE
{
    internal class InscricaoEstadualSC : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            List<int> generatedNumbers = new List<int>();

            int sum = 0;
            for (int i = 0; i < 8; i++)
            {
                generatedNumbers.Add(_random.Next(10));
                sum += generatedNumbers[generatedNumbers.Count - 1] * CalculateWeight(i);
            }

            generatedNumbers.Add(CalculateLastDigit(sum));

            return generatedNumbers.ToArray();
        }

        private int CalculateWeight(int index)
        {
            return 9 - index;
        }

        protected override int CalculateLastDigit(int summationValue)
        {
            int remainder = summationValue % 11;

            if (remainder == 0 || remainder == 1)
                return 0;

            return 11 - remainder;
        }
    }
}
