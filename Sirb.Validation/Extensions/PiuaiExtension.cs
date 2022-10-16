namespace Sirb.Validation.Extensions
{
    public static class PiuaiExtension
    {
        public static string InscricaoEstadualMaskPi(this string value)
        {
            var cleanValue = value?.OnlyNumbers();
            return string.IsNullOrEmpty(cleanValue) ? default : cleanValue;
        }
    }
}
