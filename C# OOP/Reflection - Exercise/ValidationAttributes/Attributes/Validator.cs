using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (var prop in properties)
            {
                MyVallidationAttributes[] attributes = prop.GetCustomAttributes().Cast<MyVallidationAttributes>().ToArray();

                var value = prop.GetValue(obj);

                foreach (var att in attributes)
                {
                    bool isValid = att.IsValid(value);

                    if (!isValid)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
