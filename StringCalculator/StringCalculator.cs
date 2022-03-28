using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace StringCalculator {
    public class StringCalculator {
        private readonly List<string> separators = new List<string>() { ",", "\n" };

        public int Add(string numbers) {
            if(string.IsNullOrWhiteSpace(numbers))
                return 0;

            var customSeparator = ExtractCustomSeparator(numbers);
            if(!string.IsNullOrWhiteSpace(customSeparator))
                separators.Add(customSeparator);

            numbers = RemoveHeader(numbers);

            var numbersList = numbers.Split(separators.ToArray(), StringSplitOptions.None);
            CheckNegatives(numbersList);
            
            IEnumerable<int> parsedNumbers = ParseNumbers(numbersList);
            var numbersToSum = ExcludeNumbersAbove1000(parsedNumbers);
            return numbersToSum.Sum();
        }

        private IEnumerable<int> ExcludeNumbersAbove1000(IEnumerable<int> parsedNumbers)
        {
            return parsedNumbers.Where(n => n <= 1000);
        }

        private IEnumerable<int> ParseNumbers(IEnumerable<string> numbersList) {
            return numbersList.Select(int.Parse);
        }

        private void CheckNegatives(string[] numbersList) {
            foreach (var aNumber in numbersList) {
                var errorMessage = "";
                if (int.Parse(aNumber) < 0)
                    errorMessage += aNumber + ",";
                if (!string.IsNullOrWhiteSpace(errorMessage))
                    throw new ArgumentOutOfRangeException(errorMessage);
            }
        }

        private static string RemoveHeader(string numbers) {
            if (numbers.StartsWith("//")) {
                var endIndex = numbers.IndexOf("\n");
                numbers = numbers.Substring(endIndex+1);
            } 
            return numbers;
        }

        private static string ExtractCustomSeparator(string numbers) {
            if (numbers.StartsWith("//[")) {
                var startIndex = numbers.IndexOf("//[")+3;
                var endIndex = numbers.IndexOf("]");
                return numbers.Substring(startIndex, endIndex-startIndex);
            }
            if (numbers.StartsWith("//"))
                return numbers.Substring(2, 1);
            return null;
        }
    }
}
