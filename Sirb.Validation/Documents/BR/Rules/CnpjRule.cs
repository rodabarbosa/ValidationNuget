namespace Sirb.Validation.Documents.BR.Rules
{
    internal static class CnpjRule
    {
        public static int CalculateBeforeLastDigitWeight(int index)
        {
            var value = index < 4 ? 5 : 13;
            return value - index;
        }

        public static int CalculateLastDigitWeight(int index)
        {
            var value = index < 5 ? 6 : 14;
            return value - index;
        }

        public static int CalculateDigitValue(int summationValue)
        {
            var remainder = summationValue % 11;
            return remainder < 2 ? 0 : 11 - remainder;
        }
    }
}
