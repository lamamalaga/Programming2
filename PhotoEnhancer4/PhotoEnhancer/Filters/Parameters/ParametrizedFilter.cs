using System;

namespace PhotoEnhancer
{
    public abstract class ParametrizedFilter<TParameters> : IFilter
        where TParameters : IParameters, new()
    {
        IParametersFactory<TParameters> factory = new ParametersFactory<TParameters>();

        public ParameterInfo[] GetParametersInfo()
        {
            return factory.GetDescription();
        }

        public Photo Process(Photo original, double[] values)
        {
            var parameters = factory.CreateParameters(values);
            return Process(original, parameters);
        }

        public abstract Photo Process(Photo original, TParameters parameters);
    }
}
