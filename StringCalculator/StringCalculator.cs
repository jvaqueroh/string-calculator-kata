using System;
using System.Linq;

namespace StringCalculator {
    public class StringCalculator {
        public int Add(string numbers)
        {
            if(string.IsNullOrWhiteSpace(numbers))
                return 0;
            var values = numbers.Split(",");
            if (values.Length == 2)
                return values.Sum(int.Parse);
            return int.Parse(numbers);
        }
    }
}
