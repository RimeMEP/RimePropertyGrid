using RimeControls.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RimeControls.CollectionControl.Implementation
{
    public class ItemDeletingEventArgs : CancelRoutedEventArgs
    {
        #region Private Members

        private object _item;

        #endregion

        #region Constructor

        public ItemDeletingEventArgs(RoutedEvent itemDeletingEvent, object itemDeleting)
          : base(itemDeletingEvent)
        {
            _item = itemDeleting;
        }

        #region Property Item

        public object Item
        {
            get
            {
                return _item;
            }
        }

        #endregion

        #endregion
    }
}
