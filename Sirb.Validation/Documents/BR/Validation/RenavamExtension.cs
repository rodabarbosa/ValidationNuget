namespace Sirb.Validation.Documents.BR.Validation
{
    public static class RenavamExtension
    {
        public static bool IsRenavamValid(this string value)
        {
            return RenavamValidation.IsValid(value);
        }
    }
}
