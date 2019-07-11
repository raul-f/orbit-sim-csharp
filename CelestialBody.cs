using System;

namespace orbit_simulator
{
    class CelestialBody
    {

        public decimal Mass;
        public double[] InitPosition = new double[3];
        public double[] Position = new double[3];
        public double[] InitSpeed = new double[3];
        public double[] Speed = new double[3];
        public double[] Acceleration = new double[3];
        public const decimal Gravitational = 6.67408E-11M;

        public CelestialBody(decimal mass, double[] initPosition, double[] initSpeed)
        {
            Mass = mass;
            Position = InitPosition = initPosition;
            Speed = InitSpeed = initSpeed;
        }

        public double[] UpdateAcceleration(double[] position) {
            return new double[1] {0};
        }
    }
}