﻿using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Azure.Search.Models;

namespace AzureSearchQueryBuilder.Builders
{
    public interface ISuggestParametersBuilder<TModel> : IParametersBuilder<TModel, SuggestParameters>
    {
        IEnumerable<string> OrderBy { get; }

        IEnumerable<string> Select { get; }

        bool UseFuzzyMatching { get; }

        ISuggestParametersBuilder<TModel> OrderByAscending<TProperty>(Expression<PropertyLambdaDelegate<TModel, TProperty>> lambdaExpression);

        ISuggestParametersBuilder<TModel> OrderByDescending<TProperty>(Expression<PropertyLambdaDelegate<TModel, TProperty>> lambdaExpression);

        ISuggestParametersBuilder<TModel> WithSelect<TProperty>(Expression<PropertyLambdaDelegate<TModel, TProperty>> lambdaExpression);

        ISuggestParametersBuilder<TModel> ThenByAscending<TProperty>(Expression<PropertyLambdaDelegate<TModel, TProperty>> lambdaExpression);

        ISuggestParametersBuilder<TModel> ThenByDescending<TProperty>(Expression<PropertyLambdaDelegate<TModel, TProperty>> lambdaExpression);

        ISuggestParametersBuilder<TModel> WithUseFuzzyMatching(bool useFuzzyMatching);
    }
}
