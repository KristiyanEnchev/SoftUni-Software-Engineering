using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public abstract class Phone : ICalable
    {
        public abstract string Call(string number); 
    }
}
