using System;
using FluentAssertions;
using NUnit.Framework;

namespace StringCalculator.Tests {
    public class StringCalculatorShould {
        [Test]
        public void return_0_for_an_empty_string()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("");
            result.Should().Be(0);
        }
    }
}
