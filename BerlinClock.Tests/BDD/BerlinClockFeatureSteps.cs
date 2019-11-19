using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BerlinClock.Converters;
using BerlinClock.Core;

namespace BerlinClock.Tests.BDD
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private ITimeConverter berlinClock = new TimeToTextConverter();
        private String theTime;

        
        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            theTime = time;
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(theExpectedBerlinClockOutput, berlinClock.ConvertTime(theTime));
        }

        [Then(@"an exception should be thrown")]
        [ExpectedException(typeof(ArgumentException))]
        public void ThenAnExceptionShouldBethrown()
        {
        }
    }
}
