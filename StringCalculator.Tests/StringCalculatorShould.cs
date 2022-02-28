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
        public void return_0_for_an_empty_string()
        {
            var result = calculator.Add("");
            result.Should().Be(0);
        }

        [Test]
        public void return_same_number_for_an_input_with_only_one()
        {
            var result = calculator.Add("7");
            result.Should().Be(7);
        }

        [Test]
        public void return_the_sum_for_an_input_with_two_comma_separated_values()
        {
            var result = calculator.Add("7,6");
            result.Should().Be(13);
        }

        [Test]
        public void return_the_sum_for_an_input_with_any_comma_separated_values()
        {
            var result = calculator.Add("7,6,8,2");
            result.Should().Be(23);
        }

        [Test]
        public void return_the_sum_for_an_input_with_carry_return_separator()
        {
            var result = calculator.Add("7\n6");
            result.Should().Be(13);
        }

        [Test]
        public void return_the_sum_for_an_input_with_custom_separator_line()
        {
            var result = calculator.Add("//;\n7;6");
            result.Should().Be(13);
        }
    }
}
