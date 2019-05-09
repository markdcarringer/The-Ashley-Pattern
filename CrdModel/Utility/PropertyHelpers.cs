using System;
using System.Linq.Expressions;

namespace CrdModel.Utility
{
    public static class PropertyHelpers
    {
        private static string GetPropertyName<T>(Expression<Func<T>> propertyLambda)
        {
            if (propertyLambda.Body is MemberExpression source)
            {
                return source.Member.Name;
            }

            return string.Empty;
        }

        public static string GetPropertyNameAsCrdProperty<T>(Expression<Func<T>> propertyLambda)
        {
            return GetPropertyName(propertyLambda).ToCrdFriendlyName();
        }
    }
}
