using System;

namespace PhotoEnhancer
{
    public class ReductionInSizeParameters : IParameters
    {
        [ParameterInfo(Name = "Коэффициент уменьшения", MinValue = 1, MaxValue = 10, DefailtValue = 1, Increment = 0.5)]
        public double ReductionInSizeParameter { get; set; }
    }
}
