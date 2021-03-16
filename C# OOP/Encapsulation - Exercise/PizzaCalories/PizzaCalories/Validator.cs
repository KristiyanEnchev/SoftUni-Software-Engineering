using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public static class Validator
    {

        public static void ThrowIfNumberIsNotInRange(int min, int max, int number, string exeptionMassage)
        {
            if (number < min || number > max)
            {
                throw new ArgumentException(exeptionMassage);
            }
        }
    }
}
