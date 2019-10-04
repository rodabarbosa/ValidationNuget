using Sirb.Extensions;
using System.Collections.Generic;

namespace Sirb.Documents.BR.Mockups.IE
{
	internal class InscricaoEstadualAP : InscricaoEstadualBase
	{
		protected override int[] GenerateNumbers()
		{
			List<int> generatedNumbers = new List<int> { 0, 3 };
			int total = 24;
			for (int i = 0; i < 6; i++)
			{
				generatedNumbers.Add(_random.Next(10));
				total += generatedNumbers[generatedNumbers.Count - 1] * CalculateWeight(i);
			}
			generatedNumbers.Add(CalculateLastDigit(generatedNumbers.ToArray(), total));

			return generatedNumbers.ToArray();
		}

		private int CalculateWeight(int index) => 7 - index;

		private int CalculateLastDigit(int[] eightDigitValue, int summationValue)
		{
			int auxDigit = 0;
			long x = long.Parse(eightDigitValue.ConvertToString());
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

			int digit = 11 - (summationValue % 11);
			if (digit == 10)
				return 0;
			else if (digit == 11)
				return auxDigit;

			return digit;
		}
	}
}