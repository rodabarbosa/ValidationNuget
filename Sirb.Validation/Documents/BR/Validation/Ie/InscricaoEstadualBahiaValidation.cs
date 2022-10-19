using Sirb.Validation.Documents.BR.Interfaces;
using Sirb.Validation.Extensions;
using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Validation.Ie
{
    internal class InscricaoEstadualBahiaValidation : IInscricaoEstadualValidation
    {
        public bool IsValid(string ieNumber)
        {
            var value = ieNumber?.OnlyNumbers();
            if (string.IsNullOrEmpty(value) || !HasValidLength(value))
                return false;

            var module = GetModuleValue(value);

            var sum = GetTotalForFirstDigit(value, out var length);

            var digit2 = GetTotalForSecondDigit(value, module, length, ref sum);

            return IsRemainderValid(value, sum, module, digit2);
        }

        private static bool HasValidLength(string value)
        {
            return value.Length == 8 || value.Length == 9;
        }

        private static int GetTotalForFirstDigit(string value, out int length)
        {
            var sum = 0;
            length = value.Length;
            var weight = GetWeightForFirstDigit(length);
            for (var i = 0; i < length - 2; i++)
                sum += int.Parse(value[i].ToString()) * (weight - i);

            return sum;
        }

        private static int GetWeightForFirstDigit(int length)
        {
            return length == 8 ? 7 : 8;
        }

        private static int GetTotalForSecondDigit(string value, int module, int length, ref int sum)
        {
            var weight = GetWeightForSecondDigit(length);
            length = weight;
            var rest = sum % module;
            var digit2 = rest == 0 || module == 11 && rest == 1 ? 0 : module - rest;
            sum = digit2 * 2;

            for (var i = 0; i < length - 2; i++)
                sum += int.Parse(value[i].ToString()) * (weight - i);

            return digit2;
        }

        private static int GetWeightForSecondDigit(int length)
        {
            return length == 8 ? 8 : 9;
        }

        private static int GetModuleValue(string value)
        {
            var module = 10;
            var firstDigitIndex = value.Length == 8 ? 0 : 1;
            var firstDigit = int.Parse(value[firstDigitIndex].ToString());
            var digitForModuleEleven = new List<int> { 6, 7, 9 };
            if (digitForModuleEleven.Contains(firstDigit)) module = 11;
            return module;
        }

        private static bool IsRemainderValid(string value, int sum, int module, int digit2)
        {
            int rest;
            rest = sum % module;
            var digit1 = rest == 0 || module == 11 && rest == 1 ? 0 : module - rest;
            var dv = digit1 + digit2.ToString();
            return value.EndsWith(dv);
        }
    }
}
