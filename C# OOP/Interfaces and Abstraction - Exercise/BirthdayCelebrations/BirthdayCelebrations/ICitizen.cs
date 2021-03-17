using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public interface ICitizen : IIndentifiable, IBirthable
    {
        string Name { get; }

        int Age { get; }

    }
}
