using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups
{
    public class InscricaoMinasGeraisMockupTest
    {
        [Fact]
        public void Validate()
        {
            var value = InscricaoEstadual.Generate(State.MG);
            var isValid = InscricaoEstadualValidation.IsValid(State.MG, value);
            Assert.True(isValid);
        }
    }
}
