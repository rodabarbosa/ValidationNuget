using Sirb.Validation.Documents.BR.Validation;

namespace Sirb.Validation.Extensions;

public static class RenavamExtension
{
    public static bool IsRenavamValid(this string value)
    {
        return RenavamValidation.IsValid(value);
    }
}
