using System;
using System.Linq;

namespace StringCalculator {
    public class StringCalculator {
        public int Add(string numbers)
        {
            if(string.IsNullOrWhiteSpace(numbers))
                return 0;
            var separators = new char[] { ',', '\n' };
            return numbers.Split(separators).Sum(int.Parse);
        }
    }
}
