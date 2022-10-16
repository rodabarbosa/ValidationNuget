using Sirb.Validation.Documents.BR.Interfaces;

namespace Sirb.Validation.Documents.BR.Validation.Ie
{
    internal class InscricaoEstatualParaValidation : IInscricaoEstatualValidation
    {
        public bool IsValid(string value)
        {
            if (value.Length != 9 && !value.StartsWith("15")) return false;

            var sum = 0;
            for (var i = 0; i < 8; i++)
                sum += int.Parse(value[i].ToString()) * (9 - i);

            var digit = 11 - sum % 11;
            if (sum % 11 < 2) digit = 0;

            return value.EndsWith(digit.ToString());
        }
    }
}
