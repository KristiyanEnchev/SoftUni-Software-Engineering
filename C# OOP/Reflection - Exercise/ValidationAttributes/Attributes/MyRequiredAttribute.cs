using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyVallidationAttributes
    {
        public override bool IsValid(object obj)
        {
            string str = (string)obj;

            return !string.IsNullOrEmpty(str);
        }
    }
}
