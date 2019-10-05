namespace Sirb.Documents.BR.Rules
{
	internal static class PisRule
	{
		public static int CalculateWeight(int index) => (index > 1 ? 11 : 3) - index;

		public static int CalculateLastDigit(int summationValue)
		{
			int remainder = summationValue % 11;
			return remainder < 2 ? 0 : 11 - remainder;
		}
	}
}