using NUnit.Framework;
using System.Collections.Generic;

namespace Receiver
{
    public class ReceiverTest
    {
        public List<string> GetTestData()
        {
            List<string> testData = new List<string>();

            testData.Add("[1,5,9,7,5,3,6,4,8,2]");
            testData.Add("[6,5,8,7,4,1,2,9,8,6]");

            return testData;
        }

        public void CheckStatisticsData(List<string> testData)
        {
            ReceiverMethods receiverMethods = new ReceiverMethods();
            List<StatisticsModel> statisticsData = receiverMethods.GetInputfromSender(testData);

            foreach(StatisticsModel statistics in statisticsData)
            {
                if(statistics.Sensor == "Temperature")
                {
                    Assert.AreEqual(statistics.Min, 1);
                    Assert.AreEqual(statistics.Max, 9);
                    Assert.AreEqual(statistics.SMA, "5.4, 4.6");
                }
                else
                {
                    Assert.AreEqual(statistics.Min, 1);
                    Assert.AreEqual(statistics.Max, 9);
                    Assert.AreEqual(statistics.SMA, "6.0, 5.2");
                }
            }            
        }
    }
}
