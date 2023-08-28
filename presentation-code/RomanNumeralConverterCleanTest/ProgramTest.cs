using RomanNumeralConverterClean;

namespace RomanNumeralConverterCleanTests
{
    public class ProgramTest
    {
        [Theory]
        [InlineData("0","")]
        [InlineData("e","")]
        [InlineData("1","I")]
        [InlineData("5","V")]
        [InlineData("9","IX")]
        [InlineData("78", "LXXVIII")]
        public void RomanNumeralToNumberTest(string? numberInput, string expectedRomanNumeral)
        {
            var actualRomanNumeral = Program.ValidateInputAndConvertNumberToRomanNumeral(numberInput);
            Assert.Equal(expectedRomanNumeral, actualRomanNumeral);
        }

        [Theory]
        [InlineData("XI", 11)]
        [InlineData("mmcmix", 2909)]
        [InlineData("", 0)]
        [InlineData("MMCMIFX", 0)]
        [InlineData("1", 0)]
        public void NumberToRomanNumeralTest(string? romanInput, int expectedNumber)
        {
            var actualNumber = Program.ValidateInputAndConvertRomanNumeralToNumber(romanInput);
            Assert.Equal(expectedNumber, actualNumber);
        }
    }
}