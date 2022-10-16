using Sirb.Validation.Documents.BR.Interfaces;
using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Validation.Ie
{
    internal class InscricaoEstatualAlagoasValidation : IInscricaoEstatualValidation
    {
        public bool IsValid(string value)
        {
            if (value.Length != 9 || !value.StartsWith("24")) return false;

            var thirdDigitAllowed = new List<int> { 0, 3, 5, 7, 8 };
            var thirdDigit = int.Parse(value[2].ToString());
            if (!thirdDigitAllowed.Contains(thirdDigit)) return false;

            var sum = 0;
            for (var i = 0; i < 8; i++)
                sum += int.Parse(value[i].ToString()) * (9 - i);

            var digit = sum * 10 % 11;
            if (digit == 10) digit = 0;

            return value.EndsWith(digit.ToString());
        }
    }
}
