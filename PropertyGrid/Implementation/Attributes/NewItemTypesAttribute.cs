using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimeControls.PropertyGrid.Implementation
{
    /// <summary>
    /// This attribute can decorate the collection properties (i.e., IList) 
    /// of your selected object in order to control the types that will be allowed
    /// to be instantiated in the CollectionControls.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class NewItemTypesAttribute : Attribute
    {
        public IList<Type> Types
        {
            get;
            set;
        }

        public NewItemTypesAttribute(params Type[] types)
        {
            this.Types = new List<Type>(types);
        }

        public NewItemTypesAttribute()
        {
        }
    }
}
