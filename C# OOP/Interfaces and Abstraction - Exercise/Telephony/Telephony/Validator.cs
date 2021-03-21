using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Telephony
{
    public static class Validator
    {
        public static void ThrowIfNumberInTheURLLine(string str, string masssage)
        {
            if (str.Any(x => char.IsDigit(x)))
            {
                throw new InvalidOperationException(masssage);
            }
        }
        public static void ThrowIfURLInTheNumberLine(string str, string masssage)
        {
            if (str.Any(x => !char.IsDigit(x)))
            {
                throw new InvalidOperationException(masssage);
            }
        }
    }
}
