using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wheater.Shared.Model.Chart
{
    public class ChartTemperatureData
    {
        public string Time { get; set; } = string.Empty;
        public double Temps { get; set; }
    }
}
