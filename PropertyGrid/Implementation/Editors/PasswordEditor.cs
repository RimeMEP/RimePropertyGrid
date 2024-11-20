using RimeControls.PropertyGrid.Implementation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using RimeControls.PasswordBoxes;

namespace RimeControls.PropertyGrid.Implementation.Editors
{
    public class PasswordEditor : TypeEditor<WatermarkPasswordBox>
    {
        protected override WatermarkPasswordBox CreateEditor()
        {
            return new PropertyGridEditorWatermarkPasswordBox();
        }

        protected override void SetValueDependencyProperty()
        {
            ValueProperty = System.Windows.Controls.TextBox.TextProperty;
        }

        protected override IValueConverter CreateValueConverter()
        {
            return new PasswordToStringConverter(Editor);
        }
    }

    public class PasswordToStringConverter : IValueConverter
    {
        private WatermarkPasswordBox _editor;

        public PasswordToStringConverter(WatermarkPasswordBox editor)
        {
            _editor = editor;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            _editor.Password = value as string;
            return _editor.Text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return _editor.Password;
        }
    }

    public class PropertyGridEditorWatermarkPasswordBox : WatermarkPasswordBox
    {
        static PropertyGridEditorWatermarkPasswordBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorWatermarkPasswordBox), new FrameworkPropertyMetadata(typeof(PropertyGridEditorWatermarkPasswordBox)));
        }
    }
}
