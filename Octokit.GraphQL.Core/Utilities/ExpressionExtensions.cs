﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Octokit.GraphQL.Core.Syntax;
using Newtonsoft.Json.Linq;

namespace Octokit.GraphQL.Core.Utilities
{
    /// <summary>
    /// Extension methods for Expression objects.
    /// </summary>
    static class ExpressionExtensions
    {
        /// <summary>
        /// Remove all the outer quotes from an expression.
        /// </summary>
        /// <param name="expression">Expression that might contain outer quotes.</param>
        /// <returns>Expression that no longer contains outer quotes.</returns>
        public static Expression StripQuotes(this Expression expression)
        {
            while (expression.NodeType == ExpressionType.Quote)
                expression = ((UnaryExpression)expression).Operand;
            return expression;
        }

        /// <summary>
        /// Get the lambda for an expression stripping any necessary outer quotes.
        /// </summary>
        /// <param name="expression">Expression that should be a lamba possibly wrapped
        /// in outer quotes.</param>
        /// <returns>LambdaExpression no longer wrapped in quotes.</returns>
        public static LambdaExpression GetLambda(this Expression expression)
        {
            return (LambdaExpression)expression.StripQuotes();
        }

        public static Expression AddCast(this Expression expression, Type type)
        {
            if (type.GetTypeInfo().IsAssignableFrom(expression.Type.GetTypeInfo()))
            {
                return expression;
            }
            else if (typeof(JToken).GetTypeInfo().IsAssignableFrom(expression.Type.GetTypeInfo()))
            {
                return Expression.Call(
                    expression,
                    ExpressionMethods.JTokenToObject.MakeGenericMethod(type));
            }
            else if (GetEnumerableResultType(type) != null && IsIQueryableOfJToken(expression.Type))
            {
                var queryType = type.GetTypeInfo().GenericTypeArguments[0];

                MethodCallExpression methodCall;
                if ((methodCall = expression as MethodCallExpression) != null)
                {
                    if (IsSelect(methodCall.Method))
                    {
                        var instance = methodCall.Arguments[0];
                        var lambda = methodCall.Arguments[1].GetLambda();
                        return Expression.Call(
                            ExpressionMethods.SelectMethod.MakeGenericMethod(queryType),
                            instance,
                            Expression.Lambda(
                                lambda.Body.AddCast(queryType),
                                lambda.Parameters));
                    }
                    else if (IsSelectEntity(methodCall.Method))
                    {
                        var instance = methodCall.Arguments[0];
                        var lambda = methodCall.Arguments[1].GetLambda();
                        return Expression.Call(
                            ExpressionMethods.SelectEntityMethod.MakeGenericMethod(queryType),
                            instance,
                            Expression.Lambda(
                                lambda.Body.AddCast(queryType),
                                lambda.Parameters));
                    }
                }
                else
                {
                    var parameter = Expression.Parameter(typeof(JToken));
                    return Expression.Call(
                        ExpressionMethods.SelectMethod.MakeGenericMethod(queryType),
                        expression,
                        Expression.Lambda(
                            parameter.AddCast(queryType),
                            parameter));
                }
            }

            throw new NotSupportedException(
                $"Don't know how to cast '{expression}' to '{type}'.");
        }

        /// <summary>
        /// Adds an indexer to an expression representing a <see cref="JToken"/>.
        /// </summary>
        /// <param name="instance">The expression.</param>
        /// <param name="field">The field to return.</param>
        /// <returns>A new expression.</returns>
        public static Expression AddIndexer(this Expression instance, FieldSelection field)
        {
            return AddIndexer(instance, field.Alias ?? field.Name);
        }

        /// <summary>
        /// Adds an indexer to an expression representing a <see cref="JToken"/> or a collection of
        /// <see cref="JToken"/>s.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="field">The field to return.</param>
        /// <returns>A new expression.</returns>
        public static Expression AddIndexer(this Expression expression, string fieldName)
        {
            if (expression.Type.GetTypeInfo().IsAssignableFrom(typeof(JToken).GetTypeInfo()))
            {
                // Returns `expression[fieldName];`
                return Expression.Call(
                    expression,
                    ExpressionMethods.JTokenIndexer,
                    Expression.Constant(fieldName));
            }
            else if (IsIQueryableOfJToken(expression.Type))
            {
                // Returns `expression.Select(x => x[fieldName]);`
                var lambdaParameter = Expression.Parameter(typeof(JToken));
                return Expression.Call(
                    ExpressionMethods.SelectMethod.MakeGenericMethod(typeof(JToken)),
                    expression,
                    Expression.Lambda(
                        lambdaParameter.AddIndexer(fieldName),
                        lambdaParameter));
            }
            else
            {
                throw new NotSupportedException($"Don't know how to add an indexer to {expression}.");
            }
        }

        private static Type GetEnumerableResultType(Type type)
        {
            if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                return type.GetTypeInfo().GenericTypeArguments[0];
            }

            foreach (var i in type.GetTypeInfo().ImplementedInterfaces)
            {
                if (i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    return i.GetTypeInfo().GenericTypeArguments[0];
                }
            }

            return null;
        }

        private static bool IsIQueryableOfJToken(Type type)
        {
            return typeof(IQueryable<JToken>).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo());
        }

        private static bool IsSelect(MethodInfo method)
        {
            return (method.DeclaringType == typeof(ExpressionMethods) &&
                method.Name == nameof(ExpressionMethods.Select) &&
                method.GetParameters().Length == 2);
        }

        private static bool IsSelectEntity(MethodInfo method)
        {
            return (method.DeclaringType == typeof(ExpressionMethods) &&
                method.Name == nameof(ExpressionMethods.SelectEntity) &&
                method.GetParameters().Length == 2);
        }
    }
}
