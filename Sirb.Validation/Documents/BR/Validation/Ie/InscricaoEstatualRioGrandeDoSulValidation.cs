using Sirb.Validation.Documents.BR.Interfaces;

namespace Sirb.Validation.Documents.BR.Validation.Ie
{
    internal class InscricaoEstatualRioGrandeDoSulValidation : IInscricaoEstatualValidation
    {
        public bool IsValid(string value)
        {
            if (value.Length != 10) return false;

            var sum = int.Parse(value[0].ToString()) * 2;
            for (var i = 1; i < 9; i++)
                sum += int.Parse(value[i].ToString()) * (10 - i);

            var digit = 11 - sum % 11;
            if (digit == 10 || digit == 11) digit = 0;

            return value.EndsWith(digit.ToString());
        }
    }
}
