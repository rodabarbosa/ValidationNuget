using Xunit;

namespace Sirb.Test
{
	public class TituloEleitorTest
	{
		[Theory]
		[InlineData("470080440124")]
		[InlineData("876807870728")]
		public void Validate_Valid(string value) => Assert.True(Sirb.Documents.BR.Validation.TituloEleitor.IsValid(value));

		[Theory]
		[InlineData("876807870700")]
		[InlineData("316816351122")]
		public void Validate_Invalid(string value) => Assert.False(Sirb.Documents.BR.Validation.TituloEleitor.IsValid(value));

		[Theory]
		[InlineData("475452000132")]
		public void PlaceMask(string value) => Assert.Matches(@"(\d{4}).(\d{4}).(\d{4})", Sirb.Documents.BR.Validation.TituloEleitor.PlaceMask(value));

		[Fact]
		public void GenerateAndValidate()
		{
			string value = Sirb.Documents.BR.Mockups.TituloEleitor.Generate();
			bool result = Sirb.Documents.BR.Validation.TituloEleitor.IsValid(value);
			Assert.True(result);
		}
	}
}
