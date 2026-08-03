using Sirb.Validation.Documents.BR.Interfaces;
using Sirb.Validation.Extensions;
using System.Security.Cryptography;

namespace Sirb.Validation.Documents.BR.Mockups.Ie;

internal abstract class InscricaoEstadualBase : IInscricaoEstadualInternal
{
    public string Generate()
    {
        var generatedNumbers = GenerateNumbers();
        return generatedNumbers.ConvertToString();
    }

    protected abstract int[] GenerateNumbers();

    protected static int GetRandomInt(int max) => RandomNumberGenerator.GetInt32(0, max);

    protected virtual int CalculateLastDigit(int summationValue)
    {
        var remainder = summationValue % 11;
        var value = 11 - remainder;
        return value == 10 || value == 11 ? 0 : value;
    }

    protected static int CalculateWeight(int value, int index)
    {
        return value - index;
    }
}
