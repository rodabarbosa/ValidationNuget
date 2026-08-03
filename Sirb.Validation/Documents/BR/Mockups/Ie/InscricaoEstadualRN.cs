using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups.Ie;

internal sealed class InscricaoEstadualRn : InscricaoEstadualBase
{
    protected override int[] GenerateNumbers()
    {
        var generatedNumbers = new List<int> { 2, 0 };

        var length = GetRandomLength();
        var value = length + 1;
        var total = TotalBase(length);
        for (var i = 0; i < length; i++)
        {
            generatedNumbers.Add(GetRandomInt(10));

            total += generatedNumbers[generatedNumbers.Count - 1] * CalculateWeight(value, i);
        }

        generatedNumbers.Add(CalculateLastDigit(total));

        return generatedNumbers.ToArray();
    }

    private static int GetRandomLength()
    {
        return GetRandomInt(2) == 0 ? 6 : 7;
    }

    private static int TotalBase(int length)
    {
        return length == 6 ? 18 : 20;
    }

    protected override int CalculateLastDigit(int summationValue)
    {
        var value = summationValue * 10;
        var remainder = value % 11;
        return remainder == 10 ? 0 : remainder;
    }
}
