using System;
using System.Linq;

namespace StringCalculator {
    public class StringCalculator {
        public int Add(string numbers)
        {
            if(string.IsNullOrWhiteSpace(numbers))
                return 0;
            var separators = new string[] { ",", "\n" };
            var values = numbers.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return values.Sum(int.Parse);
        }
    }
}
