using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICalable
    {
        public string Call(string number)
        {
            Validator.ThrowIfURLInTheNumberLine(number, "Invalid number!");

            return $"Dialing... {number}";
        }
    }
}
