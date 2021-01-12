using System;

namespace PhotoEnhancer
{
    public class RotationParameters : IParameters
    {
        [ParameterInfo(Name = "Угол поворота в °", MinValue = -360, MaxValue = 360, DefailtValue = 0, Increment = 5)]
        public double AngleInDegrees { get; set; }
    }
}
