using RimeControls.PropertyGrid.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RimeControls.PropertyGrid.Implementation
{
    public class EditorTemplateDefinition : EditorDefinitionBase
    {


        #region EditingTemplate
        public static readonly DependencyProperty EditingTemplateProperty =
            DependencyProperty.Register("EditingTemplate", typeof(DataTemplate), typeof(EditorTemplateDefinition), new UIPropertyMetadata(null));

        public DataTemplate EditingTemplate
        {
            get
            {
                return (DataTemplate)GetValue(EditingTemplateProperty);
            }
            set
            {
                SetValue(EditingTemplateProperty, value);
            }
        }
        #endregion //EditingTemplate

        protected override sealed FrameworkElement GenerateEditingElement(PropertyItemBase propertyItem)
        {
            return (this.EditingTemplate != null)
              ? this.EditingTemplate.LoadContent() as FrameworkElement
              : null;
        }
    }

}
