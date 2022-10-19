using System.Collections.Generic;
using System.Linq;

namespace Sirb.Validation.Documents.BR.Rules
{
    public static class RenavanRules
    {
        public static int GetSummationValue(string value)
        {
            var values = value.Select(x => int.Parse(x.ToString())).ToList();
            return GetSummationValue(values);
        }

        public static int GetSummationValue(List<int> values)
        {
            var summation = values[8] * 2;
            summation += values[9] * 3;

            for (var i = 0; i < 8; i++)
                summation += values[i] * (i + 2);

            return summation;
        }

        public static int CalculateastDigit(int summationValue)
        {
            var modulusEleven = summationValue % 11;
            var calculatedValue = 11 - modulusEleven;
            return calculatedValue >= 10 ? 0 : calculatedValue;
        }
    }
}
