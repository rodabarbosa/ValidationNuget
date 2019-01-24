using Sirb.Documents.BR.Enumeration;
using Sirb.Documents.BR.Validation;
using Xunit;

namespace ValidationTest
{
	public class InscricaoEstadualTest
	{
		[Fact]
		public void ValidateAC()
		{
			const string value = "0147835924265"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.AC, value));
		}

		[Fact]
		public void ValidateAL()
		{
			const string value = "248813420"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.AL, value));
		}

		[Fact]
		public void ValidateAM()
		{
			const string value = "585040818"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.AM, value));
		}

		[Fact]
		public void ValidateAP()
		{
			const string value = "034078983"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.AP, value));
		}

		[Fact]
		public void ValidateBA()
		{
			const string value = "75658100"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.BA, value));
		}

		[Fact]
		public void ValidateCE()
		{
			const string value = "697620638"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.CE, value));
		}

		[Fact]
		public void ValidateDF()
		{
			const string value = "0706664500149"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.DF, value));
		}

		[Fact]
		public void ValidateES()
		{
			const string value = "163051950"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.ES, value));
		}

		[Fact]
		public void ValidateGO()
		{
			const string value = "110075919"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.GO, value));
		}

		[Fact]
		public void ValidateMA()
		{
			const string value = "121360814"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.MA, value));
		}

		[Fact]
		public void ValidateMG()
		{
			const string value = "5672215254268"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.MG, value));
		}

		[Fact]
		public void ValidateMS()
		{
			const string value = "289190908"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.MS, value));
		}

		[Fact]
		public void ValidateMT()
		{
			const string value = "09636557239"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.MT, value));
		}

		[Fact]
		public void ValidatePA()
		{
			const string value = "150988621"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.PA, value));
		}

		[Fact]
		public void ValidatePB()
		{
			const string value = "465160735"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.PB, value));
		}

		[Fact]
		public void ValidatePE()
		{
			const string value = "383333253"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.PE, value));
		}

		[Fact]
		public void ValidatePI()
		{
			const string value = "681338903"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.PI, value));
		}

		[Fact]
		public void ValidatePR()
		{
			const string value = "1212323086"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.PR, value));
		}

		[Fact]
		public void ValidateRJ()
		{
			const string value = "91534932"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.RJ, value));
		}

		[Fact]
		public void ValidateRN()
		{
			const string value = "208436812"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.RN, value));
		}

		[Fact]
		public void ValidateRO()
		{
			const string value = "91334325351252"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.RO, value));
		}

		[Fact]
		public void ValidateRR()
		{
			const string value = "245194766"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.RR, value));
		}

		[Fact]
		public void ValidateRS()
		{
			const string value = "6065456989"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.RS, value));
		}

		[Fact]
		public void ValidateSC()
		{
			const string value = "744159148"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.SC, value));
		}

		[Fact]
		public void ValidateSE()
		{
			const string value = "256358630"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.SE, value));
		}

		[Fact]
		public void ValidateSP()
		{
			const string value = "685625637442"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.SP, value));
		}

		[Fact]
		public void ValidateSPWithP()
		{
			const string value = "P-01100424.3/002"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.SP, value));
		}

		[Fact]
		public void ValidateTO()
		{
			const string value = "18034891949"; // valid
			Assert.True(InscricaoEstadual.IsValid(State.TO, value));
		}
	}
}