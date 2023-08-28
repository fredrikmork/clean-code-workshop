namespace RomanNumeralConverterClean
{
    class Program
    {
        private static readonly Dictionary<int, string> _numberRomanNumeralPairs = new()
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" }
        };
        static void Main(string[] _)
        {
            Console.WriteLine("--WELCOME TO Number/Roman Numerals converter---");
            Console.WriteLine("Press Enter to exit the application.");
            while (true) RomanNumeralConverterConsoleApp();
        }

        private static void RomanNumeralConverterConsoleApp()
        {
            Console.WriteLine("\nPress [1] to convert from number to roman numerals:");
            Console.WriteLine("Press [2] to convert from roman numerals to numbers:");

            var optionInput = Console.ReadLine();
            var isNumber = int.TryParse(optionInput, out var convertOption);
            if (!isNumber) return;

            HandleNumberOrRomanConvertOptions(convertOption);
        }

        private static void HandleNumberOrRomanConvertOptions(int convertOption)
        {
            switch (convertOption)
            {
                case 1:
                    WriteInputAndConvertNumberToRomanNumeral();
                    break;
                case 2:
                    WriteInputAndConvertRomanNumeralToNumber();
                    break;
                default:
                    Console.WriteLine("\nYou must select either [1] or [2].");
                    break;
            }
        }

        private static void WriteInputAndConvertNumberToRomanNumeral()
        {
            Console.WriteLine("Enter a number in the range between 1 and 3999:");
            var numberInput = Console.ReadLine();
            ValidateInputAndConvertNumberToRomanNumeral(numberInput);
        }

        public static string ValidateInputAndConvertNumberToRomanNumeral(string? numberInput)
        {
            var isValidNumberAndWithinRange = int.TryParse(numberInput, out var number) && Enumerable.Range(1, 3999).Contains(number);
            if (!isValidNumberAndWithinRange)
            { 
                Console.WriteLine("Your input is invalid.");
                return string.Empty;
            }

            var romanNumeral = ConvertNumberToRomanNumeral(number);
            Console.Write($"The roman numeral for {number} is: {romanNumeral}.\n");
            return romanNumeral;
        }

        private static string ConvertNumberToRomanNumeral(int number)
        {
            var romanNumeral = string.Empty;
            var remainingValue = number;
            
            foreach (var pair in _numberRomanNumeralPairs)
            {
                var quotient = remainingValue / pair.Key;
                if (quotient is 0) continue;
                
                romanNumeral += string.Concat(Enumerable.Repeat(pair.Value, quotient));
                remainingValue -= pair.Key * quotient;
            }

            return romanNumeral;
        }

        private static void WriteInputAndConvertRomanNumeralToNumber()
        {
            Console.WriteLine("Enter a roman numeral less or equal than MMMCMXCIX(3999):");
            var romanInput = Console.ReadLine();
            ValidateInputAndConvertRomanNumeralToNumber(romanInput);
           
        }

        public static int ValidateInputAndConvertRomanNumeralToNumber(string? romanInput)
        {
            if (!IsValidRomanNumeral(romanInput))
            {
                Console.WriteLine("Invalid input. Please enter a valid roman numeral.");
                return 0;
            }

            var number = ConvertRomanNumeralToNumber(romanInput);
            return number;
        }

        private static bool IsValidRomanNumeral(string? romanInput)
        {
            if (string.IsNullOrEmpty(romanInput)) return false;
            romanInput = romanInput.ToUpper();
            foreach(var c in romanInput)
            {
                if (!_numberRomanNumeralPairs.ContainsValue($"{c}")) 
                    return false;
            }
            return true;
        }

        private static int ConvertRomanNumeralToNumber(string romanInput)
        {
            romanInput = romanInput.ToUpper();
            var number = 0;
            var index = 0;

            while (index < romanInput.Length)
            {
                var symbol = romanInput[index].ToString();
                if (index < romanInput.Length - 1)
                {
                    var nextSymbol = romanInput[index + 1].ToString();
                    var twoSymbols = symbol + nextSymbol;
                    if (_numberRomanNumeralPairs.ContainsValue(twoSymbols))
                    {
                        foreach (var pair in _numberRomanNumeralPairs)
                        {
                            if (pair.Value == twoSymbols)
                            {
                                number += pair.Key;
                                index += twoSymbols.Length;
                                break;
                            }
                        }
                        continue;
                    }
                }

                foreach (var pair in _numberRomanNumeralPairs)
                {
                    if (pair.Value == symbol)
                    {
                        number += pair.Key;
                        index += symbol.Length;
                        break;
                    }
                }
            }
            Console.Write($"The number for {romanInput} is: {number}.\n");
            return number;
        }
    }
}