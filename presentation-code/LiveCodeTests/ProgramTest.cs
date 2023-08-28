using LiveCode;

namespace LiveCodeTests
{
    public class ProgramTest
    {
        [Theory]
        [InlineData("1", "I")]
        [InlineData("1337", "MCCCXXXVII")]
        [InlineData("10000", "")]
        [InlineData("2222v", "")]
        public void NumberToRomanNumeralConverterTest(string inputNumber, string expectedRomanNumeral)
        {
            Assert.Equal(Program.NumberToRomanNumeral(inputNumber), expectedRomanNumeral);
        }

        [Theory]
        [InlineData("V", 5)]
        [InlineData("MCCCXXXVII", 1337)]
        public void RomanNumeralToNumberConverterTest(string inputRomanNumeral, int expectedNumber)
        {
            Assert.Equal(Program.RomanNumeralToNumber(inputRomanNumeral), expectedNumber);
        }
    }
}