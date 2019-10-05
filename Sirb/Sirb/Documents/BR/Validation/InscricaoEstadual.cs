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
		/// <param name="state">Uf da Inscrição</param>
		/// <param name="value">Inscrição Estadual</param>
		public static string PlaceMask(State state, string value)
		{
			if (string.IsNullOrEmpty(value))
				return value;

			switch (state)
			{
				// 01.004.823/001-12
				case State.AC: return StateMaskAC(value);

				// 12345678-9
				case State.AL: return StateMaskAL(value);

				// 99.999.999-9
				case State.AM: return StateMaskAM(value);

				// 11.111111-11
				case State.AP: return StateMaskAP(value);

				// 123456-63
				case State.BA: return StateMaskBA(value);

				// 06000001-5
				case State.CE: return StateMaskCE(value);

				// 00.111111.222-33
				case State.DF: return StateMaskDF(value);

				// No mask
				case State.ES: return StateMaskES(value);

				// 12.345.678-9
				case State.GO: return StateMaskGO(value);

				case State.MA: return StateMaskMA(value);

				// 062.307.904/0081
				case State.MG: return StateMaskMG(value);

				// 11.111.111-1
				case State.MS: return StateMaskMS(value);

				// 0013000001-9
				case State.MT: return StateMaskMT(value);

				// 15-999999-5
				case State.PA: return StateMaskPA(value);

				// 12345678-9
				case State.PB: return StateMaskPB(value);

				// 0321418-40
				case State.PE: return StateMaskPE(value);

				// 012345679
				case State.PI: return StateMaskPI(value);

				// NNNNNNNN-DD
				case State.PR: return StateMaskPR(value);

				// 00.000.00-0
				case State.RJ: return StateMaskRJ(value);

				// 9 d = 20.040.040-1 10 d = 20.0.040.040-0
				case State.RN: return StateMaskRN(value);

				// 101.62521-3
				case State.RO: return StateMaskRO(value);

				// 24006628-1
				case State.RR: return StateMaskRR(value);

				// 224/3658792
				case State.RS: return StateMaskRS(value);

				// 251.040.852
				case State.SC: return StateMaskSC(value);

				// 27123456-3
				case State.SE: return StateMaskSE(value);

				// P d = P-01100424.3/002 N d = 110.042.490.114
				case State.SP: return StateMaskSP(value);

				// 12.345.678-9
				case State.TO: return StateMaskTO(value);

				default:
					throw new ArgumentException("UF não identificada.");
			}
		}

		#region MASKS

		private static string StateMaskAC(string value) => Regex.Replace(RemoveMask(value), @"(\d{2})(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3/$4-$5");

		private static string StateMaskAL(string value) => Regex.Replace(RemoveMask(value), @"(\d{8})(\d{1})", "$1-$2");

		private static string StateMaskAM(string value) => Regex.Replace(RemoveMask(value), @"(\d{2})(\d{3})(\d{3})(\d{2})", "$1.$2.$3-$4");

		private static string StateMaskAP(string value) => Regex.Replace(RemoveMask(value), @"(\d{2})(\d{6})(\d{1})", "$1.$2-$3");

		private static string StateMaskBA(string value) => Regex.Replace(RemoveMask(value), @"(\d{6})(\d{2})", "$1-$2");

		private static string StateMaskCE(string value) => Regex.Replace(RemoveMask(value), @"(\d{8})(\d{1})", "$1.-$2");

		private static string StateMaskDF(string value) => Regex.Replace(RemoveMask(value), @"(\d{2})(\d{6})(\d{3})(\d{2})", "$1.$2.$3-$4");

		private static string StateMaskES(string value) => RemoveMask(value);

		private static string StateMaskGO(string value) => Regex.Replace(RemoveMask(value), @"(\d{2})(\d{3})(\d{3})(\d{1})", "$1.$2.$3-$4");

		private static string StateMaskMA(string value) => Regex.Replace(RemoveMask(value), @"(\d{2})(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3/$4-$5");

		private static string StateMaskMG(string value) => Regex.Replace(RemoveMask(value), @"(\d{3})(\d{3})(\d{3})(\d{4})", "$1.$2.$3/$4");

		private static string StateMaskMS(string value) => Regex.Replace(RemoveMask(value), @"(\d{2})(\d{3})(\d{3})(\d{1})", "$1.$2.$3-$4");

		private static string StateMaskMT(string value) => Regex.Replace(RemoveMask(value), @"(\d{10})(\d{1})", "$1-$2");

		private static string StateMaskPA(string value) => Regex.Replace(RemoveMask(value), @"(\d{2})(\d{6})(\d{1})", "$1-$2-$3");

		private static string StateMaskPB(string value) => Regex.Replace(RemoveMask(value), @"(\d{8})(\d{1})", "$1-$2");

		private static string StateMaskPE(string value) => Regex.Replace(RemoveMask(value), @"(\d{7})(\d{2})", "$1-$2");

		private static string StateMaskPI(string value) => RemoveMask(value);

		private static string StateMaskPR(string value) => Regex.Replace(RemoveMask(value), @"(\d{8})(\d{2})", "$1-$2");

		private static string StateMaskRJ(string value) => Regex.Replace(RemoveMask(value), @"(\d{2})(\d{3})(\d{2})(\d{1})", "$1.$2.$3-$4");

		private static string StateMaskRN(string value)
		{
			string onlyNumbersValue = RemoveMask(value);
			return onlyNumbersValue.Length == 9 ?
					 Regex.Replace(onlyNumbersValue, @"(\d{2})(\d{3})(\d{3})(\d{1})", "$1.$2.$3-$4") :
					 Regex.Replace(onlyNumbersValue, @"(\d{2})(\d{1})(\d{3})(\d{3})(\d{1})", "$1.$2.$3.$4-$5");
		}

		private static string StateMaskRO(string value) => Regex.Replace(RemoveMask(value), @"(\d{2})(\d{5})(\d{1})", "$1.$2-$3");

		private static string StateMaskRR(string value) => Regex.Replace(RemoveMask(value), @"(\d{8})(\d{1})", "$1-$2");

		private static string StateMaskRS(string value) => Regex.Replace(RemoveMask(value), @"(\d{3})(\d{7})", "$1/$2");

		private static string StateMaskSC(string value) => Regex.Replace(RemoveMask(value), @"(\d{3})(\d{3})(\d{3})", "$1.$2.$3");

		private static string StateMaskSE(string value) => Regex.Replace(RemoveMask(value), @"(\d{8})(\d{1})", "$1-$2");

		private static string StateMaskSP(string value)
		{
			string aux = RemoveMask(value);
			return value.StartsWith("P", StringComparison.OrdinalIgnoreCase) ?
					Regex.Replace(aux, @"(\d{8})(\d{1})(\d{3})", "P-$1.$2/$3") :
					Regex.Replace(aux, @"(\d{3})(\d{3})(\d{3})(\d{3})", "$1.$2.$3.$4");
		}

		private static string StateMaskTO(string value) => Regex.Replace(RemoveMask(value), @"(\d{2})(\d{3})(\d{3})(\d{1})", "$1.$2.$3-$4");

		#endregion MASKS

		/// <summary>
		/// Validador de inscrição estadual
		/// </summary>
		/// <param name="state">UF</param>
		/// <param name="value">Inscricao Estadual</param>
		public static bool IsValid(State state, string value)
		{
			if (string.IsNullOrEmpty(value))
				return false;

			string onlyNumberValue = RemoveMask(value);
			switch (state)
			{
				case State.AC: return ValidateAC(onlyNumberValue);

				case State.AL: return ValidateAL(onlyNumberValue);

				case State.AM: return ValidateAM(onlyNumberValue);

				case State.AP: return ValidateAP(onlyNumberValue);

				case State.BA: return ValidateBA(onlyNumberValue);

				case State.CE: return ValidateCE(onlyNumberValue);

				case State.DF: return ValidateDF(onlyNumberValue);

				case State.ES: return ValidateES(onlyNumberValue);

				case State.GO: return ValidateGO(onlyNumberValue);

				case State.MA: return ValidateMA(onlyNumberValue);

				case State.MG: return ValidateMG(onlyNumberValue);

				case State.MS: return ValidateMS(onlyNumberValue);

				case State.MT: return ValidateMT(onlyNumberValue);

				case State.PA: return ValidatePA(onlyNumberValue);

				case State.PB: return ValidatePB(onlyNumberValue);

				case State.PE: return ValidatePE(onlyNumberValue);

				case State.PI: return ValidatePI(onlyNumberValue);

				case State.PR: return ValidatePR(onlyNumberValue);

				case State.RJ: return ValidateRJ(onlyNumberValue);

				case State.RN: return ValidateRN(onlyNumberValue);

				case State.RO: return ValidateRO(onlyNumberValue);

				case State.RR: return ValidateRR(onlyNumberValue);

				case State.RS: return ValidateRS(onlyNumberValue);

				case State.SC: return ValidateSC(onlyNumberValue);

				case State.SE: return ValidateSE(onlyNumberValue);

				case State.SP: return ValidateSP(value);

				case State.TO: return ValidateTO(onlyNumberValue);

				default:
					throw new ArgumentException("A UF informada não é válida.");
			}
		}

		#region VALIDATIONS

		private static bool ValidateAC(string value)
		{
			if (value.Length != 13 && !value.StartsWith("01"))
			{
				return false;
			}

			int sum = 0;
			int startWeight = 4;
			int endWeight = 9;
			int weight;
			for (int i = 0; i < 11; i++)
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

			int digit1 = 11 - (sum % 11);
			if (digit1 == 10 || digit1 == 11)
			{
				digit1 = 0;
			}

			sum = digit1 * 2;
			startWeight = 5;
			endWeight = 9;
			for (int i = 0; i < 11; i++)
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

			int digit2 = 11 - (sum % 11);
			if (digit2 == 10 || digit2 == 11)
			{
				digit2 = 0;
			}

			string dv = digit1.ToString() + digit2.ToString();
			return value.EndsWith(dv);
		}

		private static bool ValidateAL(string value)
		{
			if (value.Length != 9 || !value.StartsWith("24"))
			{
				return false;
			}

			int[] thirdDigitAllowed = new int[] { 0, 3, 5, 7, 8 };
			int thirdDigit = int.Parse(value[2].ToString());
			if (!thirdDigitAllowed.Contains(thirdDigit))
			{
				return false;
			}

			int sum = 0;
			for (int i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
			}

			int digit = sum * 10 % 11;
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

			int sum = 0;
			for (int i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
			}

			int aux = sum < 11 ? sum : sum % 11;
			int digit = aux > 1 ? 11 - aux : 0;
			return value.EndsWith(digit.ToString());
		}

		private static bool ValidateAP(string value)
		{
			if (value.Length != 9 || !value.StartsWith("03"))
			{
				return false;
			}

			int digit1 = -1;
			int sum = -1;
			long x = long.Parse(value.Substring(1, 8));
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

			for (int i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
			}

			int digit = 11 - (sum % 11);
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

			int module = 10;
			int firstDigitIndex = value.Length == 8 ? 0 : 1;
			int firstDigit = int.Parse(value[firstDigitIndex].ToString());
			int[] digitForModuleEleven = new int[] { 6, 7, 9 };
			if (digitForModuleEleven.Contains(firstDigit))
			{
				module = 11;
			}

			int sum = 0;
			int length = value.Length;
			int weight = length == 8 ? 7 : 8;
			for (int i = 0; i < length - 2; i++)
			{
				sum += int.Parse(value[i].ToString()) * (weight - i);
			}

			int rest = sum % module;
			int digit2 = rest == 0 || (module == 11 && rest == 1) ? 0 : module - rest;
			sum = digit2 * 2;
			length =
			weight = length == 8 ? 8 : 9;
			for (int i = 0; i < length - 2; i++)
			{
				sum += int.Parse(value[i].ToString()) * (weight - i);
			}

			rest = sum % module;
			int digit1 = rest == 0 || (module == 11 && rest == 1) ? 0 : module - rest;
			string dv = digit1.ToString() + digit2.ToString();
			return value.EndsWith(dv);
		}

		private static bool ValidateCE(string value)
		{
			if (value.Length != 9)
			{
				return false;
			}

			int sum = 0;
			for (int i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
			}

			int digit = 11 - (sum % 11);
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

			int sum = 0;
			int startWeight = 4;
			int endWeight = 9;
			int weight;
			for (int i = 0; i < 11; i++)
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

			int digit1 = 11 - (sum % 11);
			if (digit1 == 11 || digit1 == 10)
			{
				digit1 = 0;
			}

			sum = digit1 * 2;
			startWeight = 5;
			endWeight = 9;
			for (int i = 0; i < 11; i++)
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

			int digit2 = 11 - (sum % 11);
			if (digit2 == 11 || digit2 == 10)
			{
				digit2 = 0;
			}

			string dv = digit1.ToString() + digit2.ToString();
			return value.EndsWith(dv);
		}

		private static bool ValidateES(string value)
		{
			if (value.Length != 9)
			{
				return false;
			}

			int sum = 0;
			for (int i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
			}

			int rest = sum % 11;
			int digit = rest > 1 ? 11 - rest : 0;
			return value.EndsWith(digit.ToString());
		}

		private static bool ValidateGO(string value)
		{
			string[] startDigitsAllowed = new string[] { "10", "11", "15" };
			string startDigit = value.Substring(0, 2);
			if (value.Length != 9 || !startDigitsAllowed.Contains(startDigit))
			{
				return false;
			}

			int lastDigit = int.Parse(value[8].ToString());
			if (value.StartsWith("11094402") && lastDigit > 1)
			{
				return false;
			}

			int sum = 0;
			int weight = 9;
			for (int i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * weight;
				weight--;
			}

			int rest = sum % 11;
			long fixValue = long.Parse(value.Substring(0, 8));
			int digit = 0;
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

			int sum = 0;
			for (int i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
			}

			int digit = 11 - (sum % 11);
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

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < 11; i++)
			{
				sb.Append(i == 3 ? $"0{value[i].ToString()}" : value[i].ToString());
			}

			int sum = 0;
			int startWeight = 1;
			int endWeight = 2;
			string valueAux = sb.ToString();
			int weight;
			int calculatedValue;
			string strcalculatedValue;
			int length;
			for (int i = 0; i < sb.Length; i++)
			{
				weight = i % 2 == 0 ? startWeight : endWeight;
				calculatedValue = int.Parse(valueAux[i].ToString()) * weight;
				strcalculatedValue = calculatedValue.ToString();
				length = strcalculatedValue.Length;
				for (int j = 0; j < length; j++)
				{
					sum += int.Parse(strcalculatedValue[j].ToString());
				}
			}

			int sumAux = sum;
			while (sumAux % 10 != 0)
			{
				sumAux++;
			}
			int digit1 = sumAux - sum;

			sum = digit1 * 2;
			startWeight = 3;
			endWeight = 11;
			for (int i = 0; i < 11; i++)
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

			int digit2 = 11 - (sum % 11);
			if (sum % 11 == 0 || sum % 11 == 1)
			{
				digit2 = 0;
			}

			string dv = digit1.ToString() + digit2.ToString();
			return value.EndsWith(dv);
		}

		private static bool ValidateMS(string value)
		{
			if (value.Length != 9 || !value.StartsWith("28"))
			{
				return false;
			}

			int sum = 0;
			for (int i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
			}

			int rest = sum % 11;
			int digit = rest > 0 && rest < 10 ? 11 - rest : 0;
			return value.EndsWith(digit.ToString());
		}

		private static bool ValidateMT(string value)
		{
			if (value.Length != 11)
			{
				return false;
			}

			int sum = 0;
			int startWeight = 3;
			int endWeight = 9;
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

			int digit = 11 - (sum % 11);
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

			int sum = 0;
			for (int i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
			}

			int digit = 11 - (sum % 11);
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

			int sum = 0;
			for (int i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
			}

			int digit = 11 - (sum % 11);
			if (digit == 10 || digit == 11)
			{
				digit = 0;
			}

			return value.EndsWith(digit.ToString());
		}

		private static bool ValidatePE(string value)
		{
			string valueAux = value.PadRight(14, '0');
			int sum = 0;
			int weight = 2;
			for (int i = 7; i >= 1; i--)
			{
				sum += int.Parse(valueAux[i - 1].ToString()) * weight;
				weight++;

				if (weight > 9)
				{
					weight = 2;
				}
			}

			int rest = sum % 11;
			int aux = 11 - rest;
			if (aux > 9)
			{
				aux -= 10;
			}

			string str = aux.ToString();
			string strDigit1 = str.Substring(str.Length - 1);
			string valueAux2 = valueAux.Substring(0, 7) + strDigit1;
			if (!valueAux2.Equals(value.Substring(0, 8)))
			{
				return false;
			}

			sum = 0;
			weight = 2;
			for (int i = 8; i >= 1; i--)
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
			string strDigit2 = str.Substring(str.Length - 1);
			valueAux2 = valueAux.Substring(0, 8) + strDigit2;
			return valueAux2 == value;
		}

		private static bool ValidatePI(string value)
		{
			if (value.Length != 9)
			{
				return false;
			}

			int sum = 0;
			for (int i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
			}

			int digit = 11 - (sum % 11);
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

			int sum1 = 0;
			int sum2 = 0;
			int weight;
			int valueParse;
			for (int i = 0; i < 8; i++)
			{
				valueParse = int.Parse(value[i].ToString());
				weight = (i < 2 ? 3 : 9) - i;
				sum1 += valueParse * weight;

				weight = (i < 3 ? 4 : 10) - i;
				sum2 += valueParse * weight;
			}

			int digit1 = 11 - (sum1 % 11);
			if ((sum1 % 11) == 0 || (sum1 % 11) == 1)
			{
				digit1 = 0;
			}

			sum2 += digit1 * 2;
			int digit2 = 11 - (sum2 % 11);
			if ((sum2 % 11) < 2)
			{
				digit2 = 0;
			}

			string dv = digit1.ToString() + digit2.ToString();
			return value.EndsWith(dv);
		}

		private static bool ValidateRJ(string value)
		{
			if (value.Length != 8)
			{
				return false;
			}

			int sum = 0;
			int weight;
			for (int i = 0; i < 7; i++)
			{
				weight = (i == 0 ? 2 : 8) - i;
				sum += int.Parse(value[i].ToString()) * weight;
			}

			int digit = 11 - (sum % 11);
			if ((sum % 11) <= 1)
			{
				digit = 0;
			}

			return value.EndsWith(digit.ToString());
		}

		private static bool ValidateRN(string value)
		{
			int weight = value.Length;
			if (weight < 9 && weight > 10 && !value.StartsWith("20"))
			{
				return false;
			}
			int length = value.Length - 1;
			int sum = 0;
			for (int i = 0; i < length; i++)
			{
				sum += int.Parse(value[i].ToString()) * (weight - i);
			}

			int digit = sum * 10 % 11;
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

			int sum = 0;
			int weight;
			for (int i = 0; i < 13; i++)
			{
				weight = (i < 5 ? 6 : 14) - i;
				sum += int.Parse(value[i].ToString()) * weight;
			}

			int digit = 11 - (sum % 11);
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

			int sum = 0;
			for (int i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (1 + i);
			}

			int digit = sum % 9;
			return value.EndsWith(digit.ToString());
		}

		private static bool ValidateRS(string value)
		{
			if (value.Length != 10)
			{
				return false;
			}

			int sum = int.Parse(value[0].ToString()) * 2;
			for (int i = 1; i < 9; i++)
			{
				sum += int.Parse(value[i].ToString()) * (10 - i);
			}

			int digit = 11 - (sum % 11);
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
			for (int i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
			}

			int digit = 11 - (sum % 11);
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

			int sum = 0;
			for (int i = 0; i < 8; i++)
			{
				sum += int.Parse(value[i].ToString()) * (9 - i);
			}

			int digit = 11 - (sum % 11);
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
			string valueAux = value.PadRight(12, '0');
			int sum = 0;
			int weight = 1;
			for (int i = 0; i < 8; i++)
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

			int rest = (sum % 11);
			string strRest = rest.ToString();
			string strDigit1 = strRest[strRest.Length - 1].ToString();

			string valueAux2 = valueAux.Substring(0, 8) + (strDigit1 + valueAux.Substring(9, 3));
			return valueAux2.Equals(value);
		}

		private static bool ValidateSPCommom(string value)
		{
			string valueAux = value.PadRight(12, '0');
			int sum = 0;
			int weight = 1;

			for (int i = 0; i < 8; i++)
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

			int rest = sum % 11;
			string strRest = rest.ToString();
			string strDigit1 = strRest[strRest.Length - 1].ToString();

			string valueAux2 = (valueAux.Substring(0, 8) + (strDigit1 + valueAux.Substring(9, 2)));
			sum = 0;
			weight = 2;
			for (int i = 11; i >= 1; i--)
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
			string strDigit2 = strRest[strRest.Length - 1].ToString();
			valueAux2 += strDigit2;

			return valueAux2.Equals(value);
		}

		private static bool ValidateTO(string value)
		{
			if (!(value.Length == 9 || value.Length == 11))
			{
				return false;
			}

			string valueAux = value;
			if (value.Length == 9)
			{
				valueAux = value.Substring(0, 2) + "02" + value.Substring(1, value.Length);
			}

			int sum = 0;
			int weight = 9;
			for (int i = 0; i < valueAux.Length - 1; i++)
			{
				if (i != 2 && i != 3)
				{
					sum += int.Parse(valueAux[i].ToString()) * weight;
					weight--;
				}
			}

			int digit = 11 - (sum % 11);
			if ((sum % 11) < 2)
			{
				digit = 0;
			}

			return valueAux.EndsWith(digit.ToString());
		}

		#endregion VALIDATIONS
	}
}