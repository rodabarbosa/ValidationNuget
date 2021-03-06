﻿using System.Collections.Generic;

namespace Sirb.Documents.BR.Mockups.IE
{
	internal class InscricaoEstadualRR : InscricaoEstadualBase
	{
		protected override int[] GenerateNumbers()
		{
			List<int> generatedNumbers = new List<int> { 2, 4 };

			int total = 10;
			for (int i = 0; i < 6; i++)
			{
				generatedNumbers.Add(_random.Next(10));
				total += generatedNumbers[generatedNumbers.Count - 1] * CalculateWeight(i);
			}

			generatedNumbers.Add(CalculateLastDigit(total));

			return generatedNumbers.ToArray();
		}

		private int CalculateWeight(int index) => index + 3;

		protected override int CalculateLastDigit(int summationValue) => summationValue % 9;
	}
}