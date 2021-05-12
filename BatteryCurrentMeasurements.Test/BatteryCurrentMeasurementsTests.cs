using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            Assert.AreEqual(originaloutput["3-5"], expectedoutput["3-5"]);
            Assert.AreEqual(originaloutput["10-12"], expectedoutput["10-12"]);
        }
        [TestMethod]
        public void GivenCurrentReadingsSampleList_WhenSampleListIsInput_ThenReturnNotExpectedOutput()
        {
            List<int> currentsamplereadingslist = new List<int>() { 3, 5, 4, 10, 11, 12 };
            Dictionary<string, int> expectedoutput = new Dictionary<string, int>();
            expectedoutput.Add("3-5", 3);
            expectedoutput.Add("10-12", 3);
            Dictionary<string, int> originaloutput = _currentreadings.GetContinuousCurrentRangeWithReadings(currentsamplereadingslist);
            Assert.AreEqual(originaloutput["3-5"], expectedoutput["3-5"]);
            Assert.AreEqual(originaloutput["10-12"], expectedoutput["10-12"]);
        }
    }
}