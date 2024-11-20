using RimeControls.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RimeControls.CollectionControl.Implementation
{
    public class ItemAddingEventArgs : CancelRoutedEventArgs
    {
        #region Constructor

        public ItemAddingEventArgs(RoutedEvent itemAddingEvent, object itemAdding)
          : base(itemAddingEvent)
        {
            Item = itemAdding;
        }

        #endregion

        #region Properties

        #region Item Property

        public object Item
        {
            get;
            set;
        }

        #endregion

        #endregion //Properties
    }
}
