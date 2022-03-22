using System;
using FluentAssertions;
using NUnit.Framework;

namespace StringCalculator.Tests {
    public class StringCalculatorShould {
        private StringCalculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new StringCalculator();
        }

        [Test]
        public void return_0_for_an_empty_input()
        {
            var result = calculator.Add("");

            result.Should().Be(0);
        }

        [Test]
        public void return_same_number_for_an_input_with_one_number()
        {
            var result = calculator.Add("7");

            result.Should().Be(7);
        }

        [Test]
        public void return_the_sum_for_an_input_with_two_numbers_separated_by_comma()
        {
            var result = calculator.Add("7,8");

            result.Should().Be(15);
        }
    }
}
