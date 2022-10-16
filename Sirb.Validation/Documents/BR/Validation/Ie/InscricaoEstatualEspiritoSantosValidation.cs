using Sirb.Validation.Documents.BR.Interfaces;

namespace Sirb.Validation.Documents.BR.Validation.Ie
{
    internal class InscricaoEstatualEspiritoSantosValidation : IInscricaoEstatualValidation
    {
        public bool IsValid(string value)
        {
            if (value.Length != 9) return false;

            var sum = 0;
            for (var i = 0; i < 8; i++)
                sum += int.Parse(value[i].ToString()) * (9 - i);

            var rest = sum % 11;
            var digit = rest > 1 ? 11 - rest : 0;
            return value.EndsWith(digit.ToString());
        }
    }
}
