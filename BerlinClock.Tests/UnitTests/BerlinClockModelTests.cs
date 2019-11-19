using System.Linq;
using BerlinClock.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.Tests.UnitTests
{
    [TestClass]
    public class BerlinClockModelTests
    {
        [TestMethod]
        public void Should_CreateAllNeededBulbs()
        {
            var clockModel = new BerlinClockModel();

            Assert.IsNotNull(clockModel.SecondsBulb);
            Assert.AreEqual(4, clockModel.BigHoursBulbs.Count());
            Assert.AreEqual(4, clockModel.HoursBulbs.Count());
            Assert.AreEqual(11, clockModel.BigMinutesBulbs.Count());
            Assert.AreEqual(4, clockModel.MinutesBulbs.Count());
        }
    }
}
