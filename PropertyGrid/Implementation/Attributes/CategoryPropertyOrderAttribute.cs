using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimeControls.PropertyGrid.Implementation
{
    public enum CategoryPropertyOrderEnum
    {
        Alphabetical,
        Declaration
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CategoryPropertyOrderAttribute : Attribute
    {
        #region Properties

        #region CategoryPropertyOrder

        public CategoryPropertyOrderEnum CategoryPropertyOrder
        {
            get;
            private set;
        }

        #endregion

        #endregion

        #region constructor

        public CategoryPropertyOrderAttribute(CategoryPropertyOrderEnum categoryPropertyOrder = CategoryPropertyOrderEnum.Alphabetical)
        {
            CategoryPropertyOrder = categoryPropertyOrder;
        }

        #endregion
    }
}
