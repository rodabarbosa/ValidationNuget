using Sirb.Documents.BR.Interfaces;
using Sirb.Extensions;
using System;

namespace Sirb.Documents.BR.Mockups.IE
{
	internal abstract class InscricaoEstadualBase : IInscricaoEstadualInternal
	{
		protected Random _random;

		protected InscricaoEstadualBase()
		{
			_random = new Random();
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
			return (value == 10 || value == 11) ? 0 : value;
		}
	}
}