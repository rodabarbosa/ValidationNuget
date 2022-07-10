using System.Text.RegularExpressions;

namespace Sirb.Benchmark.TestLib;

public static class StringTest
{
    public static string RemoveMaskWithReplace(string cpf)
    {
        if (string.IsNullOrEmpty(cpf?.Trim()))
            return default;

        return cpf.Trim().Replace(".", "").Replace("-", "");
    }

    public static string RemoveMaskWithFor(string cpf)
    {
        if (string.IsNullOrEmpty(cpf?.Trim()))
            return default;

        for (int i = cpf.Length; i > 0; i--)
        {
            if (char.IsNumber(cpf[i - 1]))
                continue;

            cpf = cpf.Remove(i - 1);
        }

        return cpf;
    }

    public static string RemoveMaskWithRegex(string cpf)
    {
        if (string.IsNullOrEmpty(cpf?.Trim()))
            return default;

        return Regex.Replace(cpf, @"[^\d]", string.Empty);
    }
}
