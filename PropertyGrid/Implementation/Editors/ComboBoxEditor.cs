using RimeControls.PropertyGrid.Implementation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RimeControls.PropertyGrid.Implementation.Editors
{
    public abstract class ComboBoxEditor : TypeEditor<System.Windows.Controls.ComboBox>
    {
        protected override void SetValueDependencyProperty()
        {
            ValueProperty = System.Windows.Controls.Primitives.Selector.SelectedItemProperty;
        }

        protected override System.Windows.Controls.ComboBox CreateEditor()
        {
            return new PropertyGridEditorComboBox();
        }

        protected override void ResolveValueBinding(PropertyItem propertyItem)
        {
            SetItemsSource(propertyItem);
            base.ResolveValueBinding(propertyItem);
        }

        protected abstract IEnumerable CreateItemsSource(PropertyItem propertyItem);

        private void SetItemsSource(PropertyItem propertyItem)
        {
            Editor.ItemsSource = CreateItemsSource(propertyItem);
        }
    }

    public class PropertyGridEditorComboBox : System.Windows.Controls.ComboBox
    {
        static PropertyGridEditorComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorComboBox), new FrameworkPropertyMetadata(typeof(PropertyGridEditorComboBox)));
        }
    }
}
