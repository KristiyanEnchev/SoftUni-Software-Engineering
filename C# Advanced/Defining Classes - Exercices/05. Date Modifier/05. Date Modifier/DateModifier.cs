using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        public static int GetDiffBetweenDateInDays(string dateOneStr, string dateTwoStr)
        {
            DateTime dataOne = DateTime.Parse(dateOneStr);
            DateTime dataTwo = DateTime.Parse(dateTwoStr);

            TimeSpan diff = dataOne - dataTwo;

            return Math.Abs( diff.Days);
        }
    }
}
