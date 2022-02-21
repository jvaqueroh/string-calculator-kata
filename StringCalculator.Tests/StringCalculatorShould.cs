using System;
using FluentAssertions;
using NUnit.Framework;

namespace StringCalculator.Tests {
    public class StringCalculatorShould {
        [Test]
        public void not_be_instanciable()
        {
            var calculator = new StringCalculator();

            Assert.Fail("Should not reach this point due a previous compilation error when calling the ctor.");
        }
    }
}
