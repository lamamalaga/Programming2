using System;

namespace PhotoEnhancer
{
    public class LighteningParameters : IParameters
    {
        [ParameterInfo(Name = "Коэффициент", MinValue = 0, MaxValue = 10, DefailtValue = 1, Increment = 0.05)]
        public double Coefficient { get; set; }
    }
}
