using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups
{
    public class InscricaoEstadualAmapaMockupTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void Validate(int index)
        {
            System.Diagnostics.Debug.WriteLine($"Debug Validation {index}");
            string value = InscricaoEstadual.Generate(State.AP);
            bool isValid = InscricaoEstadualValidation.IsValid(State.AP, value);
            Assert.True(isValid);
        }
    }
}
