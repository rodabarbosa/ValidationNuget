using System.Collections.Generic;

namespace Sirb.Documents.BR.Mockups.IE
{
    internal class InscricaoEstadualES : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            List<int> generatedNumbers = new List<int>();

            int total = 0;
            for (int i = 0; i < 8; i++)
            {
                generatedNumbers.Add(_random.Next(10));
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
            int remainder = summationValue % 11;
            return remainder > 1 ? 11 - remainder : 0;
        }
    }
}
