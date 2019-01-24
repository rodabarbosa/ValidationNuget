using Xunit;

namespace ValidationTest
{
	public class TituloEleitorTest
	{
		[Fact]
		public void ValidateValid()
		{
			const string value = "470080440124"; // valid
			Assert.True(Sirb.Documents.BR.Validation.TituloEleitor.IsValid(value));
		}

		[Fact]
		public void ValidateInvalid()
		{
			const string value = "4754.5200.0101"; // invalid
			Assert.True(!Sirb.Documents.BR.Validation.TituloEleitor.IsValid(value));
		}

		[Fact]
		public void PlaceMask()
		{
			const string value = "475452000132";
			var masked = Sirb.Documents.BR.Validation.TituloEleitor.PlaceMask(value);
			Assert.Matches(@"(\d{4}).(\d{4}).(\d{4})", masked);
		}

		[Fact]
		public void GenerateAndValidate()
		{
			var value = Sirb.Documents.BR.Mockups.TituloEleitor.Generate();
			var result = Sirb.Documents.BR.Validation.TituloEleitor.IsValid(value);
			Assert.True(result);
		}
	}
}