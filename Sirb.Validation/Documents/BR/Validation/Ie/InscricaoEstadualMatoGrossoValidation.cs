using Sirb.Validation.Documents.BR.Interfaces;
using Sirb.Validation.Extensions;

namespace Sirb.Validation.Documents.BR.Validation.Ie
{
    internal class InscricaoEstadualMatoGrossoValidation : IInscricaoEstadualValidation
    {
        public bool IsValid(string ieNumber)
        {
            var value = ieNumber?.OnlyNumbers();
            if (string.IsNullOrEmpty(value) || value.Length != 11)
                return false;

            var sum = 0;
            var startWeight = 3;
            var endWeight = 9;
            int weight;
            for (var i = 0; i < 10; i++)
            {
                if (i < 2)
                {
                    weight = startWeight;
                    startWeight--;
                }
                else
                {
                    weight = endWeight;
                    endWeight--;
                }

                sum += int.Parse(value[i].ToString()) * weight;
            }

            var digit = 11 - sum % 11;
            if (sum % 11 < 2) digit = 0;

            return value.EndsWith(digit.ToString());
        }
    }
}
