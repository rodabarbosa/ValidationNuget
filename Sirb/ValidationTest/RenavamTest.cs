using System.Reflection;
using Xunit;

namespace ValidationTest
{
	public class RenavamTest
	{
		[Theory]
		[InlineData("97091043703")]
		[InlineData("197073212")]
		[InlineData("00639884962")]
		public void Validate_Valid(string value) => Assert.True(Sirb.Documents.BR.Validation.Renavam.IsValid(value));

		[Fact]
		public void GenerateAndValidate()
		{
			string value = Sirb.Documents.BR.Mockups.Renavam.Generate();
			bool result = Sirb.Documents.BR.Validation.Renavam.IsValid(value);
			Assert.True(result);
		}
	}
}
