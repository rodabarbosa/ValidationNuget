using Sirb.Validation.Documents.BR.Interfaces;
using System.Text;

namespace Sirb.Validation.Documents.BR.Validation.Ie
{
    internal class InscricaoEstatualMinasGeraisValidation : IInscricaoEstatualValidation
    {
        public bool IsValid(string value)
        {
            if (!IsLengthValid(value)) return false;

            var digit1 = GetFirstDigit(value);

            var digit2 = GetSecondDigit(value, digit1);

            return IsDigitsValid(value, digit1, digit2);
        }

        private static bool IsLengthValid(string value)
        {
            return value.Length == 13;
        }

        private static int GetFirstDigit(string value)
        {
            var sb = BuildValueToString(value);

            var sum = DoSumForFirstDigit(sb);

            return GetFirstDigit(sum);
        }

        private static int GetSecondDigit(string value, int digit1)
        {
            var sumForSecondDigit = DoSumForSecondDigit(value, digit1);

            return GetSecondDigit(sumForSecondDigit);
        }

        private static StringBuilder BuildValueToString(string value)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < 11; i++)
            {
                if (i == 3)
                {
                    sb.Append($"0{value[i]}");
                    continue;
                }

                sb.Append(value[i].ToString());
            }

            return sb;
        }

        private static int DoSumForFirstDigit(StringBuilder sb)
        {
            var sum = 0;

            for (var i = 0; i < sb.Length; i++)
            {
                var weight = GetWeightForFirstDigit(i);

                var valueToSum = GetValueToSumForFirstDigit(sb[i].ToString(), weight);

                sum += valueToSum;
            }

            return sum;
        }

        private static int GetValueToSumForFirstDigit(string value, int weight)
        {
            var sum = 0;
            var valueAux = int.Parse(value);

            var calculatedValue = valueAux * weight;
            var strCalculatedValue = calculatedValue.ToString();

            var length = strCalculatedValue.Length;
            for (var j = 0; j < length; j++)
                sum += int.Parse(strCalculatedValue[j].ToString());

            return sum;
        }

        private static int GetWeightForFirstDigit(int index)
        {
            return index % 2 == 0 ? 1 : 2;
        }

        private static int GetFirstDigit(int sum)
        {
            var sumAux = sum;
            while (sumAux % 10 != 0)
                sumAux++;

            return sumAux - sum;
        }

        private static int DoSumForSecondDigit(string value, int digit1)
        {
            var sum = digit1 * 2;
            var startWeight = 3;
            var endWeight = 11;
            for (var i = 0; i < 11; i++)
            {
                var valueToSum = i < 2
                    ? GetSum(value[i].ToString(), ref startWeight)
                    : GetSum(value[i].ToString(), ref endWeight);

                sum += valueToSum;
            }

            return sum;
        }

        private static int GetSum(string value, ref int originalWeight)
        {
            var weight = originalWeight;
            originalWeight--;

            return int.Parse(value) * weight;
        }

        private static int GetSecondDigit(int sum)
        {
            var digit2 = 11 - sum % 11;
            if (sum % 11 == 0 || sum % 11 == 1) digit2 = 0;
            return digit2;
        }

        private static bool IsDigitsValid(string value, int digit1, int digit2)
        {
            var dv = digit1 + digit2.ToString();
            return value.EndsWith(dv);
        }
    }
}
