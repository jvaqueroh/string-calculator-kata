using System;
using System.Linq;

namespace StringCalculator {
    public class StringCalculator {
        public int Add(string numbers)
        {
            if(string.IsNullOrWhiteSpace(numbers))
                return 0;
            var defaultSeparators = new string[] { ",", "\n" };
            if (numbers.StartsWith("//"))
            {
                var lines = numbers.Split("\n");
                var customSeparator = lines[0].Substring(2, 1);
                defaultSeparators = defaultSeparators.Append(customSeparator).ToArray();
                numbers = numbers.Substring(lines[0].Length-1);
            }

            var values = numbers.Split(defaultSeparators, StringSplitOptions.RemoveEmptyEntries);
            return values.Sum(int.Parse);
        }
    }
}
