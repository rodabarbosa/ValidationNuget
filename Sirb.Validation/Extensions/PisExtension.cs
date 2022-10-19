using Sirb.Validation.Documents.BR.Validation;

namespace Sirb.Validation.Extensions
{
    public static class PisExtension
    {
        public static bool IsPisValid(this string value)
        {
            return PisValidation.IsValid(value);
        }

        public static string PlacePisMask(this string value)
        {
            return PisValidation.PlaceMask(value);
        }
    }
}
