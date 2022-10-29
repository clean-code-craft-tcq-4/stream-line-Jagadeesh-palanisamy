using System;
using System.Collections.Generic;

namespace Receiver
{
    public class Program
    {
        static void Main(string[] args)
        {
            ReceiverMethods receiverMethod = new ReceiverMethods();
            List<StatisticsModel> statisticsData = receiverMethod.GetStatisticsData();
            receiverMethod.PrintBMSCalculation(statisticsData);
        }
    }
}
