using Sirb.Validation.Documents.BR.Interfaces;

namespace Sirb.Validation.Documents.BR.Validation.Ie
{
    public class InscricaoEstatualAmapaValidation : IInscricaoEstatualValidation
    {
        public bool IsValid(string value)
        {
            if (value.Length != 9 || !value.StartsWith("03")) return false;

            var digit1 = -1;
            var sum = -1;
            var x = long.Parse(value.Substring(1, 8));
            if (x >= 3017001L && x <= 3019022L)
            {
                digit1 = 1;
                sum = 9;
            }
            else if (x >= 3000001L && x <= 3017000L)
            {
                digit1 = 0;
                sum = 5;
            }
            else if (x >= 3019023L)
            {
                digit1 = 0;
                sum = 0;
            }

            for (var i = 0; i < 8; i++)
                sum += int.Parse(value[i].ToString()) * (9 - i);

            var digit = 11 - sum % 11;
            if (digit == 10)
                digit = 0;
            else if (digit == 11) digit = digit1;

            return value.EndsWith(digit.ToString());
        }
    }
}
