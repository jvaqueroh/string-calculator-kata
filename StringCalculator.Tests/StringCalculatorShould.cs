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
    }
}
