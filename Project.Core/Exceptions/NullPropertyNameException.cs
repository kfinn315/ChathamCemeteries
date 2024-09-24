using Project.Core.Common;

namespace Project.Core.Exceptions
{
    [Serializable]
    internal class NullPropertyNameException : ExpressionBuilderException
    {
        public NullPropertyNameException(ExpressionFilter filter) : base(filter) { }
    }
}