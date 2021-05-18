using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryCurrentMeasurement
{
    public class BatteryCurrentMeasurements
    {
        public bool IsCurrentReadingsListEmpty(List<int> emptycurrentsamplelist)
        {
            return (!emptycurrentsamplelist.Any());
        }
        public Dictionary<string, int> GetContinuousCurrentRangeWithReadings(List<int> currentsamplereadingslist)
        {
            if (!IsCurrentReadingsListEmpty(currentsamplereadingslist))
            {
                Dictionary<string, int> originaloutput = new Dictionary<string, int>();
                currentsamplereadingslist.Sort();
                int firstReading = currentsamplereadingslist[0];
                int lastReading = currentsamplereadingslist[0];
                int currentReading = currentsamplereadingslist[0];
                int counter = 1;
                for (int i = 1; i < currentsamplereadingslist.Count(); i++)
                {
                    if (currentReading == currentsamplereadingslist[i] || currentReading + 1 == currentsamplereadingslist[i])
                    {
                        currentReading = lastReading = currentsamplereadingslist[i];
                        counter++;
                    }
                    else
                    {
                        originaloutput.Add(firstReading + "-" + lastReading, counter);
                        currentReading = lastReading = firstReading = currentsamplereadingslist[i];
                        counter = 1;
                    }
                }
                originaloutput.Add(firstReading + "-" + lastReading, counter);
                return originaloutput;
            }
            return null;
        }
    }
}
