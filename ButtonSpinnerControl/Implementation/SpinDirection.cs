using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimeControls.ButtonSpinnerControl.Implementation
{
    /// <summary>
    /// Represents spin directions that could be initiated by the end-user.
    /// </summary>
    /// <QualityBand>Preview</QualityBand>
    public enum SpinDirection
    {
        /// <summary>
        /// Represents a spin initiated by the end-user in order to Increase a value.
        /// </summary>
        Increase = 0,

        /// <summary>
        /// Represents a spin initiated by the end-user in order to Decrease a value.
        /// </summary>
        Decrease = 1
    }
}
