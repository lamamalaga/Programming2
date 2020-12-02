using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    class SepiaParameters : IParameters
    {
        public double SepiaParameterHueByUser { get; set; }
        public double SepiaParameterSaturationByUser { get; set; }

        public ParameterInfo[] GetDescription()
        {
            return new[]
            {
                new ParameterInfo() {
                    Name = "Оттенок",
                    MinValue = 0,
                    MaxValue = 359.95,
                    DefailtValue = 40,
                    Increment = 0.05
                },

                new ParameterInfo()
                {
                    Name = "Насыщенность",
                    MinValue = 0,
                    MaxValue = 1,
                    DefailtValue = 0.2,
                    Increment = 0.01
                }
            };
        }

        public void SetValues(double[] values)
        {
            SepiaParameterHueByUser = values[0];
            SepiaParameterSaturationByUser = values[1];
        }
    }
}
