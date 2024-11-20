﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimeControls.NumericUpDownControl.Implementation
{
    [CLSCompliantAttribute(false)]
    public class UShortUpDown : CommonNumericUpDown<ushort>
    {
        #region Constructors

        static UShortUpDown()
        {
            UpdateMetadata(typeof(UShortUpDown), (ushort)1, ushort.MinValue, ushort.MaxValue);
        }

        public UShortUpDown()
          : base(ushort.TryParse, Decimal.ToUInt16, (v1, v2) => v1 < v2, (v1, v2) => v1 > v2)
        {
        }

        #endregion //Constructors

        #region Base Class Overrides

        protected override ushort IncrementValue(ushort value, ushort increment)
        {
            return (ushort)(value + increment);
        }

        protected override ushort DecrementValue(ushort value, ushort increment)
        {
            return (ushort)(value - increment);
        }

        #endregion //Base Class Overrides
    }
}
