using Sirb.Documents.BR.Enumeration;
using System;
using System.Linq;
using System.Text;

namespace Sirb.Documents.BR.Mockups
{
	/// <summary>
	/// Gerador de Inscrição Estadual
	/// </summary>
	public static class InscricaoEstadual
	{
		/// <summary>
		/// Gera Número de Inscrição Estadual
		/// </summary>
		/// <param name="state">State</param>
		public static string Generate(State state)
		{
			switch (state)
			{
				case State.AC:
					return GenerateAC();

				case State.AL:
					return GenerateAL();

				case State.AM:
					return GenerateAM();

				case State.AP:
					return GenerateAP();

				case State.BA:
					return GenerateBA();

				case State.CE:
					return GenerateCE();

				case State.DF:
					return GenerateDF();

				case State.ES:
					return GenerateES();

				case State.GO:
					return GenerateGO();

				case State.MA:
					return GenerateMA();

				case State.MG:
					return GenerateMG();

				case State.MS:
					return GenerateMS();

				case State.MT:
					return GenerateMT();

				case State.PA:
					return GeneratePA();

				case State.PB:
					return GeneratePB();

				case State.PE:
					return GeneratePE();

				case State.PI:
					return GeneratePI();

				case State.PR:
					return GeneratePR();

				case State.RJ:
					return GenerateRJ();

				case State.RN:
					return GenerateRN();

				case State.RO:
					return GenerateRO();

				case State.RR:
					return GenerateRR();

				case State.RS:
					return GenerateRS();

				case State.SC:
					return GenerateSC();

				case State.SE:
					return GenerateSE();

				case State.SP:
					return GenerateSP();

				case State.TO:
					return GenerateTO();

				default:
					throw new ArgumentException("UF desconhecida.");
			}
		}

		private static string GenerateAC()
		{
			var random = new Random();
			var sb = new StringBuilder();
			sb.Append("01");
			var sum1 = 3;
			var sum2 = 4;
			int value;
			for (int i = 0; i < 9; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				if (i == 0)
				{
					sum1 += value * 2;
					sum2 += value * 3;
				}
				else if (i == 1)
				{
					sum1 += value * 9;
					sum2 += value * 2;
				}
				else
				{
					sum1 += value * (10 - i);
					sum2 += value * (11 - i);
				}
			}

			var digit1 = 11 - (sum1 % 11);
			if (digit1 == 10 || digit1 == 11)
			{
				digit1 = 0;
			}
			sb.Append(digit1);
			sum2 += digit1 * 2;
			var digit2 = 11 - (sum2 % 11);
			if (digit2 == 10 || digit2 == 11)
			{
				digit2 = 0;
			}
			sb.Append(digit2);
			return sb.ToString();
		}

		private static string GenerateAL()
		{
			var random = new Random();
			var sb = new StringBuilder();
			sb.Append("24");

			var sum = 50;
			var thirdDigitAllowed = new int[] { 0, 3, 5, 7, 8 };
			int value = -1;
			while (!thirdDigitAllowed.Contains(value))
			{
				value = random.Next(10);
			}
			sb.Append(value);
			sum += value * 7;
			for (var i = 0; i < 5; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				sum += value * (6 - i);
			}

			var digit = sum * 10 % 11;
			if (digit == 10)
			{
				digit = 0;
			}
			sb.Append(digit);
			return sb.ToString();
		}

		private static string GenerateAM()
		{
			var random = new Random();
			var sb = new StringBuilder();

			int value;
			var sum = 0;
			for (var i = 0; i < 8; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				sum += value * (9 - i);
			}

			var aux = sum < 11 ? sum : sum % 11;
			var digit = aux > 1 ? 11 - aux : 0;
			sb.Append(digit);
			return sb.ToString();
		}

		private static string GenerateAP()
		{
			var random = new Random();
			var sb = new StringBuilder();
			sb.Append("03");
			int value;
			var sum = 24;
			for (var i = 0; i < 6; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				sum += value * (7 - i);
			}

			var digit1 = 0;
			var x = long.Parse(sb.ToString());
			if (x >= 3017001L && x <= 3019022L)
			{
				digit1 = 1;
				sum += 9;
			}
			else if (x >= 3000001L && x <= 3017000L)
			{
				digit1 = 0;
				sum += 5;
			}

			var digit = 11 - (sum % 11);
			if (digit == 10)
			{
				digit = 0;
			}
			else if (digit == 11)
			{
				digit = digit1;
			}
			sb.Append(digit);
			return sb.ToString();
		}

