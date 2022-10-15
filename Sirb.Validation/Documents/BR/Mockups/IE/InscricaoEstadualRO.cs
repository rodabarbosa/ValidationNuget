using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups.IE
{
    internal class InscricaoEstadualRO : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            List<int> generatedNumbers = new List<int>();

            int sum = 0;
            for (int i = 0; i < 13; i++)
            {
                generatedNumbers.Add(Random.Next(10));
                sum += generatedNumbers[generatedNumbers.Count - 1] * CalculateWeight(i);
            }

            generatedNumbers.Add(CalculateLastDigit(sum));

            return generatedNumbers.ToArray();
        }

        private int CalculateWeight(int index)
        {
            return (index < 5 ? 6 : 14) - index;
        }

        protected override int CalculateLastDigit(int summationValue)
        {
            int remainder = summationValue % 11;
            int value = 11 - remainder;

            if (value == 11 || value == 10)
                value -= 10;

            return value;
        }
    }
}