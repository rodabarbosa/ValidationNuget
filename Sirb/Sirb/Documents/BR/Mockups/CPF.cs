using Sirb.Documents.BR.Enumeration;
using Sirb.Documents.BR.Rules;
using Sirb.Extensions;
using System;
using System.Collections.Generic;

namespace Sirb.Documents.BR.Mockups
{
	/// <summary>
	/// Gerador de número CPF
	/// </summary>
	public static class Cpf
	{
		/// <summary>
		/// Gera número CPF
		/// </summary>
		/// <param name="state"></param>
		/// <returns></returns>
		public static string Generate(State? state = null)
		{
			if (state == null)
				state = GetRandomState();

			int[] generatedNumbers = GenerateNumbers(state.Value);
			return generatedNumbers.ConvertToString();
		}

		private static State GetRandomState()
		{
			Random random = new Random();
			return (State)random.Next(10);
		}

		private static int[] GenerateNumbers(State state)
		{
			List<int> generatedNumbers = new List<int>();
			Random random = new Random();

			int totalBeforeLastDigit = 0;
			int totalLastDigit = 0;
			for (int i = 0; i < 9; i++)
			{
				generatedNumbers.Add(i < 8 ? random.Next(10) : (int)state);
				totalBeforeLastDigit += generatedNumbers[generatedNumbers.Count - 1] * CpfRule.CalculateBeforeLastDigitWeight(i);
				totalLastDigit += generatedNumbers[generatedNumbers.Count - 1] * CpfRule.CalculateLastDigitWeight(i);
			}

			generatedNumbers.Add(CalculateDigitValue(totalBeforeLastDigit));
			totalLastDigit += generatedNumbers[generatedNumbers.Count - 1] * 2;

			generatedNumbers.Add(CalculateDigitValue(totalLastDigit));

			return generatedNumbers.ToArray();
		}

		private static int CalculateDigitValue(int valueSummation)
		{
			int remainder = valueSummation % 11;
			return remainder < 2 ? 0 : 11 - remainder;
		}
	}
}