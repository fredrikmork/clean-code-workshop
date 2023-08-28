using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumeralConverterClean;

namespace RomanNumeralConverterCleanTest
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        [DataRow("1","I")]
        public void NumberToRomanNumeralTest(string numberInput, string expectedValue)
        {
            Assert.Equals(Program.NumbersToRomanNumerals(numberInput), expectedValue);
        }
    }
}
