using Sirb.Validation.Documents.BR.Validation;

namespace Sirb.Validation.Extensions
{
    public static class TituloEleitorExtension
    {
        public static bool IsTituloEleitorValid(this string value)
        {
            return TituloEleitorValidation.IsValid(value);
        }

        public static string PlaceTituloEleitorMask(this string value)
        {
            return TituloEleitorValidation.PlaceMask(value);
        }
    }
}
