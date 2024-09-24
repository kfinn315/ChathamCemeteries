using Project.Core.Common;

namespace Project.Core.Exceptions;

[Serializable]
public class ExpressionBuilderException : System.Exception
{
    public ExpressionBuilderException(string message) : base(message) { }
    public ExpressionBuilderException(string message, System.Exception inner) : base(message, inner) { }
    // protected ExpressionBuilderException(
    //     System.Runtime.Serialization.SerializationInfo info,
    //     System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    public ExpressionBuilderException(ExpressionFilter filter) : base(filter.ToString()) { 
        //TODO fix base(filter) to provide a readable exception message
    }
}