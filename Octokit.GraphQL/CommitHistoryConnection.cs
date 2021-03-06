namespace Octokit.GraphQL
{
    using System.Linq;
    using System.Linq.Expressions;
    using Octokit.GraphQL.Core;
    using Octokit.GraphQL.Core.Builders;

    /// <summary>
    /// The connection type for Commit.
    /// </summary>
    public class CommitHistoryConnection : QueryEntity
    {
        public CommitHistoryConnection(IQueryProvider provider, Expression expression) : base(provider, expression)
        {
        }

        public IQueryable<CommitEdge> Edges => this.CreateProperty(x => x.Edges);

        /// <summary>
        /// A list of nodes.
        /// </summary>
        public IQueryable<Commit> Nodes => this.CreateProperty(x => x.Nodes);

        /// <summary>
        /// Information to aid in pagination.
        /// </summary>
        public PageInfo PageInfo => this.CreateProperty(x => x.PageInfo, Octokit.GraphQL.PageInfo.Create);

        internal static CommitHistoryConnection Create(IQueryProvider provider, Expression expression)
        {
            return new CommitHistoryConnection(provider, expression);
        }
    }
}