		private static string GenerateBA()
		{
			var random = new Random();
			var sb = new StringBuilder();
			int value = random.Next(2);
			int length = value == 1 ? 9 : 8;

			var sum1 = 0;
			var sum2 = 0;
			var weight1 = length == 8 ? 7 : 8;
			var weight2 = length == 8 ? 8 : 9;
			var digitForModuleEleven = new int[] { 6, 7, 9 };
			var module = 10;
			for (var i = 0; i < length - 2; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				sum1 += value * (weight1 - i);
				sum2 += value * (weight2 - i);

				if (length == 8 && i == 0 && digitForModuleEleven.Contains(value))
				{
					module = 11;
				}
				else if (length == 9 && i == 1 && digitForModuleEleven.Contains(value))
				{
					module = 11;
				}
			}

			var rest = sum1 % module;
			var digit2 = rest == 0 || (module == 11 && rest == 1) ? 0 : module - rest;
			sum2 += digit2 * 2;

			rest = sum2 % module;
			var digit1 = rest == 0 || (module == 11 && rest == 1) ? 0 : module - rest;
			sb.Append(digit1);
			sb.Append(digit2);
			return sb.ToString();
		}

		private static string GenerateCE()
		{
			var random = new Random();
			var sb = new StringBuilder();
			var sum = 0;
			int value;
			for (var i = 0; i < 8; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				sum += value * (9 - i);
			}

			var digit = 11 - (sum % 11);
			if (digit == 10 || digit == 11)
			{
				digit = 0;
			}

			sb.Append(digit);
			return sb.ToString();
		}

		private static string GenerateDF()
		{
			var random = new Random();
			var sb = new StringBuilder();
			int value;
			var sum1 = 0;
			var sum2 = 0;
			for (var i = 0; i < 11; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				if (i < 3)
				{
					sum1 += value * (4 - i);
					sum2 += value * (5 - i);
				}
				else if (i < 4)
				{
					sum1 += value * (12 - i);
					sum2 += value * (5 - i);
				}
				else
				{
					sum1 += value * (12 - i);
					sum2 += value * (13 - i);
				}
			}

			var digit1 = 11 - (sum1 % 11);
			if (digit1 == 11 || digit1 == 10)
			{
				digit1 = 0;
			}

			sum2 += digit1 * 2;
			var digit2 = 11 - (sum2 % 11);
			if (digit2 == 11 || digit2 == 10)
			{
				digit2 = 0;
			}

			sb.Append(digit1);
			sb.Append(digit2);

			return sb.ToString();
		}

		private static string GenerateES()
		{
			var random = new Random();
			var sb = new StringBuilder();
			int value;

			var sum = 0;
			for (var i = 0; i < 8; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				sum += value * (9 - i);
			}

			var rest = sum % 11;
			var digit = rest > 1 ? 11 - rest : 0;
			sb.Append(digit);
			return sb.ToString();
		}

		private static string GenerateGO()
		{
			var random = new Random();
			var sb = new StringBuilder();
			int value = random.Next(3);
			var sum = 9;
			switch (value)
			{
				case 0:
					sb.Append(10);
					break;

				case 1:
					sb.Append(11);
					sum += 8;
					break;

				default:
					sb.Append(15);
					sum += 40;
					break;
			}
			for (var i = 0; i < 6; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				sum += value * (7 - i);
			}

			var rest = sum % 11;
			var fixValue = long.Parse(sb.ToString());
			var digit = 0;
			if (rest == 1)
			{
				digit = fixValue >= 10103105L && fixValue <= 10119997L ? 1 : 0;
			}
			else if (rest > 1)
			{
				digit = 11 - rest;
			}
			sb.Append(digit);
			return sb.ToString();
		}

		private static string GenerateMA()
		{
			var random = new Random();
			var sb = new StringBuilder();
			sb.Append(12);
			int value;

			var sum = 25;
			for (var i = 0; i < 6; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				sum += value * (7 - i);
			}

			var digit = 11 - (sum % 11);
			if (sum % 11 < 2)
			{
				digit = 0;
			}
			sb.Append(digit);
			return sb.ToString();
		}

