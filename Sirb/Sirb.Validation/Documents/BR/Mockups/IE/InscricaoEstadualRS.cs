using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups.IE
{
    internal class InscricaoEstadualRS : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            List<int> generatedNumbers = new List<int>();

            int total = 0;
            for (int i = 0; i < 9; i++)
            {
                generatedNumbers.Add(Random.Next(10));
                total += generatedNumbers[generatedNumbers.Count - 1] * CalculateWeight(i);
            }

            generatedNumbers.Add(CalculateLastDigit(total));

            return generatedNumbers.ToArray();
        }

        private int CalculateWeight(int index)
        {
            return (index == 0 ? 2 : 10) - index;
        }

        protected override int CalculateLastDigit(int summationValue)
        {
            int remainder = summationValue % 11;
            int digit = 11 - remainder;

            if (digit == 10 || digit == 11)
                return 0;

            return digit;
        }
    }
}