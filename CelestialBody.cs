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
        public Vector UpdateResultingForce(CelestialBody other)
        {
            Vector _this = Position, _other = other.Position;
            Vector relPos = _this.AddVector(_other.MultiplyScalar(-1));
            double distSq = Math.Pow(relPos.GetNorm(), 2);
            double norm = (other.Mass * Gravitational * Mass) / distSq;
            Vector direction = relPos.GetVersor().MultiplyScalar(-1);
            Vector force = direction.MultiplyScalar(norm);

            Console.WriteLine($"--- Start of {Name} ---");
            Console.WriteLine($"Influence: {other.Name}");
            Console.WriteLine($"{Name} relPos: {relPos}");
            Console.WriteLine($"{Name} distSq: {distSq}");
            Console.WriteLine($"{Name} norm: {norm}");
            Console.WriteLine($"{Name} direction: {direction}");
            Console.WriteLine($"{Name} force: {force}");
            Console.WriteLine($"--- End of {Name} ---\n");

            ResultingForce = ResultingForce.AddVector(force);

            return ResultingForce;
        }

        public Vector UpdateAcceleration()
        {
            Acceleration = ResultingForce.MultiplyScalar(1 / Mass);

            // Console.WriteLine($"{this.Name} acc: {Acceleration}");
            // Console.WriteLine($"{this.Name} relPos: {relPos}");

            return Acceleration;
        }

        public Vector UpdateSpeed()
        {
            Speed = Speed.AddVector(Acceleration);
            return Speed;
        }

        public Vector UpdatePosition()
        {
            Position = Position.AddVector(Speed);

            // Console.WriteLine($"{this.Name} pos: {Position}");

            return Position;
        }
    }
}