using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups.Ie
{
    internal class InscricaoEstadualMG : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            var generatedNumbers = new List<int>();
            var auxNumber = new List<int>();

            for (var i = 0; i < 11; i++)
            {
                generatedNumbers.Add(Random.Next(10));

                if (i == 3)
                    auxNumber.Add(0);

                auxNumber.Add(generatedNumbers[generatedNumbers.Count - 1]);
            }

            generatedNumbers.Add(CalculateBeforeLastDigit(auxNumber.ToArray()));
            generatedNumbers.Add(CalcultaLastDigit(generatedNumbers.ToArray()));

            return generatedNumbers.ToArray();
        }

        #region Before Last Digit

        private static int CalculateBeforeLastDigit(int[] value)
        {
            var total = 0;
            for (var i = 0; i < value.Length; i++)
                total += CalculateSummationValue(value[i], CalcultateBeforeLastWeight(i));

            return ValidateSummationValue(total);
        }

        private static int CalcultateBeforeLastWeight(int index)
        {
            return index % 2 == 0 ? 1 : 2;
        }

        private static int CalculateSummationValue(int value, int weight)
        {
            var multipliedValue = (value * weight).ToString();
            var total = 0;
            for (var i = 0; i < multipliedValue.Length; i++)
                total += int.Parse(multipliedValue[i].ToString());

            return total;
        }

        private static int ValidateSummationValue(int summationValue)
        {
            var value = summationValue;
            while (value % 10 != 0)
                value++;

            return value - summationValue;
        }

        #endregion Before Last Digit

        #region Last Digit

        private static int CalcultaLastDigit(int[] value)
        {
            var total = 0;
            for (var i = 0; i < value.Length; i++)
                total += value[i] * CalculateLastWeight(i);

            return ValidateLastDigit(total);
        }

        private static int CalculateLastWeight(int index)
        {
            return (index < 2 ? 3 : 13) - index;
        }

        private static int ValidateLastDigit(int summationValue)
        {
            var digit = 11 - summationValue % 11;
            return summationValue % 11 == 0 || summationValue % 11 == 1 ? 0 : digit;
        }

        #endregion Last Digit
    }
}
