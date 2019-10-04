using Sirb.Documents.BR.Enumeration;
using Sirb.Documents.BR.Interfaces;
using Sirb.Documents.BR.Mockups.IE;
using System;

namespace Sirb.Documents.BR.Mockups
{
	/// <summary>
	/// Gerador de Inscrição Estadual
	/// </summary>
	public static class InscricaoEstadual
	{
		/// <summary>
		/// Gera Número de Inscrição Estadual
		/// </summary>
		/// <param name="state">State</param>
		public static string Generate(State state)
		{
			IInscricaoEstadualInternal inscricaoEstadual;
			switch (state)
			{
				case State.AC:
					inscricaoEstadual = new InscricaoEstadualAC();
					break;

				case State.AL:
					inscricaoEstadual = new InscricaoEstadualAL();
					break;

				case State.AM:
					inscricaoEstadual = new InscricaoEstadualAM();
					break;

				case State.AP:
					inscricaoEstadual = new InscricaoEstadualAP();
					break;

				case State.BA:
					inscricaoEstadual = new InscricaoEstadualBA();
					break;

				case State.CE:
					inscricaoEstadual = new InscricaoEstadualCE();
					break;

				case State.DF:
					inscricaoEstadual = new InscricaoEstadualDF();
					break;

				case State.ES:
					inscricaoEstadual = new InscricaoEstadualES();
					break;

				case State.GO:
					inscricaoEstadual = new InscricaoEstadualGO();
					break;

				case State.MA:
					inscricaoEstadual = new InscricaoEstadualMA();
					break;

				case State.MG:
					inscricaoEstadual = new InscricaoEstadualMG();
					break;

				case State.MS:
					inscricaoEstadual = new InscricaoEstadualMS();
					break;

				case State.MT:
					inscricaoEstadual = new InscricaoEstadualMT();
					break;

				case State.PA:
					inscricaoEstadual = new InscricaoEstadualPA();
					break;

				case State.PB:
					inscricaoEstadual = new InscricaoEstadualPB();
					break;

				case State.PE:
					inscricaoEstadual = new InscricaoEstadualPE();
					break;

				case State.PI:
					inscricaoEstadual = new InscricaoEstadualPI();
					break;

				case State.PR:
					inscricaoEstadual = new InscricaoEstadualPR();
					break;

				case State.RJ:
					inscricaoEstadual = new InscricaoEstadualRJ();
					break;

				case State.RN:
					inscricaoEstadual = new InscricaoEstadualRN();
					break;

				case State.RO:
					inscricaoEstadual = new InscricaoEstadualRO();
					break;

				case State.RR:
					inscricaoEstadual = new InscricaoEstadualRR();
					break;

				case State.RS:
					inscricaoEstadual = new InscricaoEstadualRS();
					break;

				case State.SC:
					inscricaoEstadual = new InscricaoEstadualSC();
					break;

				case State.SE:
					inscricaoEstadual = new InscricaoEstadualSE();
					break;

				case State.SP:
					inscricaoEstadual = new InscricaoEstadualSP();
					break;

				case State.TO:
					inscricaoEstadual = new InscricaoEstadualTO();
					break;

				default:
					throw new ArgumentException("UF desconhecida.");
			}

			return inscricaoEstadual.Generate();
		}
	}
}