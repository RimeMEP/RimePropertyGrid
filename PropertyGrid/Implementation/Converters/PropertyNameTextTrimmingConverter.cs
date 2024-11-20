using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace RimeControls.PropertyGrid.Implementation.Converters
{
    public class PropertyNameTextTrimmingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var textWrapping = (TextWrapping)value;
            return (textWrapping == TextWrapping.NoWrap) ? TextTrimming.CharacterEllipsis : TextTrimming.None;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
