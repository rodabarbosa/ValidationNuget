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

        private static readonly Dictionary<State, IInscricaoEstadualValidation> _validation = new Dictionary<State, IInscricaoEstadualValidation>
        {
            { State.AC, new InscricaoEstadualAcreValidation() },
            { State.AL, new InscricaoEstadualAlagoasValidation() },
            { State.AM, new InscricaoEstadualAmazonasValidation() },
            { State.AP, new InscricaoEstadualAmapaValidation() },
            { State.BA, new InscricaoEstadualBahiaValidation() },
            { State.CE, new InscricaoEstadualCearaValidation() },
            { State.DF, new InscricaoEstadualDistritoFederalValidation() },
            { State.ES, new InscricaoEstadualEspiritoSantosValidation() },
            { State.GO, new InscricaoEstadualGoiasValidation() },
            { State.MA, new InscricaoEstadualMaranhaoValidation() },
            { State.MG, new InscricaoEstadualMinasGeraisValidation() },
            { State.MS, new InscricaoEstadualMatoGrossoDoSulValidation() },
            { State.MT, new InscricaoEstadualMatoGrossoValidation() },
            { State.PA, new InscricaoEstadualParaValidation() },
            { State.PB, new InscricaoEstadualParaibaValidation() },
            { State.PE, new InscricaoEstadualPernambucoValidation() },
            { State.PI, new InscricaoEstadualPiauiValidation() },
            { State.PR, new InscricaoEstadualParanaValidation() },
            { State.RJ, new InscricaoEstadualRioDeJaneiroValidation() },
            { State.RN, new InscricaoEstadualRioGrandeDoNorteValidation() },
            { State.RO, new InscricaoEstadualRondoniaValidation() },
            { State.RR, new InscricaoEstadualRoraimaValidation() },
            { State.RS, new InscricaoEstadualRioGrandeDoSulValidation() },
            { State.SC, new InscricaoEstadualSantaCatarinaValidation() },
            { State.SE, new InscricaoEstadualSergipeValidation() },
            { State.SP, new InscricaoEstadualSaoPauloValidation() },
            { State.TO, new InscricaoEstadualTocantinsValidation() }
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

            return _validation[uf].IsValid(value);
        }
    }
}