		private static string GenerateMG()
		{
			var random = new Random();
			var sb = new StringBuilder();
			int value;
			for (var i = 0; i < 11; i++)
			{
				value = random.Next(10);
				sb.Append(value);
			}

			var ie = sb.ToString();
			var sbAux = new StringBuilder();
			for (var i = 0; i < 11; i++)
			{
				if (i == 3)
				{
					sbAux.Append(0);
				}
				sbAux.Append(ie[i]);
			}

			var sum = 0;
			var startWeight = 1;
			var endWeight = 2;
			var valueAux = sbAux.ToString();
			int weight;
			int calculatedValue;
			string strcalculatedValue;
			int length;
			for (var i = 0; i < sbAux.Length; i++)
			{
				weight = i % 2 == 0 ? startWeight : endWeight;
				calculatedValue = int.Parse(valueAux[i].ToString()) * weight;
				strcalculatedValue = calculatedValue.ToString();
				length = strcalculatedValue.Length;
				for (var j = 0; j < length; j++)
				{
					sum += int.Parse(strcalculatedValue[j].ToString());
				}
			}

			var sumAux = sum;
			while (sumAux % 10 != 0)
			{
				sumAux++;
			}
			var digit1 = sumAux - sum;

			var sum2 = digit1 * 2;
			startWeight = 3;
			endWeight = 11;
			for (var i = 0; i < 11; i++)
			{
				if (i < 2)
				{
					weight = startWeight;
					startWeight--;
				}
				else
				{
					weight = endWeight;
					endWeight--;
				}

				sum2 += int.Parse(ie[i].ToString()) * weight;
			}

			var digit2 = 11 - (sum2 % 11);
			if (sum2 % 11 == 0 || sum2 % 11 == 1)
			{
				digit2 = 0;
			}

			sb.Append(digit1);
			sb.Append(digit2);
			return sb.ToString();
		}

		private static string GenerateMS()
		{
			var random = new Random();
			var sb = new StringBuilder();
			int value;
			var sum = 0;
			for (var i = 0; i < 8; i++)
			{
				value = random.Next(10);
				if (i == 0)
				{
					value = 2;
				}
				else if (i == 1)
				{
					value = 8;
				}

				sb.Append(value);
				sum += value * (9 - i);
			}

			var rest = sum % 11;
			var digit = rest > 0 && rest < 10 ? 11 - rest : 0;
			sb.Append(digit);
			return sb.ToString();
		}

		private static string GenerateMT()
		{
			var random = new Random();
			var sb = new StringBuilder();
			int value;

			var sum = 0;
			for (var i = 0; i < 10; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				sum += value * ((i < 2 ? 3 : 11) - i);
			}

			var digit = 11 - (sum % 11);
			if (sum % 11 < 2)
			{
				digit = 0;
			}
			sb.Append(digit);
			return sb.ToString();
		}

		private static string GeneratePA()
		{
			var random = new Random();
			var sb = new StringBuilder();
			sb.Append(15);
			int value;

			var sum = 49;
			for (int i = 0; i < 6; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				sum += value * (7 - i);
			}

			var digit = 11 - (sum % 11);
			if (sum % 11 < 2)
			{
				digit = 0;
			}
			sb.Append(digit);
			return sb.ToString();
		}

		private static string GeneratePB()
		{
			var random = new Random();
			var sb = new StringBuilder();
			int value;

			var sum = 0;
			for (int i = 0; i < 8; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				sum += value * (9 - i);
			}

			var digit = 11 - (sum % 11);
			if (digit == 10 || digit == 11)
			{
				digit = 0;
			}
			sb.Append(digit);
			return sb.ToString();
		}

		private static string GeneratePE()
		{
			var random = new Random();
			var sb = new StringBuilder();
			int value;

			var sum1 = 0;
			var sum2 = 0;
			for (var i = 0; i < 7; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				sum1 += value * (8 - i);
				sum2 += value * (9 - i);
			}
			var rest = sum1 % 11;
			var digit1 = rest < 2 ? 0 : 11 - rest;
			sb.Append(digit1);

			sum2 += digit1 * 2;
			rest = sum2 % 11;
			var digit2 = rest < 2 ? 0 : 11 - rest;
			sb.Append(digit2);

			return sb.ToString();
		}

		private static string GeneratePI()
		{
			var random = new Random();
			var sb = new StringBuilder();
			int value;

			var sum = 0;
			for (var i = 0; i < 8; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				sum += value * (9 - i);
			}

			var digit = 11 - (sum % 11);
			if (digit == 11 || digit == 10)
			{
				digit = 0;
			}

			sb.Append(digit);
			return sb.ToString();
		}

		private static string GeneratePR()
		{
			var random = new Random();
			var sb = new StringBuilder();
			int value;

			var sum1 = 0;
			var sum2 = 0;
			int weight;
			for (var i = 0; i < 8; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				weight = (i < 2 ? 3 : 9) - i;
				sum1 += value * weight;

				weight = (i < 3 ? 4 : 10) - i;
				sum2 += value * weight;
			}

			var digit1 = 11 - (sum1 % 11);
			if ((sum1 % 11) == 0 || (sum1 % 11) == 1)
			{
				digit1 = 0;
			}

			sum2 += digit1 * 2;
			var digit2 = 11 - (sum2 % 11);
			if ((sum2 % 11) == 0 || (sum2 % 11) == 1)
			{
				digit2 = 0;
			}

			sb.Append(digit1);
			sb.Append(digit2);
			return sb.ToString();
		}

