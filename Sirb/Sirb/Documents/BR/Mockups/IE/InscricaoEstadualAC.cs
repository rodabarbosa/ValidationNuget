using System.Collections.Generic;

namespace Sirb.Documents.BR.Mockups.IE
{
	internal class InscricaoEstadualAC : InscricaoEstadualBase
	{
		protected override int[] GenerateNumbers()
		{
			List<int> generatedNumbers = new List<int> { 0, 1 };

			int totalBeforeLastDigit = 3;
			int totalLastDigit = 4;

			for (int i = 0; i < 9; i++)
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
			if (index == 0)
				return 2;
			else if (index == 1)
				return 9;

			return 10 - index;
		}

		private int CalculateLastWeight(int index)
		{
			if (index == 0)
				return 3;
			else if (index == 1)
				return 2;

			return 11 - index;
		}
	}
}