using System.Linq.Expressions;
using Project.Core.Common;

namespace Project.Core.Exceptions
{
    internal class NullContainsMethodException : ExpressionBuilderException
    {
        public NullContainsMethodException(ExpressionFilter filter) : base(filter)
        {
        }
    }
}