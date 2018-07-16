using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;
using System;

namespace Quantum.cloning
{ 
    class Driver
    {
    private static readonly Random random = new Random();

    private static double RandomNumberBetween(double minValue, double maxValue)
    {
        var next = random.NextDouble();

        return minValue + (next * (maxValue - minValue));
    }
    static void Main(string[] args)
        {


        Random r = new Random();
        double pi = 2 * Math.PI;
        using (var sim = new QuantumSimulator())
            {
            Result[] initials = new Result[] { Result.Zero, Result.One };
                double a = RandomNumberBetween(0, 2 * pi);
                foreach (Result initial in initials)
                {
                    var res = cloning.Run(sim, 1000, a , initial).Result;
                    var(num00, num01, num30, num31) = res;
                System.Console.WriteLine(
                $"Init:{initial,-4} 0s on first control={num00,-4}   1s on first control={num01,-4}   0s on target={num30,-4} 1s on target={num31,-4},    {a}"); 
            }
            }
        System.Console.WriteLine("Press any key to continue...");
        System.Console.ReadKey();
    }
    }
}