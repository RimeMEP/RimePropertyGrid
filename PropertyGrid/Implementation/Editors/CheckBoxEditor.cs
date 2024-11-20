using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace RimeControls.PropertyGrid.Implementation.Editors
{
    public class CheckBoxEditor : TypeEditor<CheckBox>
    {
        protected override CheckBox CreateEditor()
        {
            return new PropertyGridEditorCheckBox();
        }

        protected override void SetValueDependencyProperty()
        {
            ValueProperty = CheckBox.IsCheckedProperty;
        }
    }

    public class PropertyGridEditorCheckBox : CheckBox
    {
        static PropertyGridEditorCheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorCheckBox), new FrameworkPropertyMetadata(typeof(PropertyGridEditorCheckBox)));
        }
    }
}
