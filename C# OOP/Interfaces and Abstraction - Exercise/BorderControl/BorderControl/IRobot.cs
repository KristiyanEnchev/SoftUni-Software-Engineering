using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    interface IRobot : IIndentifiable
    {
        string Model { get; }
    }
}
