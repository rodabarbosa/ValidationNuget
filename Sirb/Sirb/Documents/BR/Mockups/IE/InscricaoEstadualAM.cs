using System.Collections.Generic;

namespace Sirb.Documents.BR.Mockups.IE
{
	internal class InscricaoEstadualAM : InscricaoEstadualBase
	{
		protected override int[] GenerateNumbers()
		{
			List<int> generatedNumbers = new List<int>();

			int total = 0;
			for (int i = 0; i < 8; i++)
			{
				generatedNumbers.Add(_random.Next(10));
				total += generatedNumbers[generatedNumbers.Count - 1] * CalculateWeight(i);
			}

			generatedNumbers.Add(CalculateLastDigit(total));

			return generatedNumbers.ToArray();
		}

		private int CalculateWeight(int index) => 9 - index;

		protected override int CalculateLastDigit(int summationValue)
		{
			int aux = summationValue < 11 ? summationValue : summationValue % 11;
			return aux > 1 ? 11 - aux : 0;
		}
	}
}