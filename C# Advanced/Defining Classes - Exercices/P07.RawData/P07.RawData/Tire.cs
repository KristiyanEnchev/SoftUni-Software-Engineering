using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Tire
    {
        private int year;

        private double pressure;

        public Tire(double pressure, int year)
        {
            Year = year;
            Pressure = pressure;
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public double Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }
    }
}