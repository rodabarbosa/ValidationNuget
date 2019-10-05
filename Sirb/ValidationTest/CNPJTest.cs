using Xunit;

namespace ValidationTest
{
	public class CNPJTest
	{
		[Theory]
		[InlineData("49.616.903/0001-90")]
		[InlineData("72.923.755/0001-79")]
		public void Validate_Valid(string value) => Assert.True(Sirb.Documents.BR.Validation.Cnpj.IsValid(value));

		[Theory]
		[InlineData("49.616.903/0001-00")]
		[InlineData("72.923.755/0001-70")]
		public void Validate_Invalid(string value) => Assert.False(Sirb.Documents.BR.Validation.Cnpj.IsValid(value));

		[Theory]
		[InlineData("29373908000122")]
		public void PlaceMask(string value) => Assert.Matches(@"(\d{2}).(\d{3}).(\d{3})/(\d{4})-(\d{2})", Sirb.Documents.BR.Validation.Cnpj.PlaceMask(value));

		[Fact]
		public void GenerateAndValidate()
		{
			string value = Sirb.Documents.BR.Mockups.Cnpj.Generate();
			Assert.True(Sirb.Documents.BR.Validation.Cnpj.IsValid(value));
		}
	}
}