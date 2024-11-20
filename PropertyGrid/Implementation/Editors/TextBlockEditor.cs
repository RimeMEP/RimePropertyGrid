using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace RimeControls.PropertyGrid.Implementation.Editors
{
    public class TextBlockEditor : TypeEditor<TextBlock>
    {
        TypeConverter _typeConverter;

        public TextBlockEditor()
        {
        }

        public TextBlockEditor(TypeConverter typeConverter)
        {
            _typeConverter = typeConverter;
        }

        protected override TextBlock CreateEditor()
        {
            return new PropertyGridEditorTextBlock();
        }

        protected override void SetValueDependencyProperty()
        {
            ValueProperty = TextBlock.TextProperty;
        }

    }





    public class PropertyGridEditorTextBlock : TextBlock
    {
        static PropertyGridEditorTextBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorTextBlock), new FrameworkPropertyMetadata(typeof(PropertyGridEditorTextBlock)));
        }
    }
}
