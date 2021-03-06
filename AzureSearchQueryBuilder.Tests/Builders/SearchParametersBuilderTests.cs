using System.Linq;
using AzureSearchQueryBuilder.Builders;
using Microsoft.Azure.Search.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzureSearchQueryBuilder.Tests.Builders
{
    [TestClass]
    public class SearchParametersBuilderTests : ParametersBuilderTests<SearchParameters>
    {
        [TestMethod]
        public void SearchPropertyNameUtility_Facets()
        {
            ISearchParametersBuilder<Model> searchParametersBuilder = SearchParametersBuilder<Model>.Create();

            Assert.IsNull(searchParametersBuilder.Facets);

            searchParametersBuilder.WithFacet(_ => SearchFns.Score());

            Assert.IsNotNull(searchParametersBuilder.Facets);
            Assert.AreEqual(1, searchParametersBuilder.Facets.Count());
            Assert.AreEqual("search.score()", searchParametersBuilder.Facets.ElementAtOrDefault(0));

            SearchParameters parameters = searchParametersBuilder.Build();
            Assert.IsNotNull(parameters);
            Assert.IsNotNull(parameters.Facets);
            Assert.AreEqual(1, parameters.Facets.Count());
            Assert.AreEqual("search.score()", parameters.Facets.ElementAtOrDefault(0));
        }

        [TestMethod]
        public void SearchPropertyNameUtility_HighlightFields()
        {
            ISearchParametersBuilder<Model> searchParametersBuilder = SearchParametersBuilder<Model>.Create();

            Assert.IsNull(searchParametersBuilder.HighlightFields);

            searchParametersBuilder.WithHighlightField(_ => SearchFns.Score());

            Assert.IsNotNull(searchParametersBuilder.HighlightFields);
            Assert.AreEqual(1, searchParametersBuilder.HighlightFields.Count());
            Assert.AreEqual("search.score()", searchParametersBuilder.HighlightFields.ElementAtOrDefault(0));

            SearchParameters parameters = searchParametersBuilder.Build();
            Assert.IsNotNull(parameters);
            Assert.IsNotNull(parameters.HighlightFields);
            Assert.AreEqual(1, parameters.HighlightFields.Count());
            Assert.AreEqual("search.score()", parameters.HighlightFields.ElementAtOrDefault(0));
        }

        [TestMethod]
        public void SearchPropertyNameUtility_IncludeTotalResultCount()
        {
            ISearchParametersBuilder<Model> searchParametersBuilder = SearchParametersBuilder<Model>.Create();

            Assert.IsFalse(searchParametersBuilder.IncludeTotalResultCount);

            searchParametersBuilder.WithIncludeTotalResultCount(true);

            Assert.IsTrue(searchParametersBuilder.IncludeTotalResultCount);

            SearchParameters parameters = searchParametersBuilder.Build();
            Assert.IsNotNull(parameters);
            Assert.IsTrue(parameters.IncludeTotalResultCount);
        }

        [TestMethod]
        public void SearchPropertyNameUtility_OrderBy()
        {
            ISearchParametersBuilder<Model> searchParametersBuilder = SearchParametersBuilder<Model>.Create();

            Assert.IsNull(searchParametersBuilder.OrderBy);

            searchParametersBuilder.WithOrderBy(_ => SearchFns.Score()).WithThenByDescending(_ => SearchFns.Score());

            Assert.IsNotNull(searchParametersBuilder.OrderBy);
            Assert.AreEqual(2, searchParametersBuilder.OrderBy.Count());
            Assert.AreEqual("search.score() asc", searchParametersBuilder.OrderBy.ElementAtOrDefault(0));
            Assert.AreEqual("search.score() desc", searchParametersBuilder.OrderBy.ElementAtOrDefault(1));

            SearchParameters parameters = searchParametersBuilder.Build();
            Assert.IsNotNull(parameters);
            Assert.IsNotNull(parameters.OrderBy);
            Assert.AreEqual(2, parameters.OrderBy.Count());
            Assert.AreEqual("search.score() asc", parameters.OrderBy.ElementAtOrDefault(0));
            Assert.AreEqual("search.score() desc", parameters.OrderBy.ElementAtOrDefault(1));

            searchParametersBuilder.WithOrderByDescending(_ => SearchFns.Score()).WithThenBy(_ => SearchFns.Score());

            Assert.IsNotNull(searchParametersBuilder.OrderBy);
            Assert.AreEqual(2, searchParametersBuilder.OrderBy.Count());
            Assert.AreEqual("search.score() desc", searchParametersBuilder.OrderBy.ElementAtOrDefault(0));
            Assert.AreEqual("search.score() asc", searchParametersBuilder.OrderBy.ElementAtOrDefault(1));

            parameters = searchParametersBuilder.Build();
            Assert.IsNotNull(parameters);
            Assert.IsNotNull(parameters.OrderBy);
            Assert.AreEqual(2, parameters.OrderBy.Count());
            Assert.AreEqual("search.score() desc", parameters.OrderBy.ElementAtOrDefault(0));
            Assert.AreEqual("search.score() asc", parameters.OrderBy.ElementAtOrDefault(1));
        }

        [TestMethod]
        public void SearchPropertyNameUtility_ScoringParameters()
        {
            ISearchParametersBuilder<Model> searchParametersBuilder = SearchParametersBuilder<Model>.Create();

            Assert.IsNull(searchParametersBuilder.ScoringParameters);

            searchParametersBuilder.WithScoringParameter(new ScoringParameter("foo", Enumerable.Empty<string>()));

            Assert.IsNotNull(searchParametersBuilder.ScoringParameters);
            Assert.AreEqual(1, searchParametersBuilder.ScoringParameters.Count());

            SearchParameters parameters = searchParametersBuilder.Build();
            Assert.IsNotNull(parameters);
            Assert.IsNotNull(parameters.ScoringParameters);
            Assert.AreEqual(1, parameters.ScoringParameters.Count());
        }

        [TestMethod]
        public void SearchPropertyNameUtility_ScoringProfile()
        {
            ISearchParametersBuilder<Model> searchParametersBuilder = SearchParametersBuilder<Model>.Create();

            Assert.IsNull(searchParametersBuilder.ScoringProfile);

            searchParametersBuilder.WithScoringProfile("test");

            Assert.IsNotNull(searchParametersBuilder.ScoringProfile);
            Assert.AreEqual("test", searchParametersBuilder.ScoringProfile);

            SearchParameters parameters = searchParametersBuilder.Build();
            Assert.IsNotNull(parameters);
            Assert.AreEqual("test", parameters.ScoringProfile);
        }

        [TestMethod]
        public void SearchPropertyNameUtility_SearchMode()
        {
            ISearchParametersBuilder<Model> searchParametersBuilder = SearchParametersBuilder<Model>.Create();

            Assert.AreEqual(SearchMode.Any, searchParametersBuilder.SearchMode);

            searchParametersBuilder.WithSearchMode(SearchMode.All);

            Assert.AreEqual(SearchMode.All, searchParametersBuilder.SearchMode);

            SearchParameters parameters = searchParametersBuilder.Build();
            Assert.IsNotNull(parameters);
            Assert.AreEqual(SearchMode.All, parameters.SearchMode);
        }

        [TestMethod]
        public void SearchPropertyNameUtility_Select()
        {
            ISearchParametersBuilder<Model> searchParametersBuilder = SearchParametersBuilder<Model>.Create();

            Assert.IsNull(searchParametersBuilder.Select);

            searchParametersBuilder.WithSelect(_ => SearchFns.Score());

            Assert.IsNotNull(searchParametersBuilder.Select);
            Assert.AreEqual(1, searchParametersBuilder.Select.Count());
            Assert.AreEqual("search.score()", searchParametersBuilder.Select.ElementAtOrDefault(0));

            SearchParameters parameters = searchParametersBuilder.Build();
            Assert.IsNotNull(parameters);
            Assert.IsNotNull(parameters.Select);
            Assert.AreEqual(1, parameters.Select.Count());
            Assert.AreEqual("search.score()", parameters.Select.ElementAtOrDefault(0));
        }

        [TestMethod]
        public void SearchPropertyNameUtility_Skip()
        {
            ISearchParametersBuilder<Model> searchParametersBuilder = SearchParametersBuilder<Model>.Create();

            Assert.IsNull(searchParametersBuilder.Skip);

            searchParametersBuilder.WithSkip(1);

            Assert.IsNotNull(searchParametersBuilder.Skip);
            Assert.AreEqual(1, searchParametersBuilder.Skip);

            SearchParameters parameters = searchParametersBuilder.Build();
            Assert.IsNotNull(parameters);
            Assert.AreEqual(1, parameters.Skip);
        }

        protected override IParametersBuilder<Model, SearchParameters> ConstructBuilder()
        {
            return (SearchParametersBuilder<Model>)SearchParametersBuilder<Model>.Create();
        }
    }
}
