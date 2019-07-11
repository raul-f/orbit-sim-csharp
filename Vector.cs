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
            for (int index = 0; index < Coordinates.Length; index++)
            {
                Coordinates[index] *= scalar;
            }

            return this;
        }

        public Vector AddVector(Vector addend) {
            for (int index = 0; index < Coordinates.Length; index++)
            {
                Coordinates[index] += addend.Coordinates[index];
            }

            return this;
        }

        public override string ToString() => $"({string.Join(", ", Coordinates)})";
    }
}