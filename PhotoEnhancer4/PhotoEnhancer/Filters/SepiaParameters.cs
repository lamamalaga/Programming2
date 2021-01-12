using System;

namespace PhotoEnhancer
{
    public class SepiaParameters : IParameters
    {
        [ParameterInfo(Name = "Оттенок", MinValue = 0, MaxValue = 359.95, DefailtValue = 40, Increment = 0.05)]
        public double HueByUser { get; set; }

        [ParameterInfo(Name = "Насыщенность", MinValue = 0, MaxValue = 1, DefailtValue = 0.2, Increment = 0.01)]
        public double SaturationByUser { get; set; }
    }
}
