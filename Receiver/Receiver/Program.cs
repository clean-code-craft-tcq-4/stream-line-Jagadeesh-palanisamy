using System;
using System.Collections.Generic;

namespace Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            ReceiverMethods receiverMethod = new ReceiverMethods();
            List<StatisticsModel> statisticsData = new List<StatisticsModel>();
            statisticsData = receiverMethod.GetStatisticsData();
            receiverMethod.PrintBMSCalculation(statisticsData);
        }
    }
}
