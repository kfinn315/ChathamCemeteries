using System.Linq.Expressions;
using Project.Core.Common;

namespace Project.Core.Exceptions
{
    internal class NullEndsWithMethodException : ExpressionBuilderException
    {
        public NullEndsWithMethodException(ExpressionFilter filter) : base(filter) { }
    }
}