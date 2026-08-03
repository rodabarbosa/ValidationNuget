using Sirb.Validation.Documents.BR.Interfaces;
using Sirb.Validation.Documents.BR.Validation.Ie;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationNullTest
{
    // 27 classes with null/empty guard (?. OnlyNumbers + string.IsNullOrEmpty check)
    // PE, PI, and SP previously lacked a null guard; null/empty checks were added (ADR-006).
    private static readonly Type[] ClassesWithNullCheck =
    {
        typeof(InscricaoEstadualAcreValidation),
        typeof(InscricaoEstadualAlagoasValidation),
        typeof(InscricaoEstadualAmazonasValidation),
        typeof(InscricaoEstadualAmapaValidation),
        typeof(InscricaoEstadualBahiaValidation),
        typeof(InscricaoEstadualCearaValidation),
        typeof(InscricaoEstadualDistritoFederalValidation),
        typeof(InscricaoEstadualEspiritoSantosValidation),
        typeof(InscricaoEstadualGoiasValidation),
        typeof(InscricaoEstadualMaranhaoValidation),
        typeof(InscricaoEstadualMatoGrossoValidation),
        typeof(InscricaoEstadualMatoGrossoDoSulValidation),
        typeof(InscricaoEstadualMinasGeraisValidation),
        typeof(InscricaoEstadualParaValidation),
        typeof(InscricaoEstadualParaibaValidation),
        typeof(InscricaoEstadualParanaValidation),
        typeof(InscricaoEstadualPernambucoValidation),
        typeof(InscricaoEstadualPiauiValidation),
        typeof(InscricaoEstadualRioDeJaneiroValidation),
        typeof(InscricaoEstadualRioGrandeDoNorteValidation),
        typeof(InscricaoEstadualRioGrandeDoSulValidation),
        typeof(InscricaoEstadualRondoniaValidation),
        typeof(InscricaoEstadualRoraimaValidation),
        typeof(InscricaoEstadualSantaCatarinaValidation),
        typeof(InscricaoEstadualSergipeValidation),
        typeof(InscricaoEstadualSaoPauloValidation),
        typeof(InscricaoEstadualTocantinsValidation),
    };

    [Theory(DisplayName = "IE validations with null guard should return false for null input")]
    [MemberData(nameof(GetClassesWithNullCheck))]
    public void IsValid_NullInput_ReturnsFalse(Type type)
    {
        var instance = (IInscricaoEstadualValidation)Activator.CreateInstance(type)!;
        var result = instance.IsValid(null);
        Assert.False(result);
    }

    [Theory(DisplayName = "IE validations with null guard should return false for empty input")]
    [MemberData(nameof(GetClassesWithNullCheck))]
    public void IsValid_EmptyInput_ReturnsFalse(Type type)
    {
        var instance = (IInscricaoEstadualValidation)Activator.CreateInstance(type)!;
        var result = instance.IsValid("");
        Assert.False(result);
    }

    public static IEnumerable<object[]> GetClassesWithNullCheck()
    {
        return new List<object[]>(ClassesWithNullCheck.Select(t => new object[] { t }));
    }
}
