using Xunit;

namespace ValidationTest
{
	public class CPFTest
	{
		[Fact]
		public void ValidateValid()
		{
			const string value = "715.470.830-18"; // valid
			Assert.True(Sirb.Documents.BR.Validation.CPF.IsValid(value));
		}

		[Fact]
		public void ValidateInvalid()
		{
			const string value = "715.470.830-33"; // invalid
			Assert.True(!Sirb.Documents.BR.Validation.CPF.IsValid(value));
		}

		[Fact]
		public void PlaceMask()
		{
			const string value = "71547083018";
			var masked = Sirb.Documents.BR.Validation.CPF.PlaceMask(value);
			Assert.Matches(@"(\d{3}).(\d{3}).(\d{3})-(\d{2})", masked);
		}

		[Fact]
		public void GenerateAndValidate()
		{
			var value = Sirb.Documents.BR.Mockups.CPF.Generate();
			var result = Sirb.Documents.BR.Validation.CPF.IsValid(value);
			Assert.True(result);
		}
	}
}