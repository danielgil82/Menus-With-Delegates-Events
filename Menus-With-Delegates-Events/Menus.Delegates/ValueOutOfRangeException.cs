using System;
using System.Collections.Generic;
using System.Text;

namespace Menus.Delegates
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float i_maxValue;
        private readonly float i_minValue;

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
            : base(string.Format("Oops , out of range {0} - {1} ", i_MinValue, i_MaxValue))
        {
            i_maxValue = i_MaxValue;
            i_minValue = i_MinValue;
        }
    }
}