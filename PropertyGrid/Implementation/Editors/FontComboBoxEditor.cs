﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using RimeControls.Core.Utilities;

namespace RimeControls.PropertyGrid.Implementation.Editors
{
    public class FontComboBoxEditor : ComboBoxEditor
    {
        protected override IEnumerable CreateItemsSource(PropertyItem propertyItem)
        {
            if (propertyItem.PropertyType == typeof(FontFamily))
                return FontUtilities.Families.OrderBy(x => x.Source);
            else if (propertyItem.PropertyType == typeof(FontWeight))
                return FontUtilities.Weights;
            else if (propertyItem.PropertyType == typeof(FontStyle))
                return FontUtilities.Styles;
            else if (propertyItem.PropertyType == typeof(FontStretch))
                return FontUtilities.Stretches;

            return null;
        }
    }
}
