using Sirb.Validation.Documents.BR.Interfaces;
using Sirb.Validation.Extensions;

namespace Sirb.Validation.Documents.BR.Validation.Ie
{
    public class InscricaoEstadualAmapaValidation : IInscricaoEstadualValidation
    {
        public bool IsValid(string ieNumber)
        {
            var value = ieNumber?.OnlyNumbers();
            if (string.IsNullOrEmpty(value) || value.Length != 9 || !value.StartsWith("03"))
                return false;

            var digitVerification = GetDigitVarification(value);
            var sum = GetStartSumValue(value);

            for (var i = 0; i < 8; i++)
                sum += int.Parse(value[i].ToString()) * (9 - i);

            var digit = GetDigit(sum, digitVerification);

            return value.EndsWith(digit.ToString());
        }

        private static int GetDigit(int sum, int digitVerification)
        {
            var digit = 11 - sum % 11;
            if (digit == 10)
                digit = 0;
            else if (digit == 11) digit = digitVerification;
            return digit;
        }

        private static int GetDigitVarification(string value)
        {
            var x = long.Parse(value.Substring(1, 8));
            if (x >= 3017001L && x <= 3019022L)
                return 1;

            if (x >= 3000001L && x <= 3017000L)
                return 0;

            if (x >= 3019023L)
                return 0;

            return -1;
        }

        private static int GetStartSumValue(string value)
        {
            var x = long.Parse(value.Substring(1, 8));
            if (x >= 3017001L && x <= 3019022L)
                return 9;

            if (x >= 3000001L && x <= 3017000L)
                return 5;

            if (x >= 3019023L)

                return 0;

            return -1;
        }
    }
}
