namespace Sirb.Validation.Documents.BR.Rules
{
    internal static class PisRule
    {
        public static int CalculateWeight(int index)
        {
            return (index > 1 ? 11 : 3) - index;
        }

        public static int CalculateLastDigit(int summationValue)
        {
            var remainder = summationValue % 11;
            return remainder < 2 ? 0 : 11 - remainder;
        }
    }
}
