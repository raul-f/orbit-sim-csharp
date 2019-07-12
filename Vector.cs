using System;

namespace orbit_simulator
{
    class Vector
    {
        public double[] Coordinates { get; set; }

        public Vector(double[] coordinates)
        {
            Coordinates = coordinates;
        }

        public double GetNorm() {
            double sum = 0;

            foreach (double coord in Coordinates) {
                sum += coord * coord;
            }

            return Math.Sqrt(sum);
        }

        public Vector GetVersor() {
            double[] unitVector = Coordinates;
            double norm = GetNorm();

            for (int index = 0; index < unitVector.Length; index++) {
                unitVector[index] /= norm;
            }

            return new Vector(unitVector);
        }

        public double DotProduct(Vector operand)
        {
            double sum = 0;

            for (int index = 0; index < Coordinates.Length; index++)
            {
                sum += Coordinates[index] * operand.Coordinates[index];
            }

            return sum;
        }

        public Vector MultiplyByScalar(double scalar) {
            double[] coords = Coordinates;
            for (int index = 0; index < coords.Length; index++)
            {
                coords[index] *= scalar;
            }

            return new Vector(coords);
        }

        public Vector AddVector(Vector addend) {
            double[] coords = Coordinates;
            for (int index = 0; index < coords.Length; index++)
            {
                coords[index] += addend.Coordinates[index];
            }

            return new Vector(coords);
        }

        public override string ToString() => $"({string.Join(", ", Coordinates)})";
    }
}