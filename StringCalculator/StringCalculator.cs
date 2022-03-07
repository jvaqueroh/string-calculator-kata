﻿using System;
using System.Linq;

namespace StringCalculator {
    public class StringCalculator {
        private readonly string[] defatultSeparators = new string[] { ",", "\n" };

        public int Add(string numbers)
        {
            if(string.IsNullOrWhiteSpace(numbers))
                return 0;
            
            var customSeparators = defatultSeparators;
            numbers = ProcessHeader(numbers, ref customSeparators);

            var values = numbers.Split(customSeparators, StringSplitOptions.RemoveEmptyEntries);
            CheckNegativeNumbers(values);

            return values.Sum(int.Parse);
        }

        private static void CheckNegativeNumbers(string[] values)
        {
            string negativeNumbers = string.Empty;
            foreach (var aNumber in values)
            {
                if (aNumber.StartsWith("-"))
                    negativeNumbers += aNumber + ", ";
            }

            if (!string.IsNullOrWhiteSpace(negativeNumbers))
                throw new ArgumentOutOfRangeException($"Negative numbers are not allowed: {negativeNumbers}");
        }

        private string ProcessHeader(string numbers, ref string[] customSeparators)
        {
            if (numbers.StartsWith("//"))
            {
                var lines = numbers.Split("\n");
                var customSeparator = lines[0].Substring(2, 1);
                customSeparators = defatultSeparators.Append(customSeparator).ToArray();
                numbers = numbers.Substring(lines[0].Length - 1);
            }

            return numbers;
        }
    }
}
