﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimeControls.PropertyGrid.Implementation
{
    internal struct FilterInfo
    {
        public string InputString;
        public Predicate<object> Predicate;
    }
}
