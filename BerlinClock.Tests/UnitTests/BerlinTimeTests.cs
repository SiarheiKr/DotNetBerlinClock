using System;
using BerlinClock.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.Tests.UnitTests
{
    [TestClass]
    public class BerlinTimeTests
    {
        private BerlinTime _berlinTime;
        
        [TestInitialize]
        public void Initialize()
        {
            _berlinTime = new BerlinTime(5, 5, 2);
        }

        [DataTestMethod]
        [DataRow("1.0:00", 4, 4, 0, 0, true)]
        [DataRow("23:59:59", 4, 3, 11, 4, false)]
        [DataRow("00:00:10", 0, 0, 0, 0, true)]
        [DataRow("11:12:32", 2, 1, 2, 2, true)]
        [DataRow("15:03:31", 3, 0, 0, 3, false)]
        public void Should_CalculatedBigHoursBeValid(string time, 
            int expectedBigHours, 
            int expectedHours, 
            int expectedBigMinutes, 
            int expectedMinutes, 
            bool expectedSecondsState)
        {
            _berlinTime.Update(TimeSpan.Parse(time));

            Assert.AreEqual(expectedBigHours, _berlinTime.BigHours);
            Assert.AreEqual(expectedHours, _berlinTime.Hours);
            Assert.AreEqual(expectedBigMinutes,_berlinTime.BigMinutes);
            Assert.AreEqual(expectedMinutes, _berlinTime.Minutes);
            Assert.AreEqual(expectedSecondsState, _berlinTime.IsSecondsOn);
        }

        [DataTestMethod]
        [DataRow("1.05:00")]
        [DataRow("-05:00")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_ThrowException_IfTimeIsOutOfRange(string time)
        {
            _berlinTime.Update(TimeSpan.Parse(time));
        }

        [DataTestMethod]
        [DataRow(31, 5, 2)]
        [DataRow(0, 5, 2)]
        [DataRow(5, 61, 2)]
        [DataRow(5, 5, 0)]
        [DataRow(5, 5, 70)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_ThrowException_IfBeingCreatedWithInvalidArgs(int hoursPerBigHour, int minutesPerBigMinute, int secondsRepetitiveness)
        {
            _berlinTime = new BerlinTime((byte)hoursPerBigHour, (byte)minutesPerBigMinute, (byte)secondsRepetitiveness);
        }
    }
}
