using Xunit;

namespace ValidationTest
{
	public class CPFTest
	{
		[Theory]
		[InlineData("715.470.830-18")]
		[InlineData("115.327.120-65")]
		public void Validate_Valid(string value) => Assert.True(Sirb.Documents.BR.Validation.CPF.IsValid(value));

		[Theory]
		[InlineData("115.327.120-60")]
		[InlineData("715.470.830-33")]
		public void Validate_Invalid(string value) => Assert.False(Sirb.Documents.BR.Validation.CPF.IsValid(value));

		[Theory]
		[InlineData("71547083018")]
		public void PlaceMask(string value) => Assert.Matches(@"(\d{3}).(\d{3}).(\d{3})-(\d{2})", Sirb.Documents.BR.Validation.CPF.PlaceMask(value));

		[Fact]
		public void GenerateAndValidate()
		{
			string value = Sirb.Documents.BR.Mockups.CPF.Generate();
			bool result = Sirb.Documents.BR.Validation.CPF.IsValid(value);
			Assert.True(result);
		}
	}
}