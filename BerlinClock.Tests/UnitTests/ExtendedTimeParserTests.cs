using System;
using BerlinClock.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.Tests.UnitTests
{
    [TestClass]
    public class ExtendedTimeParserTests
    {
        [DataTestMethod]
        [DataRow("12:00 AM", true)]
        [DataRow("24:00", true)]
        [DataRow("24:0:0", true)]
        [DataRow("24:0", true)]
        [DataRow("11:0:0", true)]
        [DataRow("24:1:0", false)]
        [DataRow("12:70:0", false)]
        public void Should_SuccessfullyParse(string input, bool expectedValue)
        {
            Assert.AreEqual(expectedValue, ExtendedTimeParser.TryParse(input, out TimeSpan _));
        }
    }
}
