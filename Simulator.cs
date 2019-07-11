using System;

namespace orbit_simulator
{
    class Simulator
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("One more lap around the sun.");
            // Console.WriteLine($"{new Vector(new double[3] {1, 0, 1})}");
            // Console.WriteLine($"{new Vector(new double[3] {2, 0, 1}).DotProduct(new Vector(new double[3] {3, 0, 1}))}");
            Console.WriteLine($"{new Vector(new double[3] {3, 4, 0}).GetVersor()}");
            Console.WriteLine($"{new Vector(new double[3] {2, 2, 0}).MultiplyByScalar(2).MultiplyByScalar(2)}");
            Console.WriteLine($"{new Vector(new double[3] {2, 5, 0}).AddVector(new Vector(new double[3] {8, 5, 10})).GetVersor()}");
        }
    }
}
