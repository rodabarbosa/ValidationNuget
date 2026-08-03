using Sirb.Validation.Documents.BR.Rules;
using Sirb.Validation.Extensions;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups;

/// <summary>
/// Gerador de número PIS
/// </summary>
public static class Pis
{

    /// <summary>
    /// Gera número PIS
    /// </summary>
    /// <returns></returns>
    public static string Generate()
    {
        var generatedNumbers = GenerateNumbers();
        return generatedNumbers.ConvertToString();
    }

    private static int[] GenerateNumbers()
    {
        var generatedNumbers = new List<int>();

        var total = 0;
        for (var i = 0; i < 10; i++)
        {
            generatedNumbers.Add(RandomNumberGenerator.GetInt32(0, 10));
            var index = generatedNumbers.Count - 1;

            total += generatedNumbers[index] * PisRule.CalculateWeight(i);
        }

        generatedNumbers.Add(PisRule.CalculateLastDigit(total));

        return generatedNumbers.ToArray();
    }
}
