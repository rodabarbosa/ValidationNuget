using Sirb.Validation.Documents.BR.Interfaces;
using Sirb.Validation.Extensions;

namespace Sirb.Validation.Documents.BR.Validation.Ie
{
    internal class InscricaoEstadualParanaValidation : IInscricaoEstadualValidation
    {
        public bool IsValid(string ieNumber)
        {
            var value = ieNumber?.OnlyNumbers();
            if (string.IsNullOrEmpty(value) || value.Length != 10)
                return false;

            var sum1 = 0;
            var sum2 = 0;
            for (var i = 0; i < 8; i++)
            {
                var valueParse = int.Parse(value[i].ToString());
                var weight = (i < 2 ? 3 : 9) - i;
                sum1 += valueParse * weight;

                weight = (i < 3 ? 4 : 10) - i;
                sum2 += valueParse * weight;
            }

            var digit1 = 11 - sum1 % 11;
            if (sum1 % 11 == 0 || sum1 % 11 == 1) digit1 = 0;

            sum2 += digit1 * 2;
            var digit2 = 11 - sum2 % 11;
            if (sum2 % 11 < 2) digit2 = 0;

            var dv = digit1 + digit2.ToString();
            return value.EndsWith(dv);
        }
    }
}
