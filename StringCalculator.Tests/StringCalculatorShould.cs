using System;
using FluentAssertions;
using NUnit.Framework;

namespace StringCalculator.Tests {
    public class StringCalculatorShould {
        [Test]
        public void return_0_for_an_empty_input()
        {
            var calulator = new StringCalculator();

            var result = calulator.Add("");

            result.Should().Be(0);
        }

        [Test]
        public void return_same_number_for_an_input_with_one_value()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("7");

            result.Should().Be(7);
        }

        [Test]
        public void return_the_sum_for_an_input_with_two_comma_separated_values()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("6,7");
            
            result.Should().Be(13);
        }
    }
}
