using Sirb.Validation.Documents.BR.Enumeration;
using System;

namespace Sirb.Validation.Documents.BR.Validation
{
    [Obsolete("Use InscricaoEstadualValidation class instead.")]
    public static class InscricaoEstadual
    {
        public static string RemoveMask(string value)
        {
            return InscricaoEstadualValidation.RemoveMask(value);
        }

        public static string PlaceMask(State uf, string value)
        {
            return InscricaoEstadualValidation.PlaceMask(uf, value);
        }

        public static bool IsValid(State uf, string value)
        {
            return InscricaoEstadualValidation.IsValid(uf, value);
        }
    }
}
