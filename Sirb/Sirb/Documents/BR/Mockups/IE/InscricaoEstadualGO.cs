using Sirb.Extensions;
using System;
using System.Collections.Generic;

namespace Sirb.Documents.BR.Mockups.IE
{
	internal class InscricaoEstadualGO : InscricaoEstadualBase
	{
		protected override int[] GenerateNumbers()
		{
			List<int> generatedNumbers = new List<int> { 1 };

			int total = 9 + GenerateSecondDigit(generatedNumbers, _random);
			for (int i = 0; i < 6; i++)
			{
				generatedNumbers.Add(_random.Next(10));
				total += generatedNumbers[generatedNumbers.Count - 1] * CaculateWeight(i);
			}

			generatedNumbers.Add(CalculateLastDigit(total, generatedNumbers.ToArray().ConvertToString()));

			return generatedNumbers.ToArray();
		}

		private static int GenerateSecondDigit(List<int> value, Random random)
		{
			switch (random.Next(3))
			{
				case 0:
					value.Add(0);
					return 0;

				case 1:
					value.Add(1);
					return 8;

				default:
					value.Add(5);
					return 40;
			}
		}

		private static int CaculateWeight(int index) => 7 - index;

		private static int CalculateLastDigit(int summationValue, string partialGeneratedNumber)
		{
			int remainder = summationValue % 11;
			long value = long.Parse(partialGeneratedNumber);

			if (remainder == 1)
				return value >= 10103105L && value <= 10119997L ? 1 : 0;
			else if (remainder > 1)
				return 11 - remainder;

			return 0;
		}
	}
}