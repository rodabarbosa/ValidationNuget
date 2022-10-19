using Sirb.Validation.Documents.BR.Interfaces;
using Sirb.Validation.Extensions;

namespace Sirb.Validation.Documents.BR.Validation.Ie
{
    internal class InscricaoEstadualRondoniaValidation : IInscricaoEstadualValidation
    {
        public bool IsValid(string ieNumber)
        {
            var value = ieNumber?.OnlyNumbers();
            if (string.IsNullOrEmpty(value) || value.Length != 14)
                return false;

            var sum = 0;
            int weight;
            for (var i = 0; i < 13; i++)
            {
                weight = (i < 5 ? 6 : 14) - i;
                sum += int.Parse(value[i].ToString()) * weight;
            }

            var digit = 11 - sum % 11;
            if (digit == 11 || digit == 10) digit -= 10;

            return value.EndsWith(digit.ToString());
        }
    }
}
