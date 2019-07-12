using System;

namespace orbit_simulator
{
    class CelestialBody
    {

        public double Mass;
        public Vector InitPosition;
        public Vector Position;
        public Vector InitSpeed;
        public Vector Speed;
        public Vector Acceleration;
        private const double grav = 6.67408E-11;
        public double Gravitational
        {
            get
            {
                return grav;
            }
        }

        public CelestialBody(double mass, Vector initPosition, Vector initSpeed)
        {
            Mass = mass;
            Position = InitPosition = initPosition;
            Speed = InitSpeed = initSpeed;
        }

        public Vector UpdateAcceleration(CelestialBody other)
        {
            double distSq = Math.Pow(Position.AddVector(other.Position.MultiplyByScalar(-1)).GetNorm(), 2);
            double norm = (other.Mass * Gravitational * Mass) / distSq;
            Vector accs = other.Position.GetVersor().MultiplyByScalar(-1);

            return new Vector(new double[3] {0, 0, 0});
        }
    }
}