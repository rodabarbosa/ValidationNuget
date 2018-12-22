using Xunit;

namespace ValidationTest
{
	public class UnitTest1
	{
		#region CPF

		[Fact]
		public void ValidateCPFValid()
		{
			var value = "715.470.830-18"; // valid
			Assert.True(Sirb.Documents.BR.Validation.CPF.IsValid(value));
		}

		[Fact]
		public void ValidateCPFInvalid()
		{
			var value = "715.470.830-33"; // invalid
			Assert.True(!Sirb.Documents.BR.Validation.CPF.IsValid(value));
		}

		[Fact]
		public void PlaceMaskCPF()
		{
			var value = "71547083018";
			var masked = Sirb.Documents.BR.Validation.CPF.PlaceMask(value);
			Assert.True(true);
		}

		[Fact]
		public void GenerateAndValidateCPF()
		{
			var value = Sirb.Documents.BR.Mockups.CPF.Generate();
			Assert.True(Sirb.Documents.BR.Validation.CPF.IsValid(value));
		}

		#endregion CPF

		#region CNPJ

		[Fact]
		public void ValidateCNPJValite()
		{
			var value = "49.616.903/0001-90";// valid
			Assert.True(Sirb.Documents.BR.Validation.CNPJ.IsValid(value));
		}

		[Fact]
		public void ValidateCNPJInvalid()
		{
			var value = "49.616.903/0001-00";// invalid
			Assert.True(!Sirb.Documents.BR.Validation.CNPJ.IsValid(value));
		}

		[Fact]
		public void PlaceMaskCNPJ()
		{
			var value = "29373908000122";
			var masked = Sirb.Documents.BR.Validation.CNPJ.PlaceMask(value);
			Assert.True(true);
		}

		[Fact]
		public void GenerateAndValidateCNPJ()
		{
			var value = Sirb.Documents.BR.Mockups.CNPJ.Generate();
			Assert.True(Sirb.Documents.BR.Validation.CNPJ.IsValid(value));
		}

		#endregion CNPJ
	}
}