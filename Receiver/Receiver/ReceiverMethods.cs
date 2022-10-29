using System;
using System.Collections.Generic;
using System.Linq;

namespace Receiver
{
    public class ReceiverMethods
    {
        public List<StatisticsModel> GetStatisticsData()
        {
            try
            {
                string line = string.Empty; ;
                Console.WriteLine("InputData");
                List<string> inputData = new List<string>();
                while ((line = Console.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        inputData.Add(line);
                        Console.WriteLine(line);
                    }
                }
                Console.WriteLine("InputData Count: " + inputData.Count);
                if (inputData != null)
                {
                    List<StatisticsModel> statsData = GetInputfromSender(inputData);
                    return statsData;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Getting Sender Data. " + ex.Message);
                return null;
            }
            
        }
        public List<StatisticsModel> GetInputfromSender(List<string> inputData)
        {
            try
            {
                if (inputData != null)
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
                    List<StatisticsModel> statsData = CalculateStatistics(receiverDataList);
                    return statsData;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Processing sender data. " + ex.Message);
                return null;
            }
                 
        }

        public List<StatisticsModel> CalculateStatistics(List<ReceiverDataModel> receiverDataList)
        {
            try
            {
                if (receiverDataList != null)
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
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error in Calculating Statistics. " + ex.Message);
                return null;
            }          
        }

        public void PrintBMSCalculation(List<StatisticsModel> sensorStatisticsData)
        {
            try
            {
                foreach (StatisticsModel sensorStatistics in sensorStatisticsData)
                {
                    Console.WriteLine(sensorStatistics.Sensor);
                    Console.WriteLine("Minimum: " + sensorStatistics.Min);
                    Console.WriteLine("Maximum: " + sensorStatistics.Max);
                    Console.WriteLine("Simple Moving Average: " + sensorStatistics.SMA);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error in Printing Statistics. " + ex.Message);
            }
        }
    }
}
