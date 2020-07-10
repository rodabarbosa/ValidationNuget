using Xunit;

namespace Sirb.Test
{
	public class PisTest
	{
		[Theory]
		[InlineData("56303289843")]
		[InlineData("80589607730")]
		public void Validate_Valid(string value) => Assert.True(Sirb.Documents.BR.Validation.Pis.IsValid(value));

		[Theory]
		[InlineData("80589607700")]
		[InlineData("27593988377")]
		public void Validate_Invalid(string value) => Assert.False(Sirb.Documents.BR.Validation.Pis.IsValid(value));

		[Theory]
		[InlineData("53768723133")]
		public void PlaceMask(string value) => Assert.Matches(@"(\d{3}).(\d{5}).(\d{2})/(\d{1})", Sirb.Documents.BR.Validation.Pis.PlaceMask(value));

		[Fact]
		public void GenerateAndValidate()
		{
			string value = Sirb.Documents.BR.Mockups.Pis.Generate();
			bool result = Sirb.Documents.BR.Validation.Pis.IsValid(value);
			Assert.True(result);
		}
	}
}
