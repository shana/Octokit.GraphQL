namespace Octokit.GraphQL
{
    using System.Linq;
    using System.Linq.Expressions;
    using Octokit.GraphQL.Core;
    using Octokit.GraphQL.Core.Builders;

    /// <summary>
    /// An edge in a connection.
    /// </summary>
    public class PullRequestReviewEdge : QueryEntity
    {
        public PullRequestReviewEdge(IQueryProvider provider, Expression expression) : base(provider, expression)
        {
        }

        /// <summary>
        /// A cursor for use in pagination.
        /// </summary>
        public string Cursor { get; }

        /// <summary>
        /// The item at the end of the edge.
        /// </summary>
        public PullRequestReview Node => this.CreateProperty(x => x.Node, Octokit.GraphQL.PullRequestReview.Create);

        internal static PullRequestReviewEdge Create(IQueryProvider provider, Expression expression)
        {
            return new PullRequestReviewEdge(provider, expression);
        }
    }
}