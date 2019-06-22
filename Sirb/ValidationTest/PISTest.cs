using Xunit;

namespace ValidationTest
{
	public class PISTest
	{
		[Theory]
		[InlineData("537.68723.13/3")] // valid
		[InlineData("53768723175")] // invalid
		public void ValidateDoc(string value) => Assert.True(Sirb.Documents.BR.Validation.PIS.IsValid(value));

		[Theory]
		[InlineData("53768723133")]
		public void PlaceMask(string value) => Assert.Matches(@"(\d{3}).(\d{5}).(\d{2})/(\d{1})", Sirb.Documents.BR.Validation.PIS.PlaceMask(value));

		[Fact]
		public void GenerateAndValidate()
		{
			var value = Sirb.Documents.BR.Mockups.PIS.Generate();
			var result = Sirb.Documents.BR.Validation.PIS.IsValid(value);
			Assert.True(result);
		}
	}
}