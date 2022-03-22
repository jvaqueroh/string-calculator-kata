using System;
using System.Linq;

namespace StringCalculator {
    public class StringCalculator {
        public int Add(string numbers)
        {
            if(string.IsNullOrWhiteSpace(numbers))
                return 0;
            var numbersList = numbers.Split(',');
            return numbersList.Sum(n => int.Parse(n));
        }
    }
}
