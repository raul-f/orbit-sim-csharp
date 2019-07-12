using System;

namespace orbit_simulator
{
    class Vector
    {
        public double[] Coordinates { get; set; }

        public Vector(double[] coordinates)
        {
            Coordinates = (double[])coordinates.Clone();
        }

        public double GetNorm() {
            double sum = 0;

            foreach (double coord in Coordinates) {
                sum += coord * coord;
            }

            return Math.Sqrt(sum);
        }

        public Vector GetVersor() {
            double[] unitVector = (double[])Coordinates.Clone();
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

        public Vector MultiplyScalar(double scalar) {
            double[] coords = (double[])Coordinates.Clone();
            for (int index = 0; index < coords.Length; index++)
            {
                coords[index] *= scalar;
            }

            return new Vector(coords);
        }

        public Vector AddVector(Vector addend) {
            double[] coords = (double[])Coordinates.Clone();
            for (int index = 0; index < coords.Length; index++) 
            {
                coords[index] += addend.Coordinates[index];
            }

            return new Vector(coords);
        }

        public override string ToString() => $"({string.Join(", ", Coordinates)})";
    }
}