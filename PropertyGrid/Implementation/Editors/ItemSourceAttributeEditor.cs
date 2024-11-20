using RimeControls.PropertyGrid.Implementation.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimeControls.PropertyGrid.Implementation
{
    public class ItemsSourceAttributeEditor : TypeEditor<System.Windows.Controls.ComboBox>
    {
        private readonly ItemsSourceAttribute _attribute;

        public ItemsSourceAttributeEditor(ItemsSourceAttribute attribute)
        {
            _attribute = attribute;
        }

        protected override void SetValueDependencyProperty()
        {
            ValueProperty = System.Windows.Controls.ComboBox.SelectedValueProperty;
        }

        protected override System.Windows.Controls.ComboBox CreateEditor()
        {
            return new PropertyGridEditorComboBox();
        }

        protected override void ResolveValueBinding(PropertyItem propertyItem)
        {
            SetItemsSource();
            base.ResolveValueBinding(propertyItem);
        }

        protected override void SetControlProperties(PropertyItem propertyItem)
        {
            Editor.DisplayMemberPath = "DisplayName";
            Editor.SelectedValuePath = "Value";
            if (propertyItem != null)
            {
                Editor.IsEnabled = !propertyItem.IsReadOnly;
            }
        }

        private void SetItemsSource()
        {
            Editor.ItemsSource = CreateItemsSource();
        }

        private System.Collections.IEnumerable CreateItemsSource()
        {
            var instance = Activator.CreateInstance(_attribute.Type);
            return (instance as IItemsSource).GetValues();
        }
    }
}
