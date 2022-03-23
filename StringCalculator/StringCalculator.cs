using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator {
    public class StringCalculator {
        public int Add(string numbers) {
            if(string.IsNullOrWhiteSpace(numbers))
                return 0;
            
            var separators = new List<char>() { ',', '\n' };
            var customSeparator = ExtractCustomSeparator(numbers);
            if(customSeparator != null)
                separators.Add(customSeparator.Value);

            numbers = RemoveHeader(numbers);

            var numbersList = numbers.Split(separators.ToArray());
            CheckNegatives(numbersList);
            
            return numbersList.Sum(int.Parse);
        }

        private static void CheckNegatives(string[] numbersList)
        {
            foreach (var aNumber in numbersList) {
                var errorMessage = "";
                if (int.Parse(aNumber) < 0)
                    errorMessage += aNumber + ",";
                if (!string.IsNullOrWhiteSpace(errorMessage))
                    throw new ArgumentOutOfRangeException(errorMessage);
            }
        }

        private static string RemoveHeader(string numbers) {
            if (numbers.StartsWith("//")) 
                numbers = numbers.Substring(4);
            return numbers;
        }

        private static char? ExtractCustomSeparator(string numbers) {
            if (numbers.StartsWith("//"))
                return char.Parse(numbers.Substring(2, 1));
            return null;
        }
    }
}
