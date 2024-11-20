using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace RimeControls.PropertyGrid.Implementation
{
    public class PropertyGridContextMenu : ContextMenu
    {
        protected override void OnOpened(RoutedEventArgs e)
        {
            base.OnOpened(e);

            var contextMenu = e.OriginalSource as ContextMenu;
            if ((contextMenu != null) && (contextMenu.PlacementTarget != null))
            {
                var control = contextMenu.PlacementTarget;

                // Get PropertyItemBase parent
                var parent = VisualTreeHelper.GetParent(control);
                while (parent != null)
                {
                    var propertyItemBase = parent as PropertyItemBase;
                    if (propertyItemBase != null)
                    {
                        contextMenu.DataContext = propertyItemBase;
                        break;
                    }
                    parent = VisualTreeHelper.GetParent(parent);
                }
            }
        }
    }
}
