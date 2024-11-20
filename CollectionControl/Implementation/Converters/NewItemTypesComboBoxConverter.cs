using RimeControls.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RimeControls.CollectionControl.Implementation.Converters
{
    /// <summary>
    /// This multi-value converter is used in the CollectionControls template
    /// to determine the list of possible new item types that will be shown in the combo box.
    /// 
    /// If the second value (i.e., CollectionControls.NewItemTypes) is not null, this list will be used.
    /// Otherwise, if the first value (i.e., CollectionControls.ItemsSourceType) is a "IList&lt;T&gt;"
    /// type, the new item type list will contain "T".
    /// 
    /// </summary>
    public class NewItemTypesComboBoxConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {

            if (values.Length != 2)
                throw new ArgumentException("The 'values' argument should contain 2 objects.");

            if (values[1] != null)
            {
                if (!values[1].GetType().IsGenericType || !(values[1].GetType().GetGenericArguments().First().GetType() is Type))
                    throw new ArgumentException("The 'value' argument is not of the correct type.");

                return values[1];
            }
            else if (values[0] != null)
            {
                if (!(values[0].GetType() is Type))
                    throw new ArgumentException("The 'value' argument is not of the correct type.");

                List<Type> types = new List<Type>();
                Type listType = ListUtilities.GetListItemType((Type)values[0]);
                if (listType != null)
                {
                    types.Add(listType);
                }

                return types;
            }

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
