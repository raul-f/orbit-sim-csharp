using System;
using System.Collections.Generic;

namespace orbit_simulator
{
    class Simulator
    {
        static void Main(string[] args)
        {
            CelestialBody sun = new CelestialBody(
                1.989e30,
                new Vector(new double[3] { 0, 0, 0 }),
                new Vector(new double[3] { 0, 0, 0 }),
                "Sun"
            );
            CelestialBody earth = new CelestialBody(
                5.972e24,
                new Vector(new double[3] { 3.844e8, 0, 0 }),
                new Vector(new double[3] { 0, 3e6, 10 }),
                "Earth"
            );

            ManyBodiedSystem mbs = new ManyBodiedSystem(new CelestialBody[] {sun, earth});

            List<Dictionary<string, Vector>> speeds = mbs.CalculateSpeeds((int)4e4);

            Console.WriteLine($"Initial Position: {{earth: {earth.InitPosition}, sun: {sun.InitPosition}}}");
            Console.WriteLine($"Current Position: {{earth: {earth.Position}, sun: {sun.Position}}}");

            Console.ReadLine();
        }
    }
}
