using Sirb.Documents.BR.Enumeration;

namespace Sirb.Extensions
{
	internal static class StateExtension
	{
		public static int GetValue(this State value)
		{
			switch (value)
			{
				case State.CE:
				case State.MA:
				case State.PI: return 3;

				case State.MG: return 6;

				case State.ES:
				case State.RJ: return 7;

				case State.AL:
				case State.PB:
				case State.PE:
				case State.RN: return 4;

				case State.AC:
				case State.AP:
				case State.AM:
				case State.PA:
				case State.RO:
				case State.RR: return 2;

				case State.RS: return 0;

				case State.BA:
				case State.SE: return 5;

				case State.PR:
				case State.SC: return 9;

				case State.SP: return 8;

				case State.DF:
				case State.GO:
				case State.MS:
				case State.TO:
				default: return 1;
			}
		}
	}
}