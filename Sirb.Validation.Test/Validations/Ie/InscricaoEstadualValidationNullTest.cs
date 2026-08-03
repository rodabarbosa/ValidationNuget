using Sirb.Validation.Documents.BR.Interfaces;
using Sirb.Validation.Documents.BR.Validation.Ie;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sirb.Validation.Test.Validations.Ie;

public class InscricaoEstadualValidationNullTest
{
    // 24 classes with null/empty guard (?. OnlyNumbers + string.IsNullOrEmpty check)
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
        typeof(InscricaoEstadualRioDeJaneiroValidation),
        typeof(InscricaoEstadualRioGrandeDoNorteValidation),
        typeof(InscricaoEstadualRioGrandeDoSulValidation),
        typeof(InscricaoEstadualRondoniaValidation),
        typeof(InscricaoEstadualRoraimaValidation),
        typeof(InscricaoEstadualSantaCatarinaValidation),
        typeof(InscricaoEstadualSergipeValidation),
        typeof(InscricaoEstadualTocantinsValidation),
    };

    // 3 classes WITHOUT null guard — NRE on null input
    private static readonly Type[] ClassesWithoutNullCheck =
    {
        typeof(InscricaoEstadualPernambucoValidation),
        typeof(InscricaoEstadualPiauiValidation),
        typeof(InscricaoEstadualSaoPauloValidation),
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

    [Theory(DisplayName = "IE validations without null guard should throw NullReferenceException for null input")]
    [MemberData(nameof(GetClassesWithoutNullCheck))]
    public void IsValid_NullInput_ThrowsNullReferenceException(Type type)
    {
        var instance = (IInscricaoEstadualValidation)Activator.CreateInstance(type)!;
        Assert.Throws<NullReferenceException>(() => instance.IsValid(null));
    }

    public static IEnumerable<object[]> GetClassesWithNullCheck()
    {
        return new List<object[]>(ClassesWithNullCheck.Select(t => new object[] { t }));
    }

    public static IEnumerable<object[]> GetClassesWithoutNullCheck()
    {
        return new List<object[]>(ClassesWithoutNullCheck.Select(t => new object[] { t }));
    }
}
