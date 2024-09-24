using Project.Core.Common;

namespace Project.Core.Exceptions;

[Serializable]
public class ExpressionBuilderException : Exception
{
    public ExpressionBuilderException(string message) : base(message) { }
    public ExpressionBuilderException(string message, Exception inner) : base(message, inner) { }
    public ExpressionBuilderException(ExpressionFilter filter) : base(filter.ToString())
    {
        //TODO fix base(filter) to provide a readable exception message
    }
}