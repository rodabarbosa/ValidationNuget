#region

using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Interfaces;
using Sirb.Validation.Documents.BR.Validation.Ie;
using Sirb.Validation.Extensions;
using System;
using System.Collections.Generic;

#endregion

namespace Sirb.Validation.Documents.BR.Validation
{
    /// <summary>
    /// Inscrição Estadual
    /// </summary>
    public static class InscricaoEstadualValidation
    {
        private static readonly Dictionary<State, Func<string, string>> _mask = new Dictionary<State, Func<string, string>>
        {
            { State.AC, AcreExtension.InscricaoEstadualMaskAc },
            { State.AL, AlagoasExtension.InscricaoEstadualMaskAl },
            { State.AM, AmazonasExtension.InscricaoEstadualMaskAm },
            { State.AP, AmazonasExtension.InscricaoEstadualMaskAm },
            { State.BA, BahiaExtension.InscricaoEstadualMaskBa },
            { State.CE, CearaExtension.InscricaoEstadualMaskCe },
            { State.DF, DistritoFederalExtension.InscricaoEstadualMaskDf },
            { State.ES, EspiritoSantoExtension.InscricaoEstadualMaskEs },
            { State.GO, GoiasExtension.InscricaoEstadualMaskGo },
            { State.MA, MaranhaoExtension.InscricaoEstadualMaskMa },
            { State.MG, MinasGeraisExtension.InscricaoEstadualMaskMg },
            { State.MS, MatoGrossoDoSulExtension.InscricaoEstadualMaskMs },
            { State.MT, MatoGrossoExtension.InscricaoEstadualMaskMt },
            { State.PA, ParaExtension.InscricaoEstadualMaskPa },
            { State.PB, ParaibaExtension.InscricaoEstadualMaskPb },
            { State.PE, PernambucoExtension.InscricaoEstadualMaskPe },
            { State.PI, PiuaiExtension.InscricaoEstadualMaskPi },
            { State.PR, ParanaExtension.InscricaoEstadualMaskPr },
            { State.RJ, RioDeJaneiroExtension.InscricaoEstadualMaskRj },
            { State.RN, RioGrandeDoNorteExtension.InscricaoEstadualMaskRn },
            { State.RO, RondoniaExtension.InscricaoEstadualMaskRo },
            { State.RR, RoraimaExtension.InscricaoEstadualMaskRr },
            { State.RS, RioGrandeDoSulExtension.InscricaoEstadualMaskRs },
            { State.SC, SantaCatarinaExtension.InscricaoEstadualMaskSc },
            { State.SE, SergipeExtension.InscricaoEstadualMaskSe },
            { State.SP, SaoPauloExtension.InscricaoEstadualMaskSp },
            { State.TO, TocantinsExtension.InscricaoEstadualMaskTo }
        };

        private static readonly Dictionary<State, IInscricaoEstatualValidation> _validation = new Dictionary<State, IInscricaoEstatualValidation>
        {
            { State.AC, new InscricaoEstatualAcreValidation() },
            { State.AL, new InscricaoEstatualAlagoasValidation() },
            { State.AM, new InscricaoEstatualAmazonasValidation() },
            { State.AP, new InscricaoEstatualAmapaValidation() },
            { State.BA, new InscricaoEstatualBahiaValidation() },
            { State.CE, new InscricaoEstatualCearaValidation() },
            { State.DF, new InscricaoEstatualDistritoFederalValidation() },
            { State.ES, new InscricaoEstatualEspiritoSantosValidation() },
            { State.GO, new InscricaoEstatualGoiasValidation() },
            { State.MA, new InscricaoEstatualMaranhaoValidation() },
            { State.MG, new InscricaoEstatualMinasGeraisValidation() },
            { State.MS, new InscricaoEstatualMatoGrossoDoSulValidation() },
            { State.MT, new InscricaoEstatualMatoGrossoValidation() },
            { State.PA, new InscricaoEstatualParaValidation() },
            { State.PB, new InscricaoEstatualPernambucoValidation() },
            { State.PE, new InscricaoEstatualPernambucoValidation() },
            { State.PI, new InscricaoEstatualPiauiValidation() },
            { State.PR, new InscricaoEstatualParanaValidation() },
            { State.RJ, new InscricaoEstatualRioDeJaneiroValidation() },
            { State.RN, new InscricaoEstatualRioGRandeDoNorteValidation() },
            { State.RO, new InscricaoEstatualRondoniaValidation() },
            { State.RR, new InscricaoEstatualRoraimaValidation() },
            { State.RS, new InscricaoEstatualRioGrandeDoSulValidation() },
            { State.SC, new InscricaoEstatualSantaCatarinaValidation() },
            { State.SE, new InscricaoEstatualSergipeValidation() },
            { State.SP, new InscricaoEstatualSaoPauloValidation() },
            { State.TO, new InscricaoEstatualTocantinsValidation() }
        };

        /// <summary>
        /// Remove mascara da Inscrição Estadual
        /// </summary>
        /// <param name="value">Inscrição Estadual</param>
        public static string RemoveMask(string value)
        {
            return value?.OnlyNumbers();
        }

        /// <summary>
        /// Adiciona mascara a inscrição estadual
        /// </summary>
        /// <param name="uf">Uf da Inscrição</param>
        /// <param name="value">Inscrição Estadual</param>
        public static string PlaceMask(State uf, string value)
        {
            if (string.IsNullOrEmpty(value?.Trim()))
                return default;

            return _mask[uf].Invoke(value);
        }

        /// <summary>
        /// Validador de inscrição estadual
        /// </summary>
        /// <param name="uf">UF</param>
        /// <param name="value">Inscricao Estadual</param>
        public static bool IsValid(State uf, string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            var onlyNumberValue = RemoveMask(value);

            return _validation[uf].IsValid(onlyNumberValue);
        }
    }
}
