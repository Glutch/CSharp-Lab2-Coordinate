using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinate
{
    class Position
    {
        private double x;
        private double y;

        public double X
        {
            get => this.x;
            set => this.x = Math.Max(value, 0);
        }

        public double Y
        {
            get => this.y;
            set => this.y = Math.Max(value, 0);
        }

        public Position(double inputX, double inputY)
        {
            X = inputX;
            Y = inputY;
        }

        public double Length() =>
            Math.Sqrt(Math.Pow(this.X, 2) + Math.Pow(this.Y, 2));

        public bool Equals(Position pos) => 
            this.X.Equals(pos.X) && this.Y.Equals(pos.Y);

        public Position Clone() => new Position(this.X, this.Y);

        public override string ToString() => 
            "(" + this.X.ToString() + ", " + this.Y.ToString() + ")";

        public static bool operator > (Position a, Position b) => 
            !a.Length().Equals(b.Length())
                ? a.Length() > b.Length()
                : a.X >= b.X;

        public static bool operator < (Position a, Position b) => 
            !a.Length().Equals(b.Length())
                ? a.Length() < b.Length()
                : a.X <= b.X;

        public static Position operator + (Position a, Position b) =>
            new Position(a.X + b.X, a.Y + b.Y);

        public static Position operator - (Position a, Position b) =>
            new Position(Math.Abs(a.X - b.X), Math.Abs(a.Y - b.Y));

        public static double operator % (Position a, Position b) =>
            Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
    }
}
