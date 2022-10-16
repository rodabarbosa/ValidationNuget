using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Interfaces;
using Sirb.Validation.Documents.BR.Mockups.Ie;
using System.Collections.Generic;

namespace Sirb.Validation.Documents.BR.Mockups
{
    /// <summary>
    /// Gerador de Inscrição Estadual
    /// </summary>
    public static class InscricaoEstadual
    {
        private static readonly Dictionary<State, IInscricaoEstadualInternal> _generator = new Dictionary<State, IInscricaoEstadualInternal>
        {
            { State.AC, new InscricaoEstadualAc() },
            { State.AL, new InscricaoEstadualAl() },
            { State.AM, new InscricaoEstadualAm() },
            { State.AP, new InscricaoEstadualAp() },
            { State.BA, new InscricaoEstadualBa() },
            { State.CE, new InscricaoEstadualCe() },
            { State.DF, new InscricaoEstadualDf() },
            { State.ES, new InscricaoEstadualEs() },
            { State.GO, new InscricaoEstadualGO() },
            { State.MA, new InscricaoEstadualMA() },
            { State.MG, new InscricaoEstadualMG() },
            { State.MS, new InscricaoEstadualMS() },
            { State.MT, new InscricaoEstadualMT() },
            { State.PA, new InscricaoEstadualPA() },
            { State.PB, new InscricaoEstadualPB() },
            { State.PE, new InscricaoEstadualPE() },
            { State.PI, new InscricaoEstadualPI() },
            { State.PR, new InscricaoEstadualPR() },
            { State.RJ, new InscricaoEstadualRJ() },
            { State.RN, new InscricaoEstadualRn() },
            { State.RO, new InscricaoEstadualRO() },
            { State.RR, new InscricaoEstadualRR() },
            { State.RS, new InscricaoEstadualRS() },
            { State.SC, new InscricaoEstadualSC() },
            { State.SE, new InscricaoEstadualSE() },
            { State.SP, new InscricaoEstadualSP() },
            { State.TO, new InscricaoEstadualTO() }
        };

        /// <summary>
        /// Gera Número de Inscrição Estadual
        /// </summary>
        /// <param name="state">State</param>
        public static string Generate(State state)
        {
            return _generator[state].Generate();
        }
    }
}
