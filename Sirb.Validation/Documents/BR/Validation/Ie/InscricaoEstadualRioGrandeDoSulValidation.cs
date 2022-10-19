using Sirb.Validation.Documents.BR.Interfaces;
using Sirb.Validation.Extensions;

namespace Sirb.Validation.Documents.BR.Validation.Ie
{
    internal class InscricaoEstadualRioGrandeDoSulValidation : IInscricaoEstadualValidation
    {
        public bool IsValid(string ieNumber)
        {
            var value = ieNumber?.OnlyNumbers();
            if (string.IsNullOrEmpty(value) || value.Length != 10)
                return false;

            var sum = int.Parse(value[0].ToString()) * 2;
            for (var i = 1; i < 9; i++)
                sum += int.Parse(value[i].ToString()) * (10 - i);

            var digit = 11 - sum % 11;
            if (digit == 10 || digit == 11) digit = 0;

            return value.EndsWith(digit.ToString());
        }
    }
}
