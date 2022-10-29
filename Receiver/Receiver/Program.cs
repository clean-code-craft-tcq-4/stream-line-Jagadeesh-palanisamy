using System;
using System.Collections.Generic;

namespace Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            ReceiverMethods receiverMethod = new ReceiverMethods();
            List<StatisticsModel> statisticsData = receiverMethod.GetStatisticsData();
            if (statisticsData != null)
                receiverMethod.PrintBMSCalculation(statisticsData);
            else
                Console.WriteLine("Error in Sending or Receiving data");
        }
    }
}
