using Sirb.Validation.Documents.BR.Interfaces;

namespace Sirb.Validation.Documents.BR.Validation.Ie
{
    internal class InscricaoEstatualMatoGrossoDoSulValidation : IInscricaoEstatualValidation
    {
        public bool IsValid(string value)
        {
            if (value.Length != 9 || !value.StartsWith("28")) return false;

            var sum = 0;
            for (var i = 0; i < 8; i++)
                sum += int.Parse(value[i].ToString()) * (9 - i);

            var rest = sum % 11;
            var digit = rest > 0 && rest < 10 ? 11 - rest : 0;
            return value.EndsWith(digit.ToString());
        }
    }
}
