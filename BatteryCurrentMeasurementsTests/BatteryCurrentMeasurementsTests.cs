using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using System.Collections.Generic;
using System;
using System.Linq;
using BatteryCurrentMeasurementsTests;

namespace BatteryCurrentMeasurementsTests
{
    [TestClass]
    public class BatteryCurrentRangeMeasurementsTests
    {
        BatteryCurrentMeasurements _currentreadings = new BatteryCurrentMeasurements();
        [TestMethod]
        public void GivenEmptySampleList_WhenSampleListIsEmpty_ThenReturnTrue()
        {
            List<int> emptycurrentsamplelist = new List<int>();
            bool islistempty= _currentreadings.IsCurrentSampleListEmpty(emptycurrentsamplelist);
            Assert.IsTrue(islistempty);
        }
        [TestMethod]
        public void GivenNonEmptySampleList_WhenSampleListIsNotEmpty_ThenReturnFalse()
        {
            List<int> emptycurrentsamplelist = new List<int>() { 3, 3, 5, 4, 10, 11, 12 };
            bool islistempty = _currentreadings.IsCurrentSampleListEmpty(emptycurrentsamplelist);
            Assert.IsFalse(islistempty);
        }
        [TestMethod]
        public void GivenCurrentReadingsSampleList_WhenSampleListIsInput_ThenReturnExpectedOutput()
        {
            List<int> currentsamplereadingslist = new List<int>() { 3, 3, 5, 4, 10, 11, 12 };
            Dictionary<string, int> expectedoutput = new Dictionary<string, int>();
            expectedoutput.Add("3-5", 4);
            expectedoutput.Add("10-12", 3);
            Dictionary<string, int> originaloutput = _currentreadings.GetContinuousCurrentRangeWithReadings(currentsamplereadingslist);
            Assert.AreEqual(originaloutput, expectedoutput);
        }
        [TestMethod]
        public void GivenCurrentReadingsSampleList_WhenSampleListIsInput_ThenReturnNotExpectedOutput()
        {
            List<int> currentsamplereadingslist = new List<int>() { 3, 3, 5, 4, 10, 11, 12 };
            Dictionary<string, int> expectedoutput = new Dictionary<string, int>();
            expectedoutput.Add("3-5", 4);
            expectedoutput.Add("10-12", 7);
            Dictionary<string, int> originaloutput = _currentreadings.GetContinuousCurrentRangeWithReadings(currentsamplereadingslist);
            Assert.AreNotEqual(originaloutput, expectedoutput);
        }
    }
}
