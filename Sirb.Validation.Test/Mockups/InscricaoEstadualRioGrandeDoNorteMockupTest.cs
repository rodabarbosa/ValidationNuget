using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups
{
    public class InscricaoEstadualRioGrandeDoNorteMockupTest
    {
        [Fact]
        public void Validate()
        {
            var value = InscricaoEstadual.Generate(State.RN);
            var isValid = InscricaoEstadualValidation.IsValid(State.RN, value);
            Assert.True(isValid);
        }
    }
}
