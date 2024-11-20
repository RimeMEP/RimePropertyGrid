using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows;

namespace RimeControls.Primitives
{
    public class SelectorItem : ContentControl
    {
        #region Members

        private bool m_raiseSelectionChangedEvent = true;

        #endregion

        #region Constructors

        static SelectorItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SelectorItem), new FrameworkPropertyMetadata(typeof(SelectorItem)));
        }

        #endregion //Constructors

        #region Properties

        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool?), typeof(SelectorItem), new UIPropertyMetadata(false, OnIsSelectedChanged));
        public bool? IsSelected
        {
            get
            {
                return (bool?)GetValue(IsSelectedProperty);
            }
            set
            {
                SetValue(IsSelectedProperty, value);
            }
        }

        private static void OnIsSelectedChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            SelectorItem selectorItem = o as SelectorItem;
            if (selectorItem != null)
                selectorItem.OnIsSelectedChanged((bool?)e.OldValue, (bool?)e.NewValue);
        }

        protected virtual void OnIsSelectedChanged(bool? oldValue, bool? newValue)
        {
            if (m_raiseSelectionChangedEvent && newValue.HasValue)
            {
                if (newValue.Value)
                {
                    this.RaiseEvent(new RoutedEventArgs(Selector.SelectedEvent, this));
                }
                else
                {
                    this.RaiseEvent(new RoutedEventArgs(Selector.UnSelectedEvent, this));
                }
            }
        }

        internal Selector ParentSelector
        {
            get
            {
                return ItemsControl.ItemsControlFromItemContainer(this) as Selector;
            }
        }

        #endregion //Properties

        #region Internal Methods

        internal void SetIsSelected(bool isSelected, bool raiseSelectionChangedEvent = true)
        {
            m_raiseSelectionChangedEvent = raiseSelectionChangedEvent;
            this.IsSelected = isSelected;
            m_raiseSelectionChangedEvent = true;
        }

        #endregion

        #region Events

        public static readonly RoutedEvent SelectedEvent = Selector.SelectedEvent.AddOwner(typeof(SelectorItem));
        public static readonly RoutedEvent UnselectedEvent = Selector.UnSelectedEvent.AddOwner(typeof(SelectorItem));

        #endregion
    }
}
