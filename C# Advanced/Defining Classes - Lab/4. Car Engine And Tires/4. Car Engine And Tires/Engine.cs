using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Engine
    {

        public Engine(int horsePower, int cubeCapacity)
        {
            HorsePower = horsePower;
            CubicCapacity = cubeCapacity;
        }
        public int HorsePower { get; set; }
        public double CubicCapacity { get; set; }
    }
}
