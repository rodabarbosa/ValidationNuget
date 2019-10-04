using System.Collections.Generic;

namespace Sirb.Documents.BR.Mockups.IE
{
	internal class InscricaoEstadualPB : InscricaoEstadualBase
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

		private static int CalculateWeight(int index) => 9 - index;
	}
}