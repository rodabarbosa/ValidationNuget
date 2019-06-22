using Xunit;

namespace ValidationTest
{
	public class TituloEleitorTest
	{
		[Theory]
		[InlineData("470080440124")] // valid
		[InlineData("4754.5200.0101")] // invalid
		public void ValidateDoc(string value) => Assert.True(Sirb.Documents.BR.Validation.TituloEleitor.IsValid(value));

		[Theory]
		[InlineData("475452000132")]
		public void PlaceMask(string value) => Assert.Matches(@"(\d{4}).(\d{4}).(\d{4})", Sirb.Documents.BR.Validation.TituloEleitor.PlaceMask(value));

		[Fact]
		public void GenerateAndValidate()
		{
			var value = Sirb.Documents.BR.Mockups.TituloEleitor.Generate();
			var result = Sirb.Documents.BR.Validation.TituloEleitor.IsValid(value);
			Assert.True(result);
		}
	}
}