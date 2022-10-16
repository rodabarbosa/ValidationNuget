using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;
using Xunit;
using InscricaoEstadual = Sirb.Validation.Documents.BR.Mockups.InscricaoEstadual;

namespace Sirb.Validation.Test
{
    public class InscricaoEstadualTest
    {
        [Fact]
        public void ValidateAC()
        {
            //const string value = "0147835924265"; // valid
            var value = InscricaoEstadual.Generate(State.AC);
            Assert.True(InscricaoEstadualValidation.IsValid(State.AC, value));
        }

        [Fact]
        public void ValidateAL()
        {
            //const string value = "248813420"; // valid
            var value = InscricaoEstadual.Generate(State.AL);
            Assert.True(InscricaoEstadualValidation.IsValid(State.AL, value));
        }

        [Fact]
        public void ValidateAM()
        {
            //const string value = "585040818"; // valid
            var value = InscricaoEstadual.Generate(State.AM);
            Assert.True(InscricaoEstadualValidation.IsValid(State.AM, value));
        }

        [Fact]
        public void ValidateAP()
        {
            // string value = "034078983"; // valid
            var value = InscricaoEstadual.Generate(State.AP);
            Assert.True(InscricaoEstadualValidation.IsValid(State.AP, value));
        }

        [Fact]
        public void ValidateBA()
        {
            //const string value = "75658100"; // valid
            var value = InscricaoEstadual.Generate(State.BA);
            Assert.True(InscricaoEstadualValidation.IsValid(State.BA, value));
        }

        [Fact]
        public void ValidateCE()
        {
            //const string value = "697620638"; // valid
            var value = InscricaoEstadual.Generate(State.CE);
            Assert.True(InscricaoEstadualValidation.IsValid(State.CE, value));
        }

        [Fact]
        public void ValidateDF()
        {
            //const string value = "0706664500149"; //
            var value = InscricaoEstadual.Generate(State.DF);
            Assert.True(InscricaoEstadualValidation.IsValid(State.DF, value));
        }

        [Fact]
        public void ValidateES()
        {
            //const string value = "163051950"; // valid
            var value = InscricaoEstadual.Generate(State.ES);
            Assert.True(InscricaoEstadualValidation.IsValid(State.ES, value));
        }

        [Fact]
        public void ValidateGO()
        {
            //const string value = "110075919"; // valid
            var value = InscricaoEstadual.Generate(State.GO);
            Assert.True(InscricaoEstadualValidation.IsValid(State.GO, value));
        }

        [Fact]
        public void ValidateMA()
        {
            //const string value = "121360814"; // valid
            var value = InscricaoEstadual.Generate(State.MA);
            Assert.True(InscricaoEstadualValidation.IsValid(State.MA, value));
        }

        [Fact]
        public void ValidateMG()
        {
            //const string value = "5672215254268"; // valid
            var value = InscricaoEstadual.Generate(State.MG);
            Assert.True(InscricaoEstadualValidation.IsValid(State.MG, value));
        }

        [Fact]
        public void ValidateMS()
        {
            //const string value = "289190908"; // valid
            var value = InscricaoEstadual.Generate(State.MS);
            Assert.True(InscricaoEstadualValidation.IsValid(State.MS, value));
        }

        [Fact]
        public void ValidateMT()
        {
            //const string value = "09636557239"; // valid
            var value = InscricaoEstadual.Generate(State.MT);
            Assert.True(InscricaoEstadualValidation.IsValid(State.MT, value));
        }

        [Fact]
        public void ValidatePA()
        {
            //const string value = "150988621"; // valid
            var value = InscricaoEstadual.Generate(State.PA);
            Assert.True(InscricaoEstadualValidation.IsValid(State.PA, value));
        }

        [Fact]
        public void ValidatePB()
        {
            //const string value = "465160735"; // valid
            var value = InscricaoEstadual.Generate(State.PB);
            Assert.True(InscricaoEstadualValidation.IsValid(State.PB, value));
        }

        [Fact]
        public void ValidatePE()
        {
            //const string value = "383333253"; // valid
            var value = InscricaoEstadual.Generate(State.PE);
            Assert.True(InscricaoEstadualValidation.IsValid(State.PE, value));
        }

        [Fact]
        public void ValidatePI()
        {
            //const string value = "681338903"; // valid
            var value = InscricaoEstadual.Generate(State.PI);
            Assert.True(InscricaoEstadualValidation.IsValid(State.PI, value));
        }

        [Fact]
        public void ValidatePR()
        {
            //const string value = "1212323086"; // valid
            var value = InscricaoEstadual.Generate(State.PR);
            Assert.True(InscricaoEstadualValidation.IsValid(State.PR, value));
        }

        [Fact]
        public void ValidateRJ()
        {
            //const string value = "91534932"; // valid
            var value = InscricaoEstadual.Generate(State.RJ);
            Assert.True(InscricaoEstadualValidation.IsValid(State.RJ, value));
        }

        [Fact]
        public void ValidateRN()
        {
            //const string value = "208436812"; // valid
            var value = InscricaoEstadual.Generate(State.RN);
            Assert.True(InscricaoEstadualValidation.IsValid(State.RN, value));
        }

        [Fact]
        public void ValidateRO()
        {
            //const string value = "91334325351252"; // valid
            var value = InscricaoEstadual.Generate(State.RO);
            Assert.True(InscricaoEstadualValidation.IsValid(State.RO, value));
        }

        [Fact]
        public void ValidateRR()
        {
            //const string value = "245194766"; // valid
            var value = InscricaoEstadual.Generate(State.RR);
            Assert.True(InscricaoEstadualValidation.IsValid(State.RR, value));
        }

        [Fact]
        public void ValidateRS()
        {
            //const string value = "6065456989"; // valid
            var value = InscricaoEstadual.Generate(State.RS);
            Assert.True(InscricaoEstadualValidation.IsValid(State.RS, value));
        }

        [Fact]
        public void ValidateSC()
        {
            //const string value = "744159148"; // valid
            var value = InscricaoEstadual.Generate(State.SC);
            Assert.True(InscricaoEstadualValidation.IsValid(State.SC, value));
        }

        [Fact]
        public void ValidateSE()
        {
            //const string value = "256358630"; // valid
            var value = InscricaoEstadual.Generate(State.SE);
            Assert.True(InscricaoEstadualValidation.IsValid(State.SE, value));
        }

        [Fact]
        public void ValidateSP()
        {
            //const string value = "685625637442"; // valid
            var value = InscricaoEstadual.Generate(State.SP);
            Assert.True(InscricaoEstadualValidation.IsValid(State.SP, value));
        }

        [Fact]
        public void ValidateSPWithP()
        {
            const string value = "P-01100424.3/002"; // valid
            Assert.True(InscricaoEstadualValidation.IsValid(State.SP, value));
        }

        [Fact]
        public void ValidateTO()
        {
            //const string value = "18034891949"; // valid
            var value = InscricaoEstadual.Generate(State.TO);
            Assert.True(InscricaoEstadualValidation.IsValid(State.TO, value));
        }
    }
}
