using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimeControls.DateTimeUpDownControl.Implementation
{
    internal class DateTimeInfo
    {
        public string Content
        {
            get;
            set;
        }
        public string Format
        {
            get;
            set;
        }
        public bool IsReadOnly
        {
            get;
            set;
        }
        public int Length
        {
            get;
            set;
        }
        public int StartPosition
        {
            get;
            set;
        }
        public DateTimePart Type
        {
            get;
            set;
        }
    }
}
