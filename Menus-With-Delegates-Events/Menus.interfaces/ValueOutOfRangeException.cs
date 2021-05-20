using System;
using System.Collections.Generic;
using System.Text;

namespace Menus.interfaces
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        public ValueOutOfRangeException(float i_rMaxValue, float i_rMinValue)
            : base(string.Format("Oops , out of range {0} - {1} ", i_rMinValue, i_rMaxValue))
        {
            r_MaxValue = i_rMaxValue;
            r_MinValue = i_rMinValue;
        }
    }
}