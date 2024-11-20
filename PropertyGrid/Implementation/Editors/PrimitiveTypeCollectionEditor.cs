using RimeControls.CollectionControl.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RimeControls.PropertyGrid.Implementation.Editors
{
    public class PrimitiveTypeCollectionEditor : TypeEditor<PrimitiveTypeCollectionControl>
    {

        protected override void SetValueDependencyProperty()
        {
            ValueProperty = PrimitiveTypeCollectionControl.ItemsSourceProperty;
        }

        protected override PrimitiveTypeCollectionControl CreateEditor()
        {
            return new PropertyGridEditorPrimitiveTypeCollectionControl();
        }

        protected override void ResolveValueBinding(PropertyItem propertyItem)
        {
            var type = propertyItem.PropertyType;
            Editor.ItemsSourceType = type;

            if (type.BaseType == typeof(System.Array))
            {
                Editor.ItemType = type.GetElementType();
            }
            else
            {
                var typeArguments = type.GetGenericArguments();
                if (typeArguments.Length > 0)
                {
                    Editor.ItemType = typeArguments[0];
                }
            }

            base.ResolveValueBinding(propertyItem);
        }
    }

        public class PropertyGridEditorPrimitiveTypeCollectionControl : PrimitiveTypeCollectionControl
        {
            static PropertyGridEditorPrimitiveTypeCollectionControl()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorPrimitiveTypeCollectionControl), new FrameworkPropertyMetadata(typeof(PropertyGridEditorPrimitiveTypeCollectionControl)));
            }
        }
    
}
