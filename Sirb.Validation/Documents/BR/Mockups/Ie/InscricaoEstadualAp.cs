using Sirb.Validation.Extensions;
using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups.Ie
{
    internal sealed class InscricaoEstadualAp : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            var generatedNumbers = new List<int> { 0, 3 };
            var total = 24;
            for (var i = 0; i < 6; i++)
            {
                generatedNumbers.Add(Random.Next(10));
                total += generatedNumbers[generatedNumbers.Count - 1] * CalculateWeight(i);
            }

            generatedNumbers.Add(CalculateLastDigit(generatedNumbers.ToArray(), total));

            return generatedNumbers.ToArray();
        }

        private static int CalculateWeight(int index)
        {
            return CalculateWeight(7, index);
        }

        private static int CalculateLastDigit(int[] eightDigitValue, int summationValue)
        {
            var auxDigit = 0;
            var x = long.Parse(eightDigitValue.ConvertToString());
            if (x >= 3017001L && x <= 3019022L)
            {
                auxDigit = 1;
                summationValue += 9;
            }
            else if (x >= 3000001L && x <= 3017000L)
            {
                auxDigit = 0;
                summationValue += 5;
            }

            var digit = 11 - summationValue % 11;
            if (digit == 10)
                return 0;
            if (digit == 11)
                return auxDigit;

            return digit;
        }
    }
}
