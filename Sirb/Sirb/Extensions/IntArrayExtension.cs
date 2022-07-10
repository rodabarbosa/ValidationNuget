using System.Text;

namespace Sirb.Extensions
{
    internal static class IntArrayExtension
    {
        public static string ConvertToString(this int[] value)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in value)
                sb.Append(item.ToString());

            return sb.ToString();
        }
    }
}
