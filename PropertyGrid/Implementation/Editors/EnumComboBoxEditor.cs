﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RimeControls.PropertyGrid.Implementation.Editors
{
    public class EnumComboBoxEditor : ComboBoxEditor
    {
        protected override IEnumerable CreateItemsSource(PropertyItem propertyItem)
        {
            return GetValues(propertyItem.PropertyType);
        }

        private static object[] GetValues(Type enumType)
        {
            List<object> values = new List<object>();

            if (enumType != null)
            {
                var fields = enumType.GetFields().Where(x => x.IsLiteral);
                foreach (FieldInfo field in fields)
                {
                    // Get array of BrowsableAttribute attributes
                    object[] attrs = field.GetCustomAttributes(typeof(BrowsableAttribute), false);
                    if (attrs.Length == 1)
                    {
                        // If attribute exists and its value is false continue to the next field...
                        BrowsableAttribute brAttr = (BrowsableAttribute)attrs[0];
                        if (brAttr.Browsable == false)
                            continue;
                    }

                    values.Add(field.GetValue(enumType));
                }
            }

            return values.ToArray();
        }
    }
}
