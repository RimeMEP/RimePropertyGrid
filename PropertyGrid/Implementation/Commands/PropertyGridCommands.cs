using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RimeControls.PropertyGrid.Implementation.Commands
{
    public class PropertyGridCommands
    {
        private static RoutedCommand _clearFilterCommand = new RoutedCommand();
        public static RoutedCommand ClearFilter
        {
            get
            {
                return _clearFilterCommand;
            }
        }
    }
}
