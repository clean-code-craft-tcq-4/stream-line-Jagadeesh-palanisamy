using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Receiver
{
    public class ReceiverMethods
    {
        public List<StatisticsModel> GetStatisticsData()
        {
            string line;
            List<string> inputData = new List<string>();
            while ((line = Console.ReadLine()) != null)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    inputData.Add(line);
                }
            }
            return GetInputfromSender(inputData);
        }
        public List<StatisticsModel> GetInputfromSender(List<string> inputData)
        {
            List<ReceiverDataModel> receiverDataList = new List<ReceiverDataModel>();
            int lineCount = 1;
            foreach (string data in inputData)
            {
                if (!string.IsNullOrEmpty(data))
                {
                    string[] sensorValueList = data.Trim().Split(new char[] { ',', '[', ']' });
                    ReceiverDataModel receiverData = new ReceiverDataModel();

                    foreach (string sensorValue in sensorValueList)
                    {
                        if (!string.IsNullOrEmpty(sensorValue))
                            receiverData.SensorData.Add((float)Convert.ToDouble(sensorValue));
                    }
                    if (lineCount == 1)
                        receiverData.Sensor = "Temperature";
                    else
                        receiverData.Sensor = "SOC";

                    receiverDataList.Add(receiverData);
                    lineCount = lineCount + 1;
                }
            }
                
            return CalculateStatistics(receiverDataList);
        }

        public List<StatisticsModel> CalculateStatistics(List<ReceiverDataModel> receiverDataList)
        {
            List<StatisticsModel> sensorStatisticsData = new List<StatisticsModel>();

            foreach(ReceiverDataModel receiverData in receiverDataList)
            {
                StatisticsModel statisticsData = new StatisticsModel();
                string MovingAverage = string.Empty;
                float tempSMA;
                statisticsData.Sensor = receiverData.Sensor;
                statisticsData.Min = receiverData.SensorData.Min();
                statisticsData.Max = receiverData.SensorData.Max();

                for (int i = 0; i < (receiverData.SensorData.Count/5); i++)
                {
                    tempSMA = 0;
                    for(int j = 0; j < 10; j++)
                    {
                        tempSMA = tempSMA + receiverData.SensorData[i * j];
                    }
                    if(i == (receiverData.SensorData.Count / 5) - 1)
                        MovingAverage = MovingAverage + tempSMA/10;
                    else
                        MovingAverage = MovingAverage + tempSMA / 10 + ", ";
                }
                statisticsData.SMA = MovingAverage;

                sensorStatisticsData.Add(statisticsData);
            }

            return sensorStatisticsData;            
        }

        public void PrintBMSCalculation(List<StatisticsModel> sensorStatisticsData)
        {
            foreach(StatisticsModel sensorStatistics in sensorStatisticsData)
            {
                Console.WriteLine(sensorStatistics.Sensor);
                Console.WriteLine("Minimum: " + sensorStatistics.Min);
                Console.WriteLine("Maximum: " + sensorStatistics.Max);
                Console.WriteLine("Simple Moving Average: " + sensorStatistics.SMA);
            }
        }
    }
}
