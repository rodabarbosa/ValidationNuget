using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups
{
    public class InscricaoEstadualAmapaMockupTest
    {
        [Theory]
        [InlineData(10)]
        public void Validate(int retry)
        {
            for (var i = 0; i < retry; i++)
            {
                var value = InscricaoEstadual.Generate(State.AP);
                var isValid = InscricaoEstadualValidation.IsValid(State.AP, value);
                Assert.True(isValid);
            }
        }
    }
}
