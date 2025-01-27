namespace Sirb.Validation.Benchmark.TestLib;

static public class StringTest
{
    static public string RemoveMaskWithReplace(string cpf)
    {
        if (string.IsNullOrEmpty(cpf?.Trim()))
            return null;

        return cpf.Trim()
            .Replace(".", string.Empty)
            .Replace("-", string.Empty);
    }

    static public string RemoveMaskWithFor(string cpf)
    {
        if (string.IsNullOrEmpty(cpf?.Trim()))
            return default;

        for (var i = cpf.Length; i > 0; i--)
        {
            if (char.IsNumber(cpf[i - 1]))
                continue;

            cpf = cpf.Remove(i - 1);
        }

        return cpf;
    }

    static public string RemoveMaskWithRegex(string cpf)
    {
        if (string.IsNullOrEmpty(cpf?.Trim()))
            return default;

        return Regex.Replace(cpf, @"[^\d]", string.Empty);
    }

    static public string Reverse1(string value)
    {
        var charArray = value.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    static public string Reverse2(string value)
    {
        if (string.IsNullOrEmpty(value)) return value;

        var sb = new StringBuilder();
        for (var i = value.Length; i > 0; i--)
            _ = sb.Append(value[i - 1]);

        return sb.ToString();
    }
}
