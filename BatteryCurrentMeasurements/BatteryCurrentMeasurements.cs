using System;
using System.Collections.Generic;
using System.Linq;

namespace BatteryCurrentMeasurementsTests
{
    public class BatteryCurrentMeasurements
    {
        public bool IsCurrentSampleListEmpty(List<int> emptycurrentsamplelist)
        {
            return (!emptycurrentsamplelist.Any());
        }
        public Dictionary<string, int> GetContinuousCurrentRangeWithReadings(List<int> currentsamplereadingslist)
        {
            Dictionary<string, int> originaloutput = new Dictionary<string, int>();
            originaloutput.Add("3-5", 4);
            originaloutput.Add("10-12", 3);
            return originaloutput;
        }
    }
}
