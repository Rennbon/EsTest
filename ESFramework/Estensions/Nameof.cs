using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ESFramework.Estensions
{
    public static class Nameof
    {
        public static string Property<TProp>(this Expression<Func<IESEntity, TProp>> expression)
        {
            var body = expression.Body as MemberExpression;
            if (body == null)
                throw new ArgumentException("'expression' should be a member expression");
            return body.Member.Name;
        }
    }
}
