using System.Collections.Generic;

namespace Sirb.Documents.BR.Mockups.IE
{
	internal class InscricaoEstadualDF : InscricaoEstadualBase
	{
		protected override int[] GenerateNumbers()
		{
			List<int> generatedNumbers = new List<int>();

			int totalBeforeLastDigit = 0;
			int totalLastDigit = 0;
			for (int i = 0; i < 11; i++)
			{
				generatedNumbers.Add(_random.Next(10));
				totalBeforeLastDigit += generatedNumbers[generatedNumbers.Count - 1] * CalculateBeforeLastWeight(i);
				totalLastDigit += generatedNumbers[generatedNumbers.Count - 1] * CalculateLastWeight(i);
			}

			generatedNumbers.Add(CalculateLastDigit(totalBeforeLastDigit));

			totalLastDigit += generatedNumbers[generatedNumbers.Count - 1] * 2;
			generatedNumbers.Add(CalculateLastDigit(totalLastDigit));

			return generatedNumbers.ToArray();
		}

		private int CalculateBeforeLastWeight(int index)
		{
			int value = index < 3 ? 4 : 12;
			return value - index;
		}

		private int CalculateLastWeight(int index)
		{
			int value = index < 4 ? 5 : 13;
			return value - index;
		}
	}
}