		private static string GenerateRJ()
		{
			var random = new Random();
			var sb = new StringBuilder();
			int value;

			var sum = 0;
			for (var i = 0; i < 7; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				sum += value * (i == 0 ? 2 : 8 - i);
			}

			var digit = 11 - (sum % 11);
			if ((sum % 11) <= 1)
			{
				digit = 0;
			}
			sb.Append(digit);
			return sb.ToString();
		}

		private static string GenerateRN()
		{
			var random = new Random();
			var sb = new StringBuilder();
			sb.Append(20);
			int value = random.Next(2);
			var sum = value == 0 ? 18 : 20;
			var weight = value == 0 ? 7 : 8;
			var length = value == 0 ? 6 : 7;
			for (var i = 0; i < length; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				sum += value * (weight - i);
			}

			var digit = sum * 10 % 11;
			if (digit == 10)
			{
				digit = 0;
			}
			sb.Append(digit);
			return sb.ToString();
		}

		private static string GenerateRO()
		{
			var random = new Random();
			var sb = new StringBuilder();
			int value;
			int weight;
			var sum = 0;
			for (var i = 0; i < 13; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				weight = (i < 5 ? 6 : 14) - i;
				sum += value * weight;
			}

			var digit = 11 - (sum % 11);
			if (digit == 11 || digit == 10)
			{
				digit -= 10;
			}
			sb.Append(digit);
			return sb.ToString();
		}

		private static string GenerateRR()
		{
			var random = new Random();
			var sb = new StringBuilder();
			sb.Append(24);
			int value;
			var sum = 10;
			for (int i = 0; i < 6; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				sum += value * (3 + i);
			}

			var digit = sum % 9;
			sb.Append(digit);
			return sb.ToString();
		}

		private static string GenerateRS()
		{
			var random = new Random();
			var sb = new StringBuilder();
			int value;
			var sum = 0;
			int weight;
			for (int i = 0; i < 9; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				weight = (i == 0 ? 2 : 10) - i;
				sum += value * weight;
			}

			var digit = 11 - (sum % 11);
			if (digit == 10 || digit == 11)
			{
				digit = 0;
			}
			sb.Append(digit);
			return sb.ToString();
		}

		private static string GenerateSC()
		{
			var random = new Random();
			var sb = new StringBuilder();
			int value;
			int sum = 0;
			for (var i = 0; i < 8; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				sum += value * (9 - i);
			}

			var digit = 11 - (sum % 11);
			if ((sum % 11) == 0 || (sum % 11) == 1)
			{
				digit = 0;
			}
			sb.Append(digit);
			return sb.ToString();
		}

		private static string GenerateSE()
		{
			var random = new Random();
			var sb = new StringBuilder();
			int value;
			var sum = 0;
			for (int i = 0; i < 8; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				sum += value * (9 - i);
			}

			var digit = 11 - (sum % 11);
			if (digit == 11 || digit == 10)
			{
				digit = 0;
			}
			sb.Append(digit);
			return sb.ToString();
		}

		private static string GenerateSP()
		{
			var random = new Random();
			var sb = new StringBuilder();
			int value;

			var sum = 0;
			var weight = 1;
			for (var i = 0; i < 8; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				sum += value * weight;
				weight++;

				if (weight == 2)
				{
					weight = 3;
				}
				else if (weight == 9)
				{
					weight = 10;
				}
			}

			var rest = sum % 11;
			var strDigit1 = rest.ToString()[rest.ToString().Length - 1].ToString();
			sb.Append(strDigit1);
			for (var i = 0; i < 2; i++)
			{
				value = random.Next(10);
				sb.Append(value);
			}

			var valueAux = sb.ToString();
			sum = 0;
			weight = 2;
			for (var i = 11; i >= 1; i--)
			{
				sum += int.Parse(valueAux[i - 1].ToString()) * weight;
				weight++;

				if (weight > 10)
				{
					weight = 2;
				}
			}

			rest = (sum % 11);
			var strRest = rest.ToString();
			var strDigit2 = strRest[strRest.Length - 1].ToString();
			sb.Append(strDigit2);
			return sb.ToString();
		}

		private static string GenerateTO()
		{
			var random = new Random();
			var sb = new StringBuilder();
			int value = 0;

			var empresa = "99";
			if (random.Next(10) != 9)
			{
				var allowedDigits = new int[] { 1, 2, 3 };
				while (!allowedDigits.Contains(value))
				{
					value = random.Next(4);
				}
				empresa = $"0{value}";
			}

			var sum = 0;
			for (var i = 0; i < 8; i++)
			{
				value = random.Next(10);
				sb.Append(value);
				sum += value * (9 - i);
				if (i == 1)
				{
					sb.Append(empresa);
				}
			}

			var digit = 11 - (sum % 11);
			if ((sum % 11) < 2)
			{
				digit = 0;
			}
			sb.Append(digit);
			return sb.ToString();
		}
	}
}