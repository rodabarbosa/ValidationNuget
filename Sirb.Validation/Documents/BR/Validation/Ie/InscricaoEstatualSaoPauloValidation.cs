using Sirb.Validation.Documents.BR.Interfaces;
using Sirb.Validation.Extensions;
using System;

namespace Sirb.Validation.Documents.BR.Validation.Ie
{
    internal class InscricaoEstatualSaoPauloValidation : IInscricaoEstatualValidation
    {
        public bool IsValid(string value)
        {
            return value.StartsWith("P", StringComparison.OrdinalIgnoreCase) ? ValidateSPWithP(value.OnlyNumbers()) : ValidateSPCommom(value.OnlyNumbers());
        }

        private static bool ValidateSPWithP(string value)
        {
            var valueAux = value.PadRight(12, '0');
            var sum = 0;
            var weight = 1;
            for (var i = 0; i < 8; i++)
            {
                sum += int.Parse(valueAux[i].ToString()) * weight;
                weight++;

                if (weight == 2)
                    weight = 3;
                else if (weight == 9) weight = 10;
            }

            var rest = sum % 11;
            var strRest = rest.ToString();
            var strDigit1 = strRest[strRest.Length - 1].ToString();

            var valueAux2 = valueAux.Substring(0, 8) + strDigit1 + valueAux.Substring(9, 3);
            return valueAux2.Equals(value);
        }

        private static bool ValidateSPCommom(string value)
        {
            var valueAux = value.PadRight(12, '0');
            var sum = 0;
            var weight = 1;

            for (var i = 0; i < 8; i++)
            {
                sum += int.Parse(valueAux[i].ToString()) * weight;
                weight++;

                if (weight == 2)
                    weight = 3;
                else if (weight == 9) weight = 10;
            }

            var rest = sum % 11;
            var strRest = rest.ToString();
            var strDigit1 = strRest[strRest.Length - 1].ToString();

            var valueAux2 = valueAux.Substring(0, 8) + strDigit1 + valueAux.Substring(9, 2);
            sum = 0;
            weight = 2;
            for (var i = 11; i >= 1; i--)
            {
                sum += int.Parse(valueAux[i - 1].ToString()) * weight;
                weight++;

                if (weight > 10) weight = 2;
            }

            rest = sum % 11;
            strRest = rest.ToString();
            var strDigit2 = strRest[strRest.Length - 1].ToString();
            valueAux2 += strDigit2;

            return valueAux2.Equals(value);
        }
    }
}
