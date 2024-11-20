using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RimeControls.PropertyGrid.Implementation
{
    internal interface IPropertyContainer
    {







        ContainerHelperBase ContainerHelper
        {
            get;
        }

        Style PropertyContainerStyle
        {
            get;
        }

        EditorDefinitionCollection EditorDefinitions
        {
            get;
        }

        PropertyDefinitionCollection PropertyDefinitions
        {
            get;
        }

        bool IsCategorized
        {
            get;
        }

        bool IsSortedAlphabetically
        {
            get;
        }

        bool AutoGenerateProperties
        {
            get;
        }

        bool HideInheritedProperties
        {
            get;
        }

        FilterInfo FilterInfo
        {
            get;
        }

        bool? IsPropertyVisible(PropertyDescriptor pd);

    }
}
