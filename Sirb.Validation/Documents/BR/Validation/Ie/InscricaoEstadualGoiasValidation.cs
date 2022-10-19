using Sirb.Validation.Documents.BR.Interfaces;
using Sirb.Validation.Extensions;
using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Validation.Ie
{
    internal class InscricaoEstadualGoiasValidation : IInscricaoEstadualValidation
    {
        public bool IsValid(string ieNumber)
        {
            var value = ieNumber?.OnlyNumbers();
            if (string.IsNullOrEmpty(value))
                return false;

            var startDigitsAllowed = new List<string> { "10", "11", "15" };
            var startDigit = value.Substring(0, 2);
            if (value.Length != 9 || !startDigitsAllowed.Contains(startDigit))
                return false;

            var lastDigit = int.Parse(value[8].ToString());
            if (value.StartsWith("11094402") && lastDigit > 1) return false;

            var sum = 0;
            var weight = 9;
            for (var i = 0; i < 8; i++)
            {
                sum += int.Parse(value[i].ToString()) * weight;
                weight--;
            }

            var rest = sum % 11;
            var fixValue = long.Parse(value.Substring(0, 8));
            var digit = 0;
            if (rest == 1)
                digit = fixValue >= 10103105L && fixValue <= 10119997L ? 1 : 0;
            else if (rest > 1) digit = 11 - rest;

            return value.EndsWith(digit.ToString());
        }
    }
}
