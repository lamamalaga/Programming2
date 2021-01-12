using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PhotoEnhancer
{
    public class ParametersFactory<TParameters> : IParametersFactory<TParameters>
        where TParameters : IParameters, new()
    {
        static ParameterInfo[] description;
        static PropertyInfo[] properties;

        static ParametersFactory()
        {
            description = typeof(TParameters)
                .GetProperties()
                .Select(p => p.GetCustomAttributes<ParameterInfo>())
                .Where(a => a.Count() > 0)
                .SelectMany(a => a)
                .Cast<ParameterInfo>()
                .ToArray();

            properties = typeof(TParameters)
                .GetProperties()
                .Where(p => p.GetCustomAttributes<ParameterInfo>().Count() > 0)
                .ToArray();
        }

        public ParameterInfo[] GetDescription()
        {
            return description;
        }

        public TParameters CreateParameters(double[] values)
        {
            var parameters = new TParameters();

            for (var i = 0; i < values.Length; i++)
                properties[i].SetValue(parameters, values[i]);

            return parameters;
        }
    }
}
