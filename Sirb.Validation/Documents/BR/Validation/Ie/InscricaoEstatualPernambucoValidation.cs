using Sirb.Validation.Documents.BR.Interfaces;

namespace Sirb.Validation.Documents.BR.Validation.Ie
{
    internal class InscricaoEstatualPernambucoValidation : IInscricaoEstatualValidation
    {
        public bool IsValid(string value)
        {
            var valueAux = value.PadRight(14, '0');
            var sum = 0;
            var weight = 2;
            for (var i = 7; i >= 1; i--)
            {
                sum += int.Parse(valueAux[i - 1].ToString()) * weight;
                weight++;

                if (weight > 9) weight = 2;
            }

            var rest = sum % 11;
            var aux = 11 - rest;
            if (aux > 9) aux -= 10;

            var str = aux.ToString();
            var strDigit1 = str.Substring(str.Length - 1);
            var valueAux2 = valueAux.Substring(0, 7) + strDigit1;
            if (!valueAux2.Equals(value.Substring(0, 8))) return false;

            sum = 0;
            weight = 2;
            for (var i = 8; i >= 1; i--)
            {
                sum += int.Parse(valueAux[i - 1].ToString()) * weight;
                weight++;
                if (weight > 9) weight = 2;
            }

            rest = sum % 11;
            aux = 11 - rest;
            if (aux > 9) aux -= 10;
            str = aux.ToString();
            var strDigit2 = str.Substring(str.Length - 1);
            valueAux2 = valueAux.Substring(0, 8) + strDigit2;
            return valueAux2 == value;
        }
    }
}
