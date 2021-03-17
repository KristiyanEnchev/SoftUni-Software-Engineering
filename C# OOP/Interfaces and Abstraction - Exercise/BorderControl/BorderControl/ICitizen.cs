using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface ICitizen : IIndentifiable
    {
        string Name { get; }

        int Age { get; }
    }
}
