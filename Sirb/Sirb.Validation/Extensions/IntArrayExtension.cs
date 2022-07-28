using System.Text;

namespace Sirb.Validation.Extensions
{
    internal static class IntArrayExtension
    {
        public static string ConvertToString(this int[] value)
        {
            var sb = new StringBuilder();
            foreach (var item in value)
            {
                sb.Append(item.ToString());
            }

            return sb.ToString();
        }
    }
}