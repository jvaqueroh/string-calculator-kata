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

        [Test]
        public void return_the_sum_for_an_input_with_any_quantity_of_numbers_separated_by_comma()
        {
            var result = calculator.Add("7,8,9");

            result.Should().Be(24);
        }

        [Test]
        public void return_the_sum_for_an_input_with_comma_or_carry_return_separators()
        {
            var result = calculator.Add("7\n8,9");

            result.Should().Be(24);
        }

        [Test]
        public void return_the_sum_for_an_input_with_custom_separator_in_a_header_line()
        {
            var result = calculator.Add("//;\n7;8");

            result.Should().Be(15);
        }

        [Test]
        public void throws_exception_if_input_has_negative_numbers()
        {
            Func<int> call = () => calculator.Add("-7,8");

            call
                .Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage("*-7*");
        }

        [Test]
        public void ignore_numbers_greater_than_1000()
        {
            var result = calculator.Add("7,1001");

            result.Should().Be(7);
        }

        [Test]
        public void can_use_custom_separator_of_any_length()
        {
            var result = calculator.Add("//[***]\n7***8");

            result.Should().Be(15);
        }

        [Test]
        public void can_use_multiple_custom_separators_of_any_length()
        {
            var result = calculator.Add("//[*][%]\n7*8%9");

            result.Should().Be(24);
        }
    }
}
