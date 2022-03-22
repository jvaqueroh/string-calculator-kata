using System;
using System.Linq;

namespace StringCalculator {
    public class StringCalculator {
        public int Add(string numbers)
        {
            if(string.IsNullOrWhiteSpace(numbers))
                return 0;
            var separators = new[] { ',', '\n' };

            if (numbers.StartsWith("//"))
            {
                separators = separators.Append(char.Parse(numbers.Substring(2, 1))).ToArray();
                numbers = numbers.Substring(4);
            }

            var numbersList = numbers.Split(separators);
            return numbersList.Sum(int.Parse);
        }
    }
}
