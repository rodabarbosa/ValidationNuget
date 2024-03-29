﻿using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups.Ie
{
    internal class InscricaoEstadualPE : InscricaoEstadualBase
    {
        protected override int[] GenerateNumbers()
        {
            var generatedNumbers = new List<int>();

            var totalBeforeLastDigit = 0;
            var totalLastDigit = 0;
            for (var i = 0; i < 7; i++)
            {
                generatedNumbers.Add(Random.Next(10));
                totalBeforeLastDigit += generatedNumbers[generatedNumbers.Count - 1] * CalculateBeforeLastWeight(i);
                totalLastDigit += generatedNumbers[generatedNumbers.Count - 1] * CalculateLastWeight(i);
            }

            generatedNumbers.Add(CalculateLastDigit(totalBeforeLastDigit));
            totalLastDigit += generatedNumbers[generatedNumbers.Count - 1] * 2;

            generatedNumbers.Add(CalculateLastDigit(totalLastDigit));

            return generatedNumbers.ToArray();
        }

        private int CalculateBeforeLastWeight(int index)
        {
            return 8 - index;
        }

        private int CalculateLastWeight(int index)
        {
            return 9 - index;
        }

        protected override int CalculateLastDigit(int summationValue)
        {
            var remainder = summationValue % 11;
            return remainder < 2 ? 0 : 11 - remainder;
        }
    }
}
