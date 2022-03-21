﻿using System;
using FluentAssertions;
using NUnit.Framework;

namespace StringCalculator.Tests {
    public class StringCalculatorShould {
        private StringCalculator calculator;

        [SetUp()]
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
        public void return_same_number_when_input_has_only_one_operator()
        {
            var result = calculator.Add("7");
            result.Should().Be(7);
        }

        [Test]
        public void return_the_sum_when_input_is_two_numbers_separated_by_comma()
        {
            var result = calculator.Add("7,8");
            result.Should().Be(15);
        }
    }
}
