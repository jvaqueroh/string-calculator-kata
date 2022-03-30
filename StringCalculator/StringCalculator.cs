using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator {
    public class StringCalculator {
        private readonly Separators separators = new Separators();

        public int Add(string numbers) {
            if(string.IsNullOrWhiteSpace(numbers))
                return 0;

            ExtractCustomSeparators(numbers);
            
            numbers = RemoveHeader(numbers);
            IEnumerable<int> parsedNumbers = ParseNumbers(numbers);
            CheckNegatives(parsedNumbers);
            var numbersToSum = ExcludeNumbersAbove1000(parsedNumbers);
            return numbersToSum.Sum();
        }

        private IEnumerable<int> ExcludeNumbersAbove1000(IEnumerable<int> parsedNumbers)
        {
            return parsedNumbers.Where(n => n <= 1000);
        }

        private IEnumerable<int> ParseNumbers(string numbers) {
            var numbersList = numbers.Split(separators.ToArray(), StringSplitOptions.None);
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

        private string RemoveHeader(string numbers) {
            if (numbers.StartsWith("//")) {
                var endIndex = numbers.IndexOf("\n");
                numbers = numbers.Substring(endIndex+1);
            } 
            return numbers;
        }

        private void ExtractCustomSeparators(string numbers) {
            var header = numbers.Split("\n")[0];
            if (header.StartsWith("//[")) {
                var startIndex = header.IndexOf("[")+1;
                while (startIndex > 1) {
                    var endIndex = header.IndexOf("]", startIndex);
                    separators.Add(header.Substring(startIndex, endIndex-startIndex));
                    startIndex = header.IndexOf("[", endIndex)+1;
                }
            }
            if (header.StartsWith("//"))
                separators.Add(header.Substring(2, 1));
        }
    }
}
