using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface IRabel : ICitizen
    {
        string Group { get; }
    }
}
