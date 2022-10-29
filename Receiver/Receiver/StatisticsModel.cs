using System;
using System.Collections.Generic;
using System.Text;

namespace Receiver
{
    public class StatisticsModel
    {
        public string Sensor { get; set; }
        public float Min { get; set; }
        public float Max { get; set; }
        public string SMA { get; set; }
    }
}
