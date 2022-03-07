using System;
using System.Linq;

namespace StringCalculator {
    public class StringCalculator {
        private readonly string[] defatultSeparators = new string[] { ",", "\n" };

        public int Add(string numbers)
        {
            if(string.IsNullOrWhiteSpace(numbers))
                return 0;
            
            var customSeparators = defatultSeparators;
            if (numbers.StartsWith("//"))
            {
                var lines = numbers.Split("\n");
                var customSeparator = lines[0].Substring(2, 1);
                customSeparators = defatultSeparators.Append(customSeparator).ToArray();
                numbers = numbers.Substring(lines[0].Length-1);
            }

            var values = numbers.Split(customSeparators, StringSplitOptions.RemoveEmptyEntries);
            return values.Sum(int.Parse);
        }
    }
}
