using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    interface IRobot : IIndentifiable
    {
        string Model { get; }
    }
}
