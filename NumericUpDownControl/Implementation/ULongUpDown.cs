using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimeControls.NumericUpDownControl.Implementation
{
    [CLSCompliantAttribute(false)]
    public class ULongUpDown : CommonNumericUpDown<ulong>
    {
        #region Constructors

        static ULongUpDown()
        {
            UpdateMetadata(typeof(ULongUpDown), (ulong)1, ulong.MinValue, ulong.MaxValue);
        }

        public ULongUpDown()
          : base(ulong.TryParse, Decimal.ToUInt64, (v1, v2) => v1 < v2, (v1, v2) => v1 > v2)
        {
        }

        #endregion //Constructors

        #region Base Class Overrides

        protected override ulong IncrementValue(ulong value, ulong increment)
        {
            return (ulong)(value + increment);
        }

        protected override ulong DecrementValue(ulong value, ulong increment)
        {
            return (ulong)(value - increment);
        }

        #endregion //Base Class Overrides
    }
}
