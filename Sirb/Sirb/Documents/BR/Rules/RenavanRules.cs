using System.Collections.Generic;
using System.Linq;

namespace Sirb.Documents.BR.Rules
{
	public static class RenavanRules
	{
		public static int GetSummationValue(string value)
		{
			List<int> values = value.Select(x => int.Parse(x.ToString())).ToList();
			return GetSummationValue(values);
		}

		public static int GetSummationValue(List<int> values)
		{
			int summation = values[8] * 2;
			summation += values[9] * 3;

			for (int i = 0; i < 8; i++)
				summation += values[i] * (i + 2);

			return summation;
		}

		public static int CalculateastDigit(int summationValue)
		{
			int modulusEleven = summationValue % 11;
			int calculatedValue = 11 - modulusEleven;
			return calculatedValue >= 10 ? 0 : calculatedValue;
		}
	}
}
