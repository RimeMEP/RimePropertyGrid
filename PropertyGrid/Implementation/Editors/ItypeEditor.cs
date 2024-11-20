using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RimeControls.PropertyGrid.Implementation
{
    public interface ITypeEditor
    {
        FrameworkElement ResolveEditor(PropertyItem propertyItem);
    }
}
