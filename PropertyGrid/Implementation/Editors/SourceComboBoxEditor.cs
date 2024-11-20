using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RimeControls.PropertyGrid.Implementation.Editors
{
    public class SourceComboBoxEditor : ComboBoxEditor
    {
        internal static string ComboBoxNullValue = "Null";

        ICollection _collection;
        TypeConverter _typeConverter;

        public SourceComboBoxEditor(ICollection collection, TypeConverter typeConverter)
        {
            // Add a "Null" input value in the ComboBox when using a NullableConverter.
            _collection = (typeConverter is NullableConverter)
                          ? collection.Cast<object>().Select(x => x ?? SourceComboBoxEditor.ComboBoxNullValue).ToArray()
                          : collection;
            _typeConverter = typeConverter;
        }

        protected override IEnumerable CreateItemsSource(PropertyItem propertyItem)
        {
            return _collection;
        }

        protected override IValueConverter CreateValueConverter()
        {
            if (_typeConverter != null)
            {
                //When using a stringConverter, we need to convert the value
                if (_typeConverter is StringConverter)
                    return new SourceComboBoxEditorStringConverter(_typeConverter);
                //When using a NullableConverter, we need to convert the null value
                if (_typeConverter is NullableConverter)
                    return new SourceComboBoxEditorNullableConverter();
            }
            return null;
        }
    }

    internal class SourceComboBoxEditorStringConverter : IValueConverter
    {
        private TypeConverter _typeConverter;

        internal SourceComboBoxEditorStringConverter(TypeConverter typeConverter)
        {
            _typeConverter = typeConverter;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (_typeConverter != null)
            {
                if (_typeConverter.CanConvertTo(typeof(string)))
                    return _typeConverter.ConvertTo(value, typeof(string));
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (_typeConverter != null)
            {
                if (_typeConverter.CanConvertFrom(value.GetType()))
                    return _typeConverter.ConvertFrom(value);
            }
            return value;
        }
    }

    internal class SourceComboBoxEditorNullableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value ?? SourceComboBoxEditor.ComboBoxNullValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.Equals(SourceComboBoxEditor.ComboBoxNullValue) ? null : value;
        }
    }
}
