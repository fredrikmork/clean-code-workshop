namespace live-code
{ }
Console.WriteLine("--WELCOME TO Number/Roman Numerals converter---");
Console.WriteLine("Press Enter to exit the application.\n");
while (true) //Console.ReadKey().Key != ConsoleKey.Enter
{
    Console.WriteLine("Press [1] to convert from number to roman numerals:");
    Console.WriteLine("Press [2] to convert from roman numerals to numbers:");
    var converterOption = Console.ReadLine();
    var isNumber = int.TryParse(converterOption, out var option);
    Dictionary<int, string> baseValues = new()
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
    if (!isNumber) return;
    switch (option)
    {
        case 1:
            Console.WriteLine("Enter a number in the range between 1 and 3999:");
            var numberInput = Console.ReadLine();
            bool isValidNumber = int.TryParse(numberInput, out var validNumber);
            if (isValidNumber && Enumerable.Range(1, 3999).Contains(validNumber))
            {
                var romanNumeral = string.Empty;
                var tempNumber = validNumber;
                foreach (var baseValue in baseValues)
                {
                    var quotient = tempNumber / baseValue.Key; // if temp is 20 and the key is 10, the q will be 2
                    if (quotient is 0) continue; //if q is 0 skip to next baseValue
                    romanNumeral += string.Concat(Enumerable.Repeat(baseValue.Value, quotient));
                    tempNumber -= baseValue.Key * quotient;
                }
                Console.WriteLine($"The roman numeral for {validNumber} is: {romanNumeral}.\n");
                break;
            }
            Console.WriteLine("Your input is invalid.");
            break;
        case 2:
            Console.WriteLine("Enter a roman numeral below MMMCMXCIX(3999):");
            var romanInput = Console.ReadLine();
            if (romanInput is null) return;
            romanInput = romanInput.ToUpper();
            var result = 0;
            var index = 0;
            while (index < romanInput.Length)
            {
                var symbol = romanInput.Substring(index, 1);
                if (index < romanInput.Length - 1)
                {
                    var nextSymbol = romanInput.Substring(index + 1, 1);
                    var twoSymbols = symbol + nextSymbol;
                    if (baseValues.ContainsValue(twoSymbols))
                    {
                        foreach (var baseValue in baseValues)
                        {
                            if (baseValue.Value == twoSymbols)
                            {
                                result += baseValue.Key;
                                index += 2;
                                break;
                            }
                        }
                        continue;
                    }
                }
                foreach (var baseValue in baseValues)
                {
                    if (baseValue.Value == symbol)
                    {
                        result += baseValue.Key;
                        index += 1;
                        break;
                    }
                }
            }
            Console.WriteLine($"The number for {romanInput} is: {result}.\n");
            break;
        default:
            Console.WriteLine("You must select either [1] or [2].");
            break;
    }
}