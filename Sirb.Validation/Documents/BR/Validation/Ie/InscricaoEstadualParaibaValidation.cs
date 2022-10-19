using Sirb.Validation.Documents.BR.Interfaces;
using Sirb.Validation.Extensions;

namespace Sirb.Validation.Documents.BR.Validation.Ie
{
    internal class InscricaoEstadualParaibaValidation : IInscricaoEstadualValidation
    {
        public bool IsValid(string ieNumber)
        {
            var value = ieNumber?.OnlyNumbers();
            if (string.IsNullOrEmpty(value) || value.Length != 9) return false;

            var sum = 0;
            for (var i = 0; i < 8; i++)
                sum += int.Parse(value[i].ToString()) * (9 - i);

            var digit = 11 - sum % 11;
            if (digit == 10 || digit == 11) digit = 0;

            return value.EndsWith(digit.ToString());
        }
    }
}
