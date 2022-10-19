using Sirb.Validation.Documents.BR.Interfaces;
using Sirb.Validation.Extensions;

namespace Sirb.Validation.Documents.BR.Validation.Ie
{
    internal class InscricaoEstadualTocantinsValidation : IInscricaoEstadualValidation
    {
        public bool IsValid(string ieNumber)
        {
            var value = ieNumber?.OnlyNumbers();
            if (string.IsNullOrEmpty(value) || !(value.Length == 9 || value.Length == 11))
                return false;

            var valueAux = value;
            if (value.Length == 9) valueAux = value.Substring(0, 2) + "02" + value.Substring(1, value.Length);

            var sum = 0;
            var weight = 9;
            for (var i = 0; i < valueAux.Length - 1; i++)
                if (i != 2 && i != 3)
                {
                    sum += int.Parse(valueAux[i].ToString()) * weight;
                    weight--;
                }

            var digit = 11 - sum % 11;
            if (sum % 11 < 2) digit = 0;

            return valueAux.EndsWith(digit.ToString());
        }
    }
}
