using Project.Core.Common;

namespace Project.Core.Exceptions
{
    internal class NullStartsWithMethodException : ExpressionBuilderException
    {
        public NullStartsWithMethodException(ExpressionFilter filter) : base(filter) { }
    }
}