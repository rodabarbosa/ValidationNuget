using Sirb.Validation.Extensions;
using System.Text.RegularExpressions;

namespace Sirb.Validation.Documents.BR.Validation
{
    /// <summary>
    /// Título de Eleitor
    /// </summary>
    public static class TituloEleitorValidation
    {
        /// <summary>
        /// Validador de Título de Eleitor
        /// </summary>
        /// <param name="value">Titulo de Eleitor</param>
        /// <returns></returns>
        public static bool IsValid(string value)
        {
            var aux = value.RemoveMask();
            if (string.IsNullOrEmpty(aux) || aux.Length != 12)
                return false;

            var digit1 = GetFirstDigit(aux);
            var digit2 = GetSecondDigit(aux);
            var stateDigit = GetStateDigit(aux);
            return IsStateDigitValid(stateDigit)
                   && aux[10].ToString().Equals(digit1.ToString())
                   && aux[11].ToString().Equals(digit2.ToString());
        }

        private static int GetFirstDigit(string value)
        {
            var total = 0;
            for (var i = 0; i < 8; i++)
            {
                total += int.Parse(value[i].ToString()) * (i + 2);
            }

            var digit = total % 11;
            if (digit > 9)
                digit = 0;

            return digit;
        }

        private static int GetSecondDigit(string value)
        {
            var total = 0;
            for (var i = 8; i < 11; i++)
            {
                total += int.Parse(value[i].ToString()) * (i - 1);
            }

            var digit = total % 11;
            if (digit > 9)
                digit = 0;

            return digit;
        }

        private static int GetStateDigit(string value)
        {
            return int.Parse($"{value[8]}{value[9]}");
        }

        private static bool IsStateDigitValid(int digit)
        {
            return digit > 0 && digit < 29;
        }

        /// <summary>
        /// Adiciona mascara no Título de Eleitor
        /// </summary>
        /// <param name="value">Titulo de Eleitor</param>
        /// <returns></returns>
        public static string PlaceMask(string value)
        {
            if (string.IsNullOrEmpty(value?.Trim()))
                return default;

            return Regex.Replace(value.RemoveMask(), @"(\d{4})(\d{4})(\d{4})", "$1.$2.$3");
        }
    }
}
