using System;

namespace orbit_simulator
{
    class CelestialBody
    {

        public double Mass { get; }
        public string Name { get; set; }
        public Vector InitPosition { get; }
        public Vector Position { get; set; }
        public Vector InitSpeed { get; }
        public Vector Speed { get; set; }
        public Vector Acceleration { get; set; }
        public Vector ResultingForce { get; set; }
        private const double grav = 6.67408E-11;
        public double Gravitational
        {
            get
            {
                return grav;
            }
        }

        public CelestialBody(double mass, Vector initPosition, Vector initSpeed, string name)
        {
            Mass = mass;
            InitPosition = new Vector(initPosition.Coordinates);
            Position = new Vector(initPosition.Coordinates);
            Speed = new Vector(initSpeed.Coordinates);
            InitSpeed = new Vector(initSpeed.Coordinates);
            ResultingForce = new Vector(new double[3] { 0, 0, 0 });
            Name = name;
        }
        public Vector UpdateResultingForce(CelestialBody other, bool verbose = false)
        {
            Vector _this = Position, _other = other.Position;
            Vector relPos = _this.AddVector(_other.MultiplyScalar(-1));
            double distSq = Math.Pow(relPos.GetNorm(), 2);
            double norm = (other.Mass * Gravitational * Mass) / distSq;
            Vector direction = relPos.GetVersor().MultiplyScalar(-1);
            Vector force = direction.MultiplyScalar(norm);

            if (verbose)
            {
                Console.WriteLine($"--- Start of {Name}, UpdateResultingForce ---");
                Console.WriteLine($"Influence: {other.Name}");
                Console.WriteLine($"{Name} relPos: {relPos}");
                Console.WriteLine($"{Name} distSq: {distSq}");
                Console.WriteLine($"{Name} norm: {norm}");
                Console.WriteLine($"{Name} direction: {direction}");
                Console.WriteLine($"{Name} force: {force}");
                Console.WriteLine($"--- End of {Name} ---\n");
            }

            ResultingForce = ResultingForce.AddVector(force);

            return ResultingForce;
        }

        public Vector UpdateAcceleration(bool verbose = false)
        {
            Acceleration = ResultingForce.MultiplyScalar(1 / Mass);

            if (verbose)
            {
                Console.WriteLine($"--- Start of {Name}, UpdateAcceleration ---");
                Console.WriteLine($"{Name} acceleration: {Acceleration}");
                Console.WriteLine($"--- End of {Name} ---\n");
            }

            return Acceleration;
        }

        public Vector UpdateSpeed(bool verbose = false)
        {
            Speed = Speed.AddVector(Acceleration);

            if (verbose)
            {
                Console.WriteLine($"--- Start of {Name}, UpdateSpeed ---");
                Console.WriteLine($"{Name} speed: {Speed}");
                Console.WriteLine($"--- End of {Name} ---\n");
            }

            return Speed;
        }

        public Vector UpdatePosition(bool verbose = false)
        {
            Position = Position.AddVector(Speed);

            if (verbose)
            {
                Console.WriteLine($"--- Start of {Name}, UpdatePosition ---");
                Console.WriteLine($"{Name} position: {Position}");
                Console.WriteLine($"--- End of {Name} ---\n");
            }

            return Position;
        }
    }
}