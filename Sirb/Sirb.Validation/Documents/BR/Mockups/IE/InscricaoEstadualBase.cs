using System;
using Sirb.Validation.Documents.BR.Interfaces;
using Sirb.Validation.Extensions;

namespace Sirb.Validation.Documents.BR.Mockups.IE
{
    internal abstract class InscricaoEstadualBase : IInscricaoEstadualInternal
    {
        protected Random Random;

        protected InscricaoEstadualBase()
        {
            Random = new Random();
        }

        public string Generate()
        {
            int[] generatedNumbers = GenerateNumbers();
            return generatedNumbers.ConvertToString();
        }

        protected abstract int[] GenerateNumbers();

        protected virtual int CalculateLastDigit(int summationValue)
        {
            int remainder = summationValue % 11;
            int value = 11 - remainder;
            return value == 10 || value == 11 ? 0 : value;
        }

        protected static int CalculateWeight(int value, int index)
        {
            return value - index;
        }
    }
}
