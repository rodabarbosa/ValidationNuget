using Sirb.Validation.Documents.BR.Interfaces;

namespace Sirb.Validation.Documents.BR.Validation.Ie
{
    internal class InscricaoEstatualDistritoFederalValidation : IInscricaoEstatualValidation
    {
        public bool IsValid(string value)
        {
            if (value.Length != 13) return false;

            var sum = 0;
            var startWeight = 4;
            var endWeight = 9;
            int weight;
            for (var i = 0; i < 11; i++)
            {
                if (i < 3)
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

            var digit1 = 11 - sum % 11;
            if (digit1 == 11 || digit1 == 10) digit1 = 0;

            sum = digit1 * 2;
            startWeight = 5;
            endWeight = 9;
            for (var i = 0; i < 11; i++)
            {
                if (i < 4)
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

            var digit2 = 11 - sum % 11;
            if (digit2 == 11 || digit2 == 10) digit2 = 0;

            var dv = digit1 + digit2.ToString();
            return value.EndsWith(dv);
        }
    }
}
