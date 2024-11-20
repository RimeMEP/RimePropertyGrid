using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimeControls.NumericUpDownControl.Implementation
{
    [CLSCompliantAttribute(false)]
    public class SByteUpDown : CommonNumericUpDown<sbyte>
    {
        #region Constructors

        static SByteUpDown()
        {
            UpdateMetadata(typeof(SByteUpDown), (sbyte)1, sbyte.MinValue, sbyte.MaxValue);
        }

        public SByteUpDown()
          : base(sbyte.TryParse, Decimal.ToSByte, (v1, v2) => v1 < v2, (v1, v2) => v1 > v2)
        {
        }

        #endregion //Constructors

        #region Base Class Overrides

        protected override sbyte IncrementValue(sbyte value, sbyte increment)
        {
            return (sbyte)(value + increment);
        }

        protected override sbyte DecrementValue(sbyte value, sbyte increment)
        {
            return (sbyte)(value - increment);
        }

        #endregion //Base Class Overrides
    }
}
