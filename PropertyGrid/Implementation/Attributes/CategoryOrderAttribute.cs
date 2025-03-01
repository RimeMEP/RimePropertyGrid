﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimeControls.PropertyGrid.Implementation
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CategoryOrderAttribute : Attribute
    {
        #region Properties

        #region Order

        public int Order
        {
            get;
            set;
        }

        #endregion

        #region Category

        public virtual string Category
        {
            get
            {
                return CategoryValue;
            }
        }

        #endregion

        #region CategoryValue

        public string CategoryValue
        {
            get;
            private set;
        }

        #endregion

        public override object TypeId
        {
            get
            {
                return this.CategoryValue;
            }
        }

        #endregion

        #region constructor

        public CategoryOrderAttribute()
        {
        }

        public CategoryOrderAttribute(string categoryName, int order)
          : this()
        {
            CategoryValue = categoryName;
            Order = order;
        }

        #endregion
    }
}
