using System.Collections.Generic;

namespace Sirb.Documents.BR.Mockups.IE
{
	internal class InscricaoEstadualRJ : InscricaoEstadualBase
	{
		protected override int[] GenerateNumbers()
		{
			List<int> generatedNumbers = new List<int>();
			int total = 0;
			for (int i = 0; i < 7; i++)
			{
				generatedNumbers.Add(_random.Next(10));
				total += generatedNumbers[generatedNumbers.Count - 1] * CalculateWeight(i);
			}

			generatedNumbers.Add(CalculateLastDigit(total));

			return generatedNumbers.ToArray();
		}

		private int CalculateWeight(int index) => (index == 0 ? 2 : 8) - index;

		protected override int CalculateLastDigit(int summationValue)
		{
			int remainder = summationValue % 11;
			if (remainder <= 1)
				return 0;

			return 11 - remainder;
		}
	}
}