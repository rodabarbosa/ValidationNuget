using Sirb.Validation.Documents.BR.Interfaces;

namespace Sirb.Validation.Documents.BR.Validation.Ie
{
    internal class InscricaoEstatualRioDeJaneiroValidation : IInscricaoEstatualValidation
    {
        public bool IsValid(string value)
        {
            if (value.Length != 8) return false;

            var sum = 0;
            for (var i = 0; i < 7; i++)
            {
                var weight = (i == 0 ? 2 : 8) - i;
                sum += int.Parse(value[i].ToString()) * weight;
            }

            var digit = 11 - sum % 11;
            if (sum % 11 <= 1) digit = 0;

            return value.EndsWith(digit.ToString());
        }
    }
}
