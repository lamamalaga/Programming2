using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using PhotoEnhancer;

namespace Profiler
{
    class Program
    {
        static void Main()
        {
            var factory = new ParametersFactory<LighteningParameters>();

            Test(v => factory.CreateParameters(v), 100000, "Новое");
            Test(v => new LighteningParameters { Coefficient = v[0] }, 100000, "Старое");

            Console.ReadKey();
        }

        static void Test(Func<double[], LighteningParameters> method, int n, string description)
        {
            var values = new double[] { 1 };
            var parameters = new LighteningParameters();

            method(values);

            var watch = new Stopwatch();
            watch.Start();

            for (var i = 0; i < n; i++)
                method(values);

            watch.Stop();

            var elapsed = 1000 * (double)watch.ElapsedMilliseconds / n;

            Console.WriteLine($"{description}: {elapsed:F2} ns");

        }
    }
}
