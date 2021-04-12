using Azure.Search.Documents;

namespace AzureSearchQueryBuilder.Builders
{
    /// <summary>
    /// An interface representing an orderless <see cref="SuggestParameters"/> builder.
    /// </summary>
    /// <typeparam name="TModel">The type of the model representing the search index documents.</typeparam>
    public interface IOrderlessSuggestOptionsBuilder<TModel>
    {
        /// <summary>
        /// Build a <typeparamref name="SuggestParameters"/> object.
        /// </summary>
        /// <returns>the <typeparamref name="SuggestParameters"/> object.</returns>
        SuggestOptions Build();
    }
}
