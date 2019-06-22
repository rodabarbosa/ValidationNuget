using Xunit;

namespace ValidationTest
{
	public class CPFTest
	{
		[Theory]
		[InlineData("715.470.830-18")] // valid
		[InlineData("715.470.830-33")] // invalid
		public void ValidateDoc(string value) => Assert.True(Sirb.Documents.BR.Validation.CPF.IsValid(value));

		[Theory]
		[InlineData("71547083018")]
		public void PlaceMask(string value) => Assert.Matches(@"(\d{3}).(\d{3}).(\d{3})-(\d{2})", Sirb.Documents.BR.Validation.CPF.PlaceMask(value));


		[Fact]
		public void GenerateAndValidate()
		{
			var value = Sirb.Documents.BR.Mockups.CPF.Generate();
			var result = Sirb.Documents.BR.Validation.CPF.IsValid(value);
			Assert.True(result);
		}
	}
}