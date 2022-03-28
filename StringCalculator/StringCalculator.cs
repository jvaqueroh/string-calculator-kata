using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace StringCalculator {
    public class Separators
    {
        private List<string> Value { get; } = new List<string>() { ",", "\n" };

        public void Add(string newSeparator) {
            if(!string.IsNullOrWhiteSpace(newSeparator))
                Value.Add(newSeparator);
        }

        public string[] ToArray() {
            return Value.ToArray();
        }
    }

    public class StringCalculator {
        private readonly Separators separators = new Separators();

        public int Add(string numbers) {
            if(string.IsNullOrWhiteSpace(numbers))
                return 0;

            var customSeparator = ExtractCustomSeparator(numbers);
            separators.Add(customSeparator);

            numbers = RemoveHeader(numbers);

            var numbersList = numbers.Split(separators.ToArray(), StringSplitOptions.None);
            IEnumerable<int> parsedNumbers = ParseNumbers(numbersList);
            CheckNegatives(parsedNumbers);
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

        private void CheckNegatives(IEnumerable<int> numbersList) {
            foreach (var aNumber in numbersList) {
                var errorMessage = "";
                if (aNumber < 0)
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
