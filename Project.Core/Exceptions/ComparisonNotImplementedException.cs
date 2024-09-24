using Project.Core.Common;

namespace Project.Core.Exceptions;

[System.Serializable]
public class ComparisonNotImplementedException : ExpressionBuilderException
{
    public ComparisonNotImplementedException(ExpressionFilter filter) : base(filter) { }
}
