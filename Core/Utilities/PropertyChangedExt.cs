﻿using RimeControls.PropertyGrid.Implementation.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RimeControls.Core.Utilities
{
    internal static class PropertyChangedExt
    {
        #region Notify Methods

        public static void Notify<TMember>(
          this INotifyPropertyChanged sender,
          PropertyChangedEventHandler handler,
          Expression<Func<TMember>> expression)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            if (expression == null)
                throw new ArgumentNullException("expression");

            var body = expression.Body as MemberExpression;
            if (body == null)
                throw new ArgumentException("The expression must target a property or field.", "expression");

            string propertyName = GetPropertyName(body, sender.GetType());

            NotifyCore(sender, handler, propertyName);
        }

        public static void Notify(this INotifyPropertyChanged sender, PropertyChangedEventHandler handler, string propertyName)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            if (propertyName == null)
                throw new ArgumentNullException("propertyName");

            ReflectionHelper.ValidatePropertyName(sender, propertyName);

            NotifyCore(sender, handler, propertyName);
        }

        private static void NotifyCore(INotifyPropertyChanged sender, PropertyChangedEventHandler handler, string propertyName)
        {
            if (handler != null)
            {
                handler(sender, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region PropertyChanged Verification Methods

        internal static bool PropertyChanged(string propertyName, PropertyChangedEventArgs e, bool targetPropertyOnly)
        {
            string target = e.PropertyName;
            if (target == propertyName)
                return true;

            return !targetPropertyOnly
                && string.IsNullOrEmpty(target);
        }

        internal static bool PropertyChanged<TOwner, TMember>(
          Expression<Func<TMember>> expression,
          PropertyChangedEventArgs e,
          bool targetPropertyOnly)
        {
            var body = expression.Body as MemberExpression;
            if (body == null)
                throw new ArgumentException("The expression must target a property or field.", "expression");

            return PropertyChanged(body, typeof(TOwner), e, targetPropertyOnly);
        }

        internal static bool PropertyChanged<TOwner, TMember>(
          Expression<Func<TOwner, TMember>> expression,
          PropertyChangedEventArgs e,
          bool targetPropertyOnly)
        {
            var body = expression.Body as MemberExpression;
            if (body == null)
                throw new ArgumentException("The expression must target a property or field.", "expression");

            return PropertyChanged(body, typeof(TOwner), e, targetPropertyOnly);
        }

        private static bool PropertyChanged(MemberExpression expression, Type ownerType, PropertyChangedEventArgs e, bool targetPropertyOnly)
        {
            var propertyName = GetPropertyName(expression, ownerType);

            return PropertyChanged(propertyName, e, targetPropertyOnly);
        }

        #endregion

        private static string GetPropertyName(MemberExpression expression, Type ownerType)
        {
            var targetType = expression.Expression.Type;
            if (!targetType.IsAssignableFrom(ownerType))
                throw new ArgumentException("The expression must target a property or field on the appropriate owner.", "expression");

            return ReflectionHelper.GetPropertyOrFieldName(expression);
        }
    }
}
