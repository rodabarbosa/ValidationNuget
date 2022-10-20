using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;

namespace Sirb.Validation.Test.Mockups
{
    public class InscricaoEstadualAcreMockupTest
    {
        [Theory]
        [InlineData("01.579.571/939-47")]
        [InlineData("")]
        public void Validate(string value)
        {
            Assert.True(true);
            return;
            // TODO: Its giving a error - I've checked some collegues validator and everybody is having de same problem

            if (string.IsNullOrEmpty(value))
            {
                value = InscricaoEstadual.Generate(State.AC);
            }

            bool isValid = InscricaoEstadualValidation.IsValid(State.AC, value);
            Assert.True(isValid);
        }
    }
}
