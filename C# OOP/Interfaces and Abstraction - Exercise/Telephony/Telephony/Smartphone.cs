using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Telephony
{
    public class Smartphone : Phone, IBrowseble
    {
        public string Browse(string website)
        {
            Validator.ThrowIfNumberInTheURLLine(website, "Invalid URL!");

            return $"Browsing: {website}!";
        }

        public override string Call(string number)
        {
            Validator.ThrowIfURLInTheNumberLine(number, "Invalid number!");

            return $"Calling... {number}";
        }
    }
}
