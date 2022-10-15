namespace Sirb.Validation.Documents.BR.Rules
{
    internal static class CpfRule
    {
        public static int CalculateBeforeLastDigitWeight(int index)
        {
            return 10 - index;
        }

        public static int CalculateLastDigitWeight(int index)
        {
            return 11 - index;
        }
    }
}