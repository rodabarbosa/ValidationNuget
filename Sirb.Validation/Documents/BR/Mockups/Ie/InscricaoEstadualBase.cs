using Sirb.Validation.Documents.BR.Interfaces;
using Sirb.Validation.Extensions;
using System;

namespace Sirb.Validation.Documents.BR.Mockups.Ie
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
            var generatedNumbers = GenerateNumbers();
            return generatedNumbers.ConvertToString();
        }

        protected abstract int[] GenerateNumbers();

        protected virtual int CalculateLastDigit(int summationValue)
        {
            var remainder = summationValue % 11;
            var value = 11 - remainder;
            return value == 10 || value == 11 ? 0 : value;
        }

        protected static int CalculateWeight(int value, int index)
        {
            return value - index;
        }
    }
}
