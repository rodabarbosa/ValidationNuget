using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups
{
    public class InscricaoEstadualSergipeMockupTest
    {
        [Fact]
        public void Validate()
        {
            var value = InscricaoEstadual.Generate(State.SE);
            var isValid = InscricaoEstadualValidation.IsValid(State.SE, value);
            Assert.True(isValid);
        }
    }
}
