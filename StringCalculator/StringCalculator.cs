using System;
using System.Linq;

namespace StringCalculator {
    public class StringCalculator {
        public int Add(string numbers)
        {
            if(string.IsNullOrWhiteSpace(numbers))
                return 0;
            var separators = new char[] { ',', '\n' };

            if (numbers.StartsWith("//"))
            {
                char customSeparator = char.Parse(numbers.Split("\n")[0].Split("//")[1]);
                separators.Append(customSeparator);
                numbers = numbers.Substring(numbers.IndexOf("\n")+1);
            }

            return numbers.Split(separators).Sum(int.Parse);
        }
    }
}
