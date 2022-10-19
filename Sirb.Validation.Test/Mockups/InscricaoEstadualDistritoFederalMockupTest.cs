using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups
{
    public class InscricaoEstadualDistritoFederalMockupTest
    {
        [Fact]
        public void Validate()
        {
            var value = InscricaoEstadual.Generate(State.DF);
            var isValid = InscricaoEstadualValidation.IsValid(State.DF, value);
            Assert.True(isValid);
        }
    }
}
