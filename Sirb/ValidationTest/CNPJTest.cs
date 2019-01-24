using Xunit;

namespace ValidationTest
{
	public class CNPJTest
	{
		[Fact]
		public void ValidateValid()
		{
			const string value = "49.616.903/0001-90";// valid
			Assert.True(Sirb.Documents.BR.Validation.CNPJ.IsValid(value));
		}

		[Fact]
		public void ValidateInvalid()
		{
			const string value = "49.616.903/0001-00";// invalid
			Assert.True(!Sirb.Documents.BR.Validation.CNPJ.IsValid(value));
		}

		[Fact]
		public void PlaceMask()
		{
			const string value = "29373908000122";
			var masked = Sirb.Documents.BR.Validation.CNPJ.PlaceMask(value);
			Assert.Matches(@"(\d{2}).(\d{3}).(\d{3})/(\d{4})-(\d{2})", masked);
		}

		[Fact]
		public void GenerateAndValidate()
		{
			var value = Sirb.Documents.BR.Mockups.CNPJ.Generate();
			Assert.True(Sirb.Documents.BR.Validation.CNPJ.IsValid(value));
		}
	}
}