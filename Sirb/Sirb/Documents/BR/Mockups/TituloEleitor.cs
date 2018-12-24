using System;
using System.Text;

namespace Sirb.Documents.BR.Mockups
{
	/// <summary>
	/// Gerador de número Título de Eleitor
	/// </summary>
	public static class TituloEleitor
	{
		/// <summary>
		/// Gera número Titulo de Eleitor
		/// </summary>
		/// <returns></returns>
		public static string Generate()
		{
			var sb = new StringBuilder();
			var random = new Random();
			var total = 0;
			int value;
			int stateDigit;
			int digit9;
			int digit10;
			int digit11;
			int digit12;
			for (var i = 0; i < 8; i++)
			{
				value = random.Next(10);
				sb.Append(value.ToString());
				total += value * (i + 2);
			}

			digit11 = total % 11;
			if (digit11 > 9)
			{
				digit11 = 0;
			}

			var done = false;
			while (!done)
			{
				digit9 = random.Next(10);
				digit10 = random.Next(10);
				stateDigit = int.Parse($"{digit9}{digit10}");
				if (!(stateDigit > 0 && stateDigit < 29))
				{
					continue;
				}

				total = (digit9 * 7) + (digit10 * 8) + (digit11 * 9);
				digit12 = total % 11;
				if (digit12 > 9)
				{
					digit12 = 0;
				}
				sb.Append($"{digit9}{digit10}{digit11}{digit12}");
				done = true;
			}

			return sb.ToString();
		}
	}
}