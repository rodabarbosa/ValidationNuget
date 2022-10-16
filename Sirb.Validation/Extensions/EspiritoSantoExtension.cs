namespace Sirb.Validation.Extensions
{
    public static class EspiritoSantoExtension
    {
        public static string InscricaoEstadualMaskEs(this string value)
        {
            var cleanValue = value?.OnlyNumbers();
            return string.IsNullOrEmpty(cleanValue) ? default : cleanValue;
        }
    }
}
