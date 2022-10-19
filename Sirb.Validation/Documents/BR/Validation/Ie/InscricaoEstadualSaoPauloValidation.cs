using Sirb.Validation.Documents.BR.Interfaces;
using Sirb.Validation.Extensions;
using System;

namespace Sirb.Validation.Documents.BR.Validation.Ie
{
    internal class InscricaoEstadualSaoPauloValidation : IInscricaoEstadualValidation
    {
        public bool IsValid(string value)
        {
            return value.StartsWith("P", StringComparison.OrdinalIgnoreCase)
                ? ValidateWithP(value.OnlyNumbers())
                : ValidateStandart(value.OnlyNumbers());
        }

        private static bool ValidateWithP(string value)
        {
            var valueAux = NormalizaValue(value);
            var sum = GetSum(valueAux);

            var rest = sum % 11;
            var strRest = rest.ToString();
            var strDigit1 = strRest[strRest.Length - 1].ToString();

            var valueAux2 = valueAux.Substring(0, 8) + strDigit1 + valueAux.Substring(9, 3);
            return valueAux2.Equals(value);
        }

        private static string NormalizaValue(string value)
        {
            var valueAux = value.PadRight(12, '0');
            return valueAux;
        }

        private static int GetSum(string valueAux)
        {
            var sum = 0;
            var weight = 1;
            for (var i = 0; i < 8; i++)
            {
                sum += int.Parse(valueAux[i].ToString()) * weight;
                weight = CalculateNewWeight(weight);
            }

            return sum;
        }

        private static int CalculateNewWeight(int weight)
        {
            weight++;

            if (weight == 2)
                return 3;

            if (weight == 9)
                return 10;

            return weight;
        }

        private static bool ValidateStandart(string value)
        {
            var valueAux = NormalizaValue(value);

            var strDigit1 = GetFirstDigit(valueAux);

            var valueAux2 = valueAux.Substring(0, 8) + strDigit1 + valueAux.Substring(9, 2);
            var strDigit2 = GetSecondDigit(valueAux);
            valueAux2 += strDigit2;

            return valueAux2.Equals(value);
        }

        private static string GetSecondDigit(string valueAux)
        {
            var sum = GetSumSecondValue(valueAux);

            var rest = sum % 11;
            var strRest = rest.ToString();
            var strDigit2 = strRest[strRest.Length - 1].ToString();
            return strDigit2;
        }

        private static string GetFirstDigit(string valueAux)
        {
            var sum = GetSum(valueAux);

            var rest = sum % 11;
            var strRest = rest.ToString();
            var strDigit1 = strRest[strRest.Length - 1].ToString();
            return strDigit1;
        }

        private static int GetSumSecondValue(string valueAux)
        {
            int sum;
            sum = 0;
            var weight = 2;
            for (var i = 11; i >= 1; i--)
            {
                sum += int.Parse(valueAux[i - 1].ToString()) * weight;
                weight++;

                if (weight > 10) weight = 2;
            }

            return sum;
        }
    }
}
