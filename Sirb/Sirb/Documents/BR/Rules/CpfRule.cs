namespace Sirb.Documents.BR.Rules
{
	internal static class CpfRule
	{
		public static int CalculateBeforeLastDigitWeight(int index) => 10 - index;

		public static int CalculateLastDigitWeight(int index) => 11 - index;
	}
}