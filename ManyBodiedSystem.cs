using System;
using System.Collections.Generic;
using System.Text;

namespace orbit_simulator
{
    class ManyBodiedSystem
    {
        public CelestialBody[] Bodies;

        public ManyBodiedSystem(CelestialBody[] bodies)
        {
            Bodies = (CelestialBody[])bodies.Clone();
        }

        public List<Dictionary<string, Vector>> CalculateSpeeds(int cicles, bool verbose = false)
        {
            List<Dictionary<string, Vector>> speeds = new List<Dictionary<string, Vector>>();

            for (int i = 0; i < cicles; i++)
            {
                if (verbose)
                {
                    Console.WriteLine($"----- Start of cicle {i} -----\n");
                }

                for (int k = 0; k < Bodies.Length; k++)
                {
                    CelestialBody cb = Bodies[k];
                    for (int j = 0; j < Bodies.Length; j++)
                    {
                        CelestialBody influence = Bodies[j];

                        if (verbose)
                        {
                            Console.WriteLine($"cb({k}): {cb.Name}\ninfluence({j}): {influence.Name}\n");
                        }

                        if (k != j)
                        {
                            // Console.WriteLine($"cb({i}): {cb.Name}\ninfluence({j}): {influence.Name}");
                            cb.UpdateResultingForce(influence);
                        }
                        else if (verbose)
                        {
                            Console.WriteLine($"Same body - skipped this cicle");
                        }
                    }
                    cb.UpdateAcceleration();
                    cb.UpdateSpeed();
                }

                 speeds.Add(new Dictionary<string, Vector>());

                foreach (var cb in Bodies)
                {
                    cb.UpdatePosition();
                    speeds[i].Add(cb.Name, new Vector(cb.Speed.Coordinates));
                }

                if (verbose)
                {
                    Console.WriteLine($"----- End of cicle {i} -----\n");
                }

            }

            return speeds;
        }
    }
}
