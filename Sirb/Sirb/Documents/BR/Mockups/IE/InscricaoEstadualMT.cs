using System.Collections.Generic;

namespace Sirb.Documents.BR.Mockups.IE
{
	internal class InscricaoEstadualMT : InscricaoEstadualBase
	{
		protected override int[] GenerateNumbers()
		{
			List<int> generatedNumbers = new List<int>();

			int total = 0;
			for (int i = 0; i < 10; i++)
			{
				generatedNumbers.Add(_random.Next(10));
				total += generatedNumbers[generatedNumbers.Count - 1] * CalculateWeight(i);
			}

			generatedNumbers.Add(CalculateLastDigit(total));

			return generatedNumbers.ToArray();
		}

		private static int CalculateWeight(int index) => (index < 2 ? 3 : 11) - index;

		protected override int CalculateLastDigit(int summationValue)
		{
			int digit = 11 - (summationValue % 11);
			return summationValue % 11 < 2 ? 0 : digit;
		}
	}
}