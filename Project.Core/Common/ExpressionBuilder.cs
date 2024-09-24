using System.Linq.Expressions;
using System.Reflection;
using Project.Core.Exceptions;

namespace Project.Core.Common
{
    public static class ExpressionBuilder
    {
        public static Expression<Func<T, bool>>? ConstructAndExpressionTree<T>(List<ExpressionFilter> filters)
        {
            if (filters.Count == 0)
                return null;

            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            Expression? exp;
            if (filters.Count == 1)
            {
                exp = GetExpression<T>(param, filters[0]);
            }
            else
            {
                exp = GetExpression<T>(param, filters[0]);
                for (int i = 1; i < filters.Count; i++)
                {
                    var exp1 = GetExpression<T>(param, filters[i]);
                    exp = Expression.Or(exp!, exp1!);
                }
            }

            return Expression.Lambda<Func<T, bool>>(exp, param);
        }

        public static Expression GetExpression<T>(ParameterExpression param, ExpressionFilter filter)
        {
            MethodInfo? containsMethod = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
            MethodInfo? startsWithMethod = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
            MethodInfo? endsWithMethod = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });

            if (filter.PropertyName is null)
            {
                throw new NullPropertyNameException(filter);
            }

            MemberExpression member = Expression.Property(param, filter.PropertyName!);
            ConstantExpression constant = Expression.Constant(filter.Value);

            switch (filter.Comparison)
            {
                case Comparison.Equal:
                    return Expression.Equal(member, constant);
                case Comparison.GreaterThan:
                    return Expression.GreaterThan(member, constant);
                case Comparison.GreaterThanOrEqual:
                    return Expression.GreaterThanOrEqual(member, constant);
                case Comparison.LessThan:
                    return Expression.LessThan(member, constant);
                case Comparison.LessThanOrEqual:
                    return Expression.LessThanOrEqual(member, constant);
                case Comparison.NotEqual:
                    return Expression.NotEqual(member, constant);
                case Comparison.Contains:
                    if (containsMethod is null)
                        throw new NullContainsMethodException(filter);
                    return Expression.Call(member, containsMethod, constant);
                case Comparison.StartsWith:
                    if (startsWithMethod is null)
                        throw new NullStartsWithMethodException(filter);
                    return Expression.Call(member, startsWithMethod, constant);
                case Comparison.EndsWith:
                    if (endsWithMethod is null)
                        throw new NullEndsWithMethodException(filter);
                    return Expression.Call(member, endsWithMethod, constant);
                default:
                    // return null;
                    throw new ComparisonNotImplementedException(filter);
            }
        }
    }
}