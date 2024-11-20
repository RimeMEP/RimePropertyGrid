using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimeControls.Core.Input
{
    public interface IValidateInput
    {
        event InputValidationErrorEventHandler InputValidationError;
        bool CommitInput();
    }
}
