﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RimeControls.CollectionControl.Implementation
{
    public class ItemEventArgs : RoutedEventArgs
    {
        #region Protected Members

        private object _item;

        #endregion

        #region Constructor

        internal ItemEventArgs(RoutedEvent routedEvent, object newItem)
          : base(routedEvent)
        {
            _item = newItem;
        }

        #endregion

        #region Property Item

        public object Item
        {
            get
            {
                return _item;
            }
        }

        #endregion
    }
}
