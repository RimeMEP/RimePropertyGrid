using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RimeControls.NumericUpDownControl.Implementation
{
    public class ByteUpDown : CommonNumericUpDown<byte>
    {
        #region Constructors

        static ByteUpDown()
        {
            UpdateMetadata(typeof(ByteUpDown), (byte)1, byte.MinValue, byte.MaxValue);
            MaxLengthProperty.OverrideMetadata(typeof(ByteUpDown), new FrameworkPropertyMetadata(3));
        }

        public ByteUpDown()
          : base(Byte.TryParse, Decimal.ToByte, (v1, v2) => v1 < v2, (v1, v2) => v1 > v2)
        {
        }

        #endregion //Constructors

        #region Base Class Overrides

        protected override byte IncrementValue(byte value, byte increment)
        {
            return (byte)(value + increment);
        }

        protected override byte DecrementValue(byte value, byte increment)
        {
            return (byte)(value - increment);
        }

        #endregion //Base Class Overrides
    }
}
