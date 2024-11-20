using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimeControls.NumericUpDownControl.Implementation
{
    [Flags]
    public enum AllowedSpecialValues
    {
        None = 0,
        NaN = 1,
        PositiveInfinity = 2,
        NegativeInfinity = 4,
        AnyInfinity = PositiveInfinity | NegativeInfinity,
        Any = NaN | AnyInfinity
    }
}
