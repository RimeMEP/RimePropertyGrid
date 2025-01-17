﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RimeControls.Core.Utilities
{
    internal class WeakEventListener<TArgs> : IWeakEventListener where TArgs : EventArgs
    {
        private Action<object, TArgs> _callback;

        public WeakEventListener(Action<object, TArgs> callback)
        {
            if (callback == null)
                throw new ArgumentNullException("callback");

            _callback = callback;
        }

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            _callback(sender, (TArgs)e);
            return true;
        }
    }
}
