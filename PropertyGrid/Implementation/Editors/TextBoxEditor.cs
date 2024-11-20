using RimeControls.PropertyGrid.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using RimeControls.TextBoxControls.WatermarkTextboxControl.Implementation;

namespace RimeControls.PropertyGrid.Implementation.Editors
{
    public class TextBoxEditor : TypeEditor<WatermarkTextBox>
    {
        protected override WatermarkTextBox CreateEditor()
        {
            return new PropertyGridEditorTextBox();
        }

#if !VS2008
        protected override void SetControlProperties(PropertyItem propertyItem)
        {
            var displayAttribute = PropertyGridUtilities.GetAttribute<DisplayAttribute>(propertyItem.PropertyDescriptor);
            if (displayAttribute != null)
            {
                Editor.Watermark = displayAttribute.GetPrompt();
            }
        }
#endif

        protected override void SetValueDependencyProperty()
        {
            ValueProperty = TextBox.TextProperty;
        }
    }

    public class PropertyGridEditorTextBox : WatermarkTextBox
    {
        static PropertyGridEditorTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorTextBox), new FrameworkPropertyMetadata(typeof(PropertyGridEditorTextBox)));
        }
    }
}
