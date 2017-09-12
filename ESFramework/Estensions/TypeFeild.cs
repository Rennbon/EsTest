using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ESFramework.Estensions
{
    public class TypeFeild<T> 
    {

        private Expression<Func<T, object>> feild;
        private object value;

        public Expression<Func<T, object>> Field { get { return feild; } }
        public object Value { get { return value; } }

        public TypeFeild(Expression<Func<T, object>> expression, object value)
        {
            this.feild = expression;
            this.value = value;
        }
    }
}
