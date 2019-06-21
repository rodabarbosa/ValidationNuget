using Sirb.Documents.BR.Enumeration;
using Sirb.Extensions;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sirb.Documents.BR.Validation
{
	/// <summary>
	/// Inscrição Estadual
	/// </summary>
	public static class InscricaoEstadual
	{
		/// <summary>
		/// Remove mascara da Inscrição Estadual
		/// </summary>
		/// <param name="value">Inscrição Estadual</param>
		public static string RemoveMask(string value) => string.IsNullOrEmpty(value) ? value : value.OnlyNumbers();

		/// <summary>
		/// Adiciona mascara a inscrição estadual
		/// </summary>
		/// <param name="uf">Uf da Inscrição</param>
		/// <param name="value">Inscrição Estadual</param>
		public static string PlaceMask(State uf, string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return value;
			}

			switch (uf)
			{
				// 01.004.823/001-12
				case State.AC:
					return Regex.Replace(RemoveMask(value), @"(\d{2})(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3/$4-$5");

				// 12345678-9
				case State.AL:
					return Regex.Replace(RemoveMask(value), @"(\d{8})(\d{1})", "$1-$2");

				// 99.999.999-9
				case State.AM:
					return Regex.Replace(RemoveMask(value), @"(\d{2})(\d{3})(\d{3})(\d{2})", "$1.$2.$3-$4");

				// 11.111111-11
				case State.AP:
					return Regex.Replace(RemoveMask(value), @"(\d{2})(\d{6})(\d{1})", "$1.$2-$3");

				// 123456-63
				case State.BA:
					return Regex.Replace(RemoveMask(value), @"(\d{6})(\d{2})", "$1-$2");

				// 06000001-5
				case State.CE:
					return Regex.Replace(RemoveMask(value), @"(\d{8})(\d{1})", "$1.-$2");

				// 00.111111.222-33
				case State.DF:
					return Regex.Replace(RemoveMask(value), @"(\d{2})(\d{6})(\d{3})(\d{2})", "$1.$2.$3-$4");

				// No mask
				case State.ES:
					return RemoveMask(value);

				// 12.345.678-9
				case State.GO:
					return Regex.Replace(RemoveMask(value), @"(\d{2})(\d{3})(\d{3})(\d{1})", "$1.$2.$3-$4");

				case State.MA:
					return Regex.Replace(RemoveMask(value), @"(\d{2})(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3/$4-$5");

				// 062.307.904/0081
				case State.MG:
					return Regex.Replace(RemoveMask(value), @"(\d{3})(\d{3})(\d{3})(\d{4})", "$1.$2.$3/$4");

				// 11.111.111-1
				case State.MS:
					return Regex.Replace(RemoveMask(value), @"(\d{2})(\d{3})(\d{3})(\d{1})", "$1.$2.$3-$4");

				// 0013000001-9
				case State.MT:
					return Regex.Replace(RemoveMask(value), @"(\d{10})(\d{1})", "$1-$2");

				// 15-999999-5
				case State.PA:
					return Regex.Replace(RemoveMask(value), @"(\d{2})(\d{6})(\d{1})", "$1-$2-$3");

				// 12345678-9
				case State.PB:
					return Regex.Replace(RemoveMask(value), @"(\d{8})(\d{1})", "$1-$2");

				// 0321418-40
				case State.PE:
					return Regex.Replace(RemoveMask(value), @"(\d{7})(\d{2})", "$1-$2");

				//  012345679
				case State.PI:
					return RemoveMask(value);

				//  NNNNNNNN-DD
				case State.PR:
					return Regex.Replace(RemoveMask(value), @"(\d{8})(\d{2})", "$1-$2");

				// 00.000.00-0
				case State.RJ:
					return Regex.Replace(RemoveMask(value), @"(\d{2})(\d{3})(\d{2})(\d{1})", "$1.$2.$3-$4");

				// 9  d = 20.040.040-1
				// 10 d = 20.0.040.040-0
				case State.RN:
					return value.Length == 9 ?
						Regex.Replace(RemoveMask(value), @"(\d{2})(\d{3})(\d{3})(\d{1})", "$1.$2.$3-$4") :
						Regex.Replace(RemoveMask(value), @"(\d{2})(\d{1})(\d{3})(\d{3})(\d{1})", "$1.$2.$3.$4-$5");

				// 101.62521-3
				case State.RO:
					return Regex.Replace(RemoveMask(value), @"(\d{2})(\d{5})(\d{1})", "$1.$2-$3");

				// 24006628-1
				case State.RR:
					return Regex.Replace(RemoveMask(value), @"(\d{8})(\d{1})", "$1-$2");

				// 224/3658792
				case State.RS:
					return Regex.Replace(RemoveMask(value), @"(\d{3})(\d{7})", "$1/$2");

				// 251.040.852
				case State.SC:
					return Regex.Replace(RemoveMask(value), @"(\d{3})(\d{3})(\d{3})", "$1.$2.$3");

				// 27123456-3
				case State.SE:
					return Regex.Replace(RemoveMask(value), @"(\d{8})(\d{1})", "$1-$2");

				// P  d = P-01100424.3/002
				// N d = 110.042.490.114
				case State.SP:
					return value.StartsWith("P", StringComparison.OrdinalIgnoreCase) ?
						Regex.Replace(RemoveMask(value), @"(\d{8})(\d{1})(\d{3})", "P-$1.$2/$3") :
						Regex.Replace(RemoveMask(value), @"(\d{3})(\d{3})(\d{3})(\d{3})", "$1.$2.$3.$4");

				// 12.345.678-9
				case State.TO:
					return Regex.Replace(RemoveMask(value), @"(\d{2})(\d{3})(\d{3})(\d{1})", "$1.$2.$3-$4");

				default:
					throw new ArgumentException("UF não identificada.");
			}
		}

		/// <summary>
		/// Validador de inscrição estadual
		/// </summary>
		/// <param name="uf">UF</param>
		/// <param name="value">Inscricao Estadual</param>
		public static bool IsValid(State uf, string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return false;
			}

			if (uf == State.SP)
			{
				return ValidateSP(value);
			}

			switch (uf)
			{
				case State.AC: return ValidateAC(value.OnlyNumbers());

				case State.AL: return ValidateAL(value.OnlyNumbers());

				case State.AM: return ValidateAM(value.OnlyNumbers());

				case State.AP: return ValidateAP(value.OnlyNumbers());

				case State.BA: return ValidateBA(value.OnlyNumbers());

				case State.CE: return ValidateCE(value.OnlyNumbers());

				case State.DF: return ValidateDF(value.OnlyNumbers());

				case State.ES: return ValidateES(value.OnlyNumbers());

				case State.GO: return ValidateGO(value.OnlyNumbers());

				case State.MA: return ValidateMA(value.OnlyNumbers());

				case State.MG: return ValidateMG(value.OnlyNumbers());

				case State.MS: return ValidateMS(value.OnlyNumbers());

				case State.MT: return ValidateMT(value.OnlyNumbers());

				case State.PA: return ValidatePA(value.OnlyNumbers());

				case State.PB: return ValidatePB(value.OnlyNumbers());

				case State.PE: return ValidatePE(value.OnlyNumbers());

				case State.PI: return ValidatePI(value.OnlyNumbers());

				case State.PR: return ValidatePR(value.OnlyNumbers());

				case State.RJ: return ValidateRJ(value.OnlyNumbers());

				case State.RN: return ValidateRN(value.OnlyNumbers());

				case State.RO: return ValidateRO(value.OnlyNumbers());

				case State.RR: return ValidateRR(value.OnlyNumbers());

				case State.RS: return ValidateRS(value.OnlyNumbers());

				case State.SC: return ValidateSC(value.OnlyNumbers());

				case State.SE: return ValidateSE(value.OnlyNumbers());

				case State.SP: return ValidateSP(value.OnlyNumbers());

				case State.TO: return ValidateTO(value.OnlyNumbers());

				default:
					throw new ArgumentException("A UF informada não é válida.");
			}
		}

		private static bool ValidateAC(string value)
		{
			if (value.Length != 13 && !value.StartsWith("01"))
			{
				return false;
			}

			var sum = 0;
			var startWeight = 4;
			var endWeight = 9;
			int weight;
			for (var i = 0; i < 11; i++)
			{
				if (i < 3)
				{
					weight = startWeight;
					startWeight--;
				}
				else
				{
					weight = endWeight;
					endWeight--;
				}

				sum += int.Parse(value[i].ToString()) * weight;
			}

			var digit1 = 11 - (sum % 11);
			if (digit1 == 10 || digit1 == 11)
			{
				digit1 = 0;
			}

			sum = digit1 * 2;
			startWeight = 5;
			endWeight = 9;
			for (var i = 0; i < 11; i++)
			{
				if (i < 4)
				{
					weight = startWeight;
					startWeight--;
				}
				else
				{
					weight = endWeight;
					endWeight--;
				}

				sum += int.Parse(value[i].ToString()) * weight;
			}

			var digit2 = 11 - (sum % 11);
			if (digit2 == 10 || digit2 == 11)
			{
				digit2 = 0;
			}

			var dv = digit1.ToString() + digit2.ToString();
			return value.EndsWith(dv);
		}

		private static bool ValidateAL(string value)
		{
			if (value.Length != 9 || !value.StartsWith("24"))
			{
				return false;
			}

			var thirdDigitAllowed = new int[] { 0, 3, 5, 7, 8 };
			var thirdDigit = int.Parse(value[2].ToString());
			if (!thirdDigitAllowed.Contains(thirdDigit))
			{
				return false;
			}

			var sum = 0;
			for (var i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
			}

			var digit = sum * 10 % 11;
			if (digit == 10)
			{
				digit = 0;
			}

			return value.EndsWith(digit.ToString());
		}

		private static bool ValidateAM(string value)
		{
			if (value.Length != 9)
			{
				return false;
			}

			var sum = 0;
			for (var i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
			}

			var aux = sum < 11 ? sum : sum % 11;
			var digit = aux > 1 ? 11 - aux : 0;
			return value.EndsWith(digit.ToString());
		}

		private static bool ValidateAP(string value)
		{
			if (value.Length != 9 || !value.StartsWith("03"))
			{
				return false;
			}

			var digit1 = -1;
			var sum = -1;
			var x = long.Parse(value.Substring(1, 8));
			if (x >= 3017001L && x <= 3019022L)
			{
				digit1 = 1;
				sum = 9;
			}
			else if (x >= 3000001L && x <= 3017000L)
			{
				digit1 = 0;
				sum = 5;
			}
			else if (x >= 3019023L)
			{
				digit1 = 0;
				sum = 0;
			}

			for (var i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
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

			return value.EndsWith(digit.ToString());
		}

		private static bool ValidateBA(string value)
		{
			if (value.Length < 8 && value.Length > 9)
			{
				return false;
			}

			var module = 10;
			var firstDigitIndex = value.Length == 8 ? 0 : 1;
			var firstDigit = int.Parse(value[firstDigitIndex].ToString());
			var digitForModuleEleven = new int[] { 6, 7, 9 };
			if (digitForModuleEleven.Contains(firstDigit))
			{
				module = 11;
			}

			var sum = 0;
			var length = value.Length;
			var weight = length == 8 ? 7 : 8;
			for (var i = 0; i < length - 2; i++)
			{
				sum += int.Parse(value[i].ToString()) * (weight - i);
			}

			var rest = sum % module;
			var digit2 = rest == 0 || (module == 11 && rest == 1) ? 0 : module - rest;
			sum = digit2 * 2;
			length =
			weight = length == 8 ? 8 : 9;
			for (var i = 0; i < length - 2; i++)
			{
				sum += int.Parse(value[i].ToString()) * (weight - i);
			}

			rest = sum % module;
			var digit1 = rest == 0 || (module == 11 && rest == 1) ? 0 : module - rest;
			var dv = digit1.ToString() + digit2.ToString();
			return value.EndsWith(dv);
		}

		private static bool ValidateCE(string value)
		{
			if (value.Length != 9)
			{
				return false;
			}

			var sum = 0;
			for (var i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
			}

			var digit = 11 - (sum % 11);
			if (digit == 10 || digit == 11)
			{
				digit = 0;
			}

			return value.EndsWith(digit.ToString());
		}

		private static bool ValidateDF(string value)
		{
			if (value.Length != 13)
			{
				return false;
			}

			var sum = 0;
			var startWeight = 4;
			var endWeight = 9;
			int weight;
			for (var i = 0; i < 11; i++)
			{
				if (i < 3)
				{
					weight = startWeight;
					startWeight--;
				}
				else
				{
					weight = endWeight;
					endWeight--;
				}

				sum += int.Parse(value[i].ToString()) * weight;
			}

			var digit1 = 11 - (sum % 11);
			if (digit1 == 11 || digit1 == 10)
			{
				digit1 = 0;
			}

			sum = digit1 * 2;
			startWeight = 5;
			endWeight = 9;
			for (var i = 0; i < 11; i++)
			{
				if (i < 4)
				{
					weight = startWeight;
					startWeight--;
				}
				else
				{
					weight = endWeight;
					endWeight--;
				}

				sum += int.Parse(value[i].ToString()) * weight;
			}

			var digit2 = 11 - (sum % 11);
			if (digit2 == 11 || digit2 == 10)
			{
				digit2 = 0;
			}

			var dv = digit1.ToString() + digit2.ToString();
			return value.EndsWith(dv);
		}

		private static bool ValidateES(string value)
		{
			if (value.Length != 9)
			{
				return false;
			}

			var sum = 0;
			for (var i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
			}

			var rest = sum % 11;
			var digit = rest > 1 ? 11 - rest : 0;
			return value.EndsWith(digit.ToString());
		}

		private static bool ValidateGO(string value)
		{
			var startDigitsAllowed = new string[] { "10", "11", "15" };
			var startDigit = value.Substring(0, 2);
			if (value.Length != 9 || !startDigitsAllowed.Contains(startDigit))
			{
				return false;
			}

			var lastDigit = int.Parse(value[8].ToString());
			if (value.StartsWith("11094402") && lastDigit > 1)
			{
				return false;
			}

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
			{
				digit = fixValue >= 10103105L && fixValue <= 10119997L ? 1 : 0;
			}
			else if (rest > 1)
			{
				digit = 11 - rest;
			}

			return value.EndsWith(digit.ToString());
		}

		private static bool ValidateMA(string value)
		{
			if (value.Length != 9 && !value.StartsWith("12"))
			{
				return false;
			}

			var sum = 0;
			for (var i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
			}

			var digit = 11 - (sum % 11);
			if (sum % 11 < 2)
			{
				digit = 0;
			}

			return value.EndsWith(digit.ToString());
		}

		private static bool ValidateMG(string value)
		{
			if (value.Length != 13)
			{
				return false;
			}

			var sb = new StringBuilder();
			for (var i = 0; i < 11; i++)
			{
				sb.Append(i == 3 ? $"0{value[i].ToString()}" : value[i].ToString());
			}

			var sum = 0;
			var startWeight = 1;
			var endWeight = 2;
			var valueAux = sb.ToString();
			int weight;
			int calculatedValue;
			string strcalculatedValue;
			int length;
			for (var i = 0; i < sb.Length; i++)
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

			sum = digit1 * 2;
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

				sum += int.Parse(value[i].ToString()) * weight;
			}

			var digit2 = 11 - (sum % 11);
			if (sum % 11 == 0 || sum % 11 == 1)
			{
				digit2 = 0;
			}

			var dv = digit1.ToString() + digit2.ToString();
			return value.EndsWith(dv);
		}

		private static bool ValidateMS(string value)
		{
			if (value.Length != 9 || !value.StartsWith("28"))
			{
				return false;
			}

			var sum = 0;
			for (var i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
			}

			var rest = sum % 11;
			var digit = rest > 0 && rest < 10 ? 11 - rest : 0;
			return value.EndsWith(digit.ToString());
		}

		private static bool ValidateMT(string value)
		{
			if (value.Length != 11)
			{
				return false;
			}

			var sum = 0;
			var startWeight = 3;
			var endWeight = 9;
			int weight;
			for (int i = 0; i < 10; i++)
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
				sum += int.Parse(value[i].ToString()) * weight;
			}

			var digit = 11 - (sum % 11);
			if (sum % 11 < 2)
			{
				digit = 0;
			}

			return value.EndsWith(digit.ToString());
		}

		private static bool ValidatePA(string value)
		{
			if (value.Length != 9 && !value.StartsWith("15"))
			{
				return false;
			}

			var sum = 0;
			for (int i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
			}

			var digit = 11 - (sum % 11);
			if (sum % 11 < 2)
			{
				digit = 0;
			}

			return value.EndsWith(digit.ToString());
		}

		private static bool ValidatePB(string value)
		{
			if (value.Length != 9)
			{
				return false;
			}

			var sum = 0;
			for (int i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
			}

			var digit = 11 - (sum % 11);
			if (digit == 10 || digit == 11)
			{
				digit = 0;
			}

			return value.EndsWith(digit.ToString());
		}

		private static bool ValidatePE(string value)
		{
			var valueAux = value.PadRight(14, '0');
			var sum = 0;
			var weight = 2;
			for (var i = 7; i >= 1; i--)
			{
				sum += int.Parse(valueAux[i - 1].ToString()) * weight;
				weight++;

				if (weight > 9)
				{
					weight = 2;
				}
			}

			var rest = sum % 11;
			var aux = 11 - rest;
			if (aux > 9)
			{
				aux -= 10;
			}

			var str = aux.ToString();
			var strDigit1 = str.Substring(str.Length - 1);
			var valueAux2 = valueAux.Substring(0, 7) + strDigit1;
			if (!valueAux2.Equals(value.Substring(0, 8)))
			{
				return false;
			}

			sum = 0;
			weight = 2;
			for (var i = 8; i >= 1; i--)
			{
				sum += int.Parse(valueAux[i - 1].ToString()) * weight;
				weight++;
				if (weight > 9)
				{
					weight = 2;
				}
			}

			rest = sum % 11;
			aux = 11 - rest;
			if (aux > 9)
			{
				aux -= 10;
			}
			str = aux.ToString();
			var strDigit2 = str.Substring(str.Length - 1);
			valueAux2 = valueAux.Substring(0, 8) + strDigit2;
			return valueAux2 == value;
		}

		private static bool ValidatePI(string value)
		{
			if (value.Length != 9)
			{
				return false;
			}

			var sum = 0;
			for (var i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
			}

			var digit = 11 - (sum % 11);
			if (digit == 11 || digit == 10)
			{
				digit = 0;
			}

			return value.EndsWith(digit.ToString());
		}

		private static bool ValidatePR(string value)
		{
			if (value.Length != 10)
			{
				return false;
			}

			var sum1 = 0;
			var sum2 = 0;
			int weight;
			int valueParse;
			for (var i = 0; i < 8; i++)
			{
				valueParse = int.Parse(value[i].ToString());
				weight = (i < 2 ? 3 : 9) - i;
				sum1 += valueParse * weight;

				weight = (i < 3 ? 4 : 10) - i;
				sum2 += valueParse * weight;
			}

			var digit1 = 11 - (sum1 % 11);
			if ((sum1 % 11) == 0 || (sum1 % 11) == 1)
			{
				digit1 = 0;
			}

			sum2 += digit1 * 2;
			var digit2 = 11 - (sum2 % 11);
			if ((sum2 % 11) < 2)
			{
				digit2 = 0;
			}

			var dv = digit1.ToString() + digit2.ToString();
			return value.EndsWith(dv);
		}

		private static bool ValidateRJ(string value)
		{
			if (value.Length != 8)
			{
				return false;
			}

			var sum = 0;
			int weight;
			for (var i = 0; i < 7; i++)
			{
				weight = (i == 0 ? 2 : 8) - i;
				sum += int.Parse(value[i].ToString()) * weight;
			}

			var digit = 11 - (sum % 11);
			if ((sum % 11) <= 1)
			{
				digit = 0;
			}

			return value.EndsWith(digit.ToString());
		}

		private static bool ValidateRN(string value)
		{
			var weight = value.Length;
			if (weight < 9 && weight > 10 && !value.StartsWith("20"))
			{
				return false;
			}
			var length = value.Length - 1;
			var sum = 0;
			for (var i = 0; i < length; i++)
			{
				sum += int.Parse(value[i].ToString()) * (weight - i);
			}

			var digit = sum * 10 % 11;
			if (digit == 10)
			{
				digit = 0;
			}

			return value.EndsWith(digit.ToString());
		}

		private static bool ValidateRO(string value)
		{
			if (value.Length != 14)
			{
				return false;
			}

			var sum = 0;
			int weight;
			for (var i = 0; i < 13; i++)
			{
				weight = (i < 5 ? 6 : 14) - i;
				sum += int.Parse(value[i].ToString()) * weight;
			}

			var digit = 11 - (sum % 11);
			if (digit == 11 || digit == 10)
			{
				digit -= 10;
			}

			return value.EndsWith(digit.ToString());
		}

		private static bool ValidateRR(string value)
		{
			if (value.Length != 9 && !value.StartsWith("24"))
			{
				return false;
			}

			var sum = 0;
			for (int i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (1 + i);
			}

			var digit = sum % 9;
			return value.EndsWith(digit.ToString());
		}

		private static bool ValidateRS(string value)
		{
			if (value.Length != 10)
			{
				return false;
			}

			var sum = int.Parse(value[0].ToString()) * 2;
			for (int i = 1; i < 9; i++)
			{
				sum += int.Parse(value[i].ToString()) * (10 - i);
			}

			var digit = 11 - (sum % 11);
			if (digit == 10 || digit == 11)
			{
				digit = 0;
			}

			return value.EndsWith(digit.ToString());
		}

		private static bool ValidateSC(string value)
		{
			if (value.Length != 9)
			{
				return false;
			}

			int sum = 0;
			for (var i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
			}

			var digit = 11 - (sum % 11);
			if ((sum % 11) == 0 || (sum % 11) == 1)
			{
				digit = 0;
			}
			return value.EndsWith(digit.ToString());
		}

		private static bool ValidateSE(string value)
		{
			if (value.Length != 9)
			{
				return false;
			}

			var sum = 0;
			for (int i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
			}

			var digit = 11 - (sum % 11);
			if (digit == 11 || digit == 10)
			{
				digit = 0;
			}

			return value.EndsWith(digit.ToString());
		}

		private static bool ValidateSP(string value)
		{
			return value.StartsWith("P", StringComparison.OrdinalIgnoreCase) ? ValidateSPWithP(value.OnlyNumbers()) : ValidateSPCommom(value.OnlyNumbers());
		}

		private static bool ValidateSPWithP(string value)
		{
			var valueAux = value.PadRight(12, '0');
			var sum = 0;
			var weight = 1;
			for (var i = 0; i < 8; i++)
			{
				sum += int.Parse(valueAux[i].ToString()) * weight;
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

			var rest = (sum % 11);
			var strRest = rest.ToString();
			var strDigit1 = strRest[strRest.Length - 1].ToString();

			var valueAux2 = valueAux.Substring(0, 8) + (strDigit1 + valueAux.Substring(9, 3));
			return valueAux2.Equals(value);
		}

		private static bool ValidateSPCommom(string value)
		{
			var valueAux = value.PadRight(12, '0');
			var sum = 0;
			var weight = 1;

			for (var i = 0; i < 8; i++)
			{
				sum += int.Parse(valueAux[i].ToString()) * weight;
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
			var strRest = rest.ToString();
			var strDigit1 = strRest[strRest.Length - 1].ToString();

			var valueAux2 = (valueAux.Substring(0, 8) + (strDigit1 + valueAux.Substring(9, 2)));
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
			strRest = rest.ToString();
			var strDigit2 = strRest[strRest.Length - 1].ToString();
			valueAux2 += strDigit2;

			return valueAux2.Equals(value);
		}

		private static bool ValidateTO(string value)
		{
			if (!(value.Length == 9 || value.Length == 11))
			{
				return false;
			}

			var valueAux = value;
			if (value.Length == 9)
			{
				valueAux = value.Substring(0, 2) + "02" + value.Substring(1, value.Length);
			}

			var sum = 0;
			var weight = 9;
			for (var i = 0; i < valueAux.Length - 1; i++)
			{
				if (i != 2 && i != 3)
				{
					sum += int.Parse(valueAux[i].ToString()) * weight;
					weight--;
				}
			}

			var digit = 11 - (sum % 11);
			if ((sum % 11) < 2)
			{
				digit = 0;
			}

			return valueAux.EndsWith(digit.ToString());
		}
	}
}