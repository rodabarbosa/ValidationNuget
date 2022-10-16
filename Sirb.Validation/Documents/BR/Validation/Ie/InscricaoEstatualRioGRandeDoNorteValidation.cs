using Sirb.Validation.Documents.BR.Interfaces;

namespace Sirb.Validation.Documents.BR.Validation.Ie
{
    internal class InscricaoEstatualRioGRandeDoNorteValidation : IInscricaoEstatualValidation
    {
        public bool IsValid(string value)
        {
            var weight = value.Length;
            if (weight < 9 && weight > 10 && !value.StartsWith("20")) return false;

            var length = value.Length - 1;
            var sum = 0;
            for (var i = 0; i < length; i++)
                sum += int.Parse(value[i].ToString()) * (weight - i);

            var digit = sum * 10 % 11;
            if (digit == 10) digit = 0;

            return value.EndsWith(digit.ToString());
        }
    }
}
