using System;
using System.Collections.Generic;
using System.Linq;

namespace Receiver
{
    public class ReceiverMethods
    {
        public List<StatisticsModel> GetStatisticsData()
        {           
            string line = string.Empty;
            List<string> inputData = new List<string>();
            string inputLine = string.Empty;
            while ((line = Console.ReadLine()) != null)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    if(line.Contains('[') || line.Contains(']'))
                    {
                        inputData.Add(inputLine);
                        inputLine = string.Empty;
                    }
                    else
                    {
                        inputLine = inputLine + line;
                    }
                }
            }
            inputData = inputData.Where(t => !string.IsNullOrWhiteSpace(t)).Distinct().ToList();
            return GetInputfromSender(inputData);
            
        }
        public List<StatisticsModel> GetInputfromSender(List<string> inputData)
        {
            
            List<ReceiverDataModel> receiverDataList = new List<ReceiverDataModel>();

            int lineCount = 1;
            foreach (string data in inputData)
            {
                List<float> sensorData = new List<float>();
                var receiverData = new ReceiverDataModel();
                if (!string.IsNullOrEmpty(data))
                {
                    string[] sensorValueList = data.Trim().Split(new char[] { ',', '[', ']' });

                    foreach (string sensorValue in sensorValueList)
                    {
                        if (!string.IsNullOrEmpty(sensorValue))
                            sensorData.Add((float)Convert.ToDouble(sensorValue));
                    }
                    if (lineCount == 1)
                        receiverData.Sensor = "Temperature";
                    else
                        receiverData.Sensor = "SOC";

                    receiverData.SensorData = sensorData;

                    receiverDataList.Add(receiverData);
                    lineCount = lineCount + 1;
                }
            }
            return CalculateStatistics(receiverDataList);                 
        }

        public List<StatisticsModel> CalculateStatistics(List<ReceiverDataModel> receiverDataList)
        {
                        
            List<StatisticsModel> sensorStatisticsData = new List<StatisticsModel>();

            foreach (ReceiverDataModel receiverData in receiverDataList)
            {
                StatisticsModel statisticsData = new StatisticsModel();
                string MovingAverage = string.Empty;
                float tempSMA;
                statisticsData.Sensor = receiverData.Sensor;
                statisticsData.Min = receiverData.SensorData.Min();
                statisticsData.Max = receiverData.SensorData.Max();

                for (int i = 0; i < (receiverData.SensorData.Count / 5); i++)
                {
                    tempSMA = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        tempSMA = tempSMA + receiverData.SensorData[(i * 5) + j];
                    }
                    if (i == (receiverData.SensorData.Count / 5) - 1)
                        MovingAverage = MovingAverage + tempSMA / 5;
                    else
                        MovingAverage = MovingAverage + tempSMA / 5 + ", ";
                }
                statisticsData.SMA = MovingAverage;

                sensorStatisticsData.Add(statisticsData);
            }
            return sensorStatisticsData;     
        }

        public void PrintBMSCalculation(List<StatisticsModel> sensorStatisticsData)
        {            
            foreach (StatisticsModel sensorStatistics in sensorStatisticsData)
            {
                Console.WriteLine(sensorStatistics.Sensor + " Statistics");
                Console.WriteLine(sensorStatistics.Sensor + " Minimum: " + sensorStatistics.Min);
                Console.WriteLine(sensorStatistics.Sensor + " Maximum: " + sensorStatistics.Max);
                Console.WriteLine(sensorStatistics.Sensor + " Simple Moving Average (With 5 Input Values): " + sensorStatistics.SMA);
            }
        }
    }
}
