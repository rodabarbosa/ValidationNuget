using System;

namespace Sirb.Benchmark.TestLib
{
	public static class StringTest
	{
		public static string RemoveMaskWithReplace(string cpf)
		{
			if (string.IsNullOrEmpty(cpf))
				return null;

			return cpf.Trim().Replace(".", "").Replace("-", "");
		}

		public static string RemoveMaskWithFor(string cpf)
		{
			if (string.IsNullOrEmpty(cpf))
				return null;

			for (int i = cpf.Length; i > 0; i--)
			{
				if (Char.IsNumber(cpf[i - 1]))
					continue;

				cpf = cpf.Remove(i - 1);
			}

			return cpf;
		}
	}
}
