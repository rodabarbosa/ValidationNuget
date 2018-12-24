using Xunit;

namespace ValidationTest
{
	public class PISTest
	{
		[Fact]
		public void ValidateValid()
		{
			var value = "537.68723.13/3"; // valid
			Assert.True(Sirb.Documents.BR.Validation.PIS.IsValid(value));
		}

		[Fact]
		public void ValidateInvalid()
		{
			var value = "53768723175"; // invalid
			Assert.True(!Sirb.Documents.BR.Validation.PIS.IsValid(value));
		}

		[Fact]
		public void PlaceMask()
		{
			var value = "53768723133";
			var masked = Sirb.Documents.BR.Validation.PIS.PlaceMask(value);
			Assert.Matches(@"(\d{3}).(\d{5}).(\d{2})/(\d{1})", masked);
		}

		[Fact]
		public void GenerateAndValidate()
		{
			var value = Sirb.Documents.BR.Mockups.PIS.Generate();
			var result = Sirb.Documents.BR.Validation.PIS.IsValid(value);
			Assert.True(result);
		}
	}
}