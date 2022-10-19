using Sirb.Validation.Documents.BR.Validation;

namespace Sirb.Validation.Exceptions
{
    public static class CnpjExtension
    {
        public static string PlaceCnpjMask(this string value)
        {
            return CnpjValidation.PlaceMask(value);
        }

        public static bool IsCnpjValid(this string value)
        {
            return CnpjValidation.IsValid(value);
        }
    }
}
