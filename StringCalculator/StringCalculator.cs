using System;
using System.Linq;

namespace StringCalculator {
    public class StringCalculator {
        public int Add(string numbers)
        {
            if(string.IsNullOrWhiteSpace(numbers))
                return 0;
            var separators = new[] { ',', '\n' };
            var numbersList = numbers.Split(separators);
            return numbersList.Sum(int.Parse);
        }
    }
}
