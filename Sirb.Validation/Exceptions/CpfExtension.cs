using Sirb.Validation.Documents.BR.Validation;

namespace Sirb.Validation.Exceptions
{
    public static class CpfExtension
    {
        public static string PlaceCpfMask(this string value)
        {
            return CpfValidation.PlaceMask(value);
        }

        public static bool IsCpfValid(this string value)
        {
            return CpfValidation.IsValid(value);
        }
    }
}
