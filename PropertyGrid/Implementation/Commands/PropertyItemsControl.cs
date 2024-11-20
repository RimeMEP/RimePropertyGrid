using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RimeControls.PropertyGrid.Implementation.Commands
{
    public static class PropertyItemCommands
    {
        private static RoutedCommand _resetValueCommand = new RoutedCommand();
        public static RoutedCommand ResetValue
        {
            get
            {
                return _resetValueCommand;
            }
        }
    }
}
