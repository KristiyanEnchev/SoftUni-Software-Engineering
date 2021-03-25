using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public abstract class MyVallidationAttributes : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
