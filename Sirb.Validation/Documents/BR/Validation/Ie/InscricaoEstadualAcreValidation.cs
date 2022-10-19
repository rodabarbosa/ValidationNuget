using Sirb.Validation.Documents.BR.Interfaces;
using Sirb.Validation.Extensions;

namespace Sirb.Validation.Documents.BR.Validation.Ie
{
    internal class InscricaoEstadualAcreValidation : IInscricaoEstadualValidation
    {
        public bool IsValid(string ieNumber)
        {
            var value = ieNumber?.OnlyNumbers();
            if (string.IsNullOrEmpty(value))
                return false;

            var invalidSetup = IsInvalidSetup(value);

            if (invalidSetup)
                return false;

            var digit1 = GetFirstDigit(value);

            var digit2 = GetSecondDigit(digit1, value);

            return IsDigitsValid(digit1, digit2, value);
        }

        private static int GetFirstDigit(string value)
        {
            var sum = GetTotalForFirstDigit(value);

            var digit1 = GetRemainderForFirstDigit(sum);
            return digit1;
        }

        private static int GetTotalForFirstDigit(string value)
        {
            var sum = 0;
            var startWeight = 4;
            var endWeight = 9;
            int weight;
            for (var i = 0; i < 11; i++)
            {
                var valueToSum = i < 3
                    ? GetValueToSum(value[i].ToString(), ref startWeight)
                    : GetValueToSum(value[i].ToString(), ref endWeight);

                sum += valueToSum;
            }

            return sum;
        }

        private static int GetRemainderForFirstDigit(int sum)
        {
            var digit1 = 11 - sum % 11;
            if (digit1 == 10 || digit1 == 11) digit1 = 0;
            return digit1;
        }

        private static int GetSecondDigit(int digit1, string value)
        {
            var sum = GetTotalForSecondDigit(digit1, value);

            var digit2 = GetRemainderForSecondDigit(sum);
            return digit2;
        }

        private static int GetTotalForSecondDigit(int digit1, string value)
        {
            var sum = digit1 * 2;
            var startWeight = 5;
            var endWeight = 9;
            for (var i = 0; i < 11; i++)
            {
                var valueToSum = i < 4
                    ? GetValueToSum(value[i].ToString(), ref startWeight)
                    : GetValueToSum(value[i].ToString(), ref endWeight);

                sum += valueToSum;
            }

            return sum;
        }

        private static int GetRemainderForSecondDigit(int sum)
        {
            var digit2 = 11 - sum % 11;
            if (digit2 == 10 || digit2 == 11) digit2 = 0;
            return digit2;
        }

        private static bool IsDigitsValid(int digit1, int digit2, string value)
        {
            var digits = digit1 + digit2;
            var dv = digits.ToString();
            return value.EndsWith(dv);
        }

        private static int GetValueToSum(string value, ref int originalWeight)
        {
            var weight = originalWeight;
            originalWeight--;

            var valueInt = int.Parse(value);
            return weight * valueInt;
        }

        private static bool IsInvalidSetup(string value)
        {
            var validLength = IsLengthValid(value);
            var validStartingDigits = IsStartDigitsValid(value);
            return !validLength && !validStartingDigits;
        }

        private static bool IsLengthValid(string value)
        {
            return value.Length == 13;
        }

        private static bool IsStartDigitsValid(string value)
        {
            return value.StartsWith("01");
        }
    }
}
