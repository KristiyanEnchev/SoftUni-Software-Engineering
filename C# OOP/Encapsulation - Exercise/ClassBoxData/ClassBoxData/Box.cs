using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                this.ThrowIfInvalidSide(value, nameof(Length));

                length = value;
            }
        }


        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                this.ThrowIfInvalidSide(value, nameof(Width));

                width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                this.ThrowIfInvalidSide(value, nameof(Height));

                height = value;
            }
        }

        public double LiteralSurfaceArea()
        {
            double literalValue = 2 * this.Length * this.Height + 2 * this.Width * this.Height;
            return literalValue;
        }
        public double SurfaceArea()
        {
            double surfaceArea = 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height;
            return surfaceArea;
        }
        public double Volume()
        {
            double volume = Length * Width * Height;
            return volume;
        }


        private void ThrowIfInvalidSide(double value, string side)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{side} cannot be zero or negative.");
            }
        }

    }
}
