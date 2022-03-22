using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator {
    public class StringCalculator {
        public int Add(string numbers)
        {
            if(string.IsNullOrWhiteSpace(numbers))
                return 0;
            var separators = new List<char>() { ',', '\n' };

            numbers = ProcessHeader(numbers, separators);

            var numbersList = numbers.Split(separators.ToArray());
            return numbersList.Sum(int.Parse);
        }

        private static string ProcessHeader(string numbers, List<char> separators)
        {
            if (numbers.StartsWith("//"))
            {
                separators.Add(char.Parse(numbers.Substring(2, 1)));
                numbers = numbers.Substring(4);
            }

            return numbers;
        }
    }
}
