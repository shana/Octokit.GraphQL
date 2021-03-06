namespace Octokit.GraphQL
{
    using System.Linq;
    using System.Linq.Expressions;
    using Octokit.GraphQL.Core;
    using Octokit.GraphQL.Core.Builders;

    /// <summary>
    /// An edge in a connection.
    /// </summary>
    public class PullRequestCommitEdge : QueryEntity
    {
        public PullRequestCommitEdge(IQueryProvider provider, Expression expression) : base(provider, expression)
        {
        }

        /// <summary>
        /// A cursor for use in pagination.
        /// </summary>
        public string Cursor { get; }

        /// <summary>
        /// The item at the end of the edge.
        /// </summary>
        public PullRequestCommit Node => this.CreateProperty(x => x.Node, Octokit.GraphQL.PullRequestCommit.Create);

        internal static PullRequestCommitEdge Create(IQueryProvider provider, Expression expression)
        {
            return new PullRequestCommitEdge(provider, expression);
        }
    }
}