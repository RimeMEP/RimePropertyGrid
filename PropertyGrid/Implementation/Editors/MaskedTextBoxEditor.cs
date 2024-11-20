using RimeControls.MaskedTextBoxControl.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RimeControls.PropertyGrid.Implementation.Editors
{
    public class MaskedTextBoxEditor : TypeEditor<MaskedTextBox>
    {
        public string Mask
        {
            get;
            set;
        }

        public Type ValueDataType
        {
            get;
            set;
        }

        protected override MaskedTextBox CreateEditor()
        {
            return new PropertyGridEditorMaskedTextBox();
        }

        protected override void SetControlProperties(PropertyItem propertyItem)
        {
            // Do not set Editor properties which could not be overriden in a user style.

            this.Editor.ValueDataType = this.ValueDataType;
            this.Editor.Mask = this.Mask;
        }

        protected override void SetValueDependencyProperty()
        {
            this.ValueProperty = MaskedTextBox.ValueProperty;
        }
    }

    public class PropertyGridEditorMaskedTextBox : MaskedTextBox
    {
        static PropertyGridEditorMaskedTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorMaskedTextBox), new FrameworkPropertyMetadata(typeof(PropertyGridEditorMaskedTextBox)));
        }
    }
}
