namespace Octokit.GraphQL
{
    using System.Linq;
    using System.Linq.Expressions;
    using Octokit.GraphQL.Core;
    using Octokit.GraphQL.Core.Builders;

    /// <summary>
    /// A list of repositories owned by the subject.
    /// </summary>
    public class RepositoryConnection : QueryEntity
    {
        public RepositoryConnection(IQueryProvider provider, Expression expression) : base(provider, expression)
        {
        }

        /// <summary>
        /// A list of edges.
        /// </summary>
        public IQueryable<RepositoryEdge> Edges => this.CreateProperty(x => x.Edges);

        /// <summary>
        /// A list of nodes.
        /// </summary>
        public IQueryable<Repository> Nodes => this.CreateProperty(x => x.Nodes);

        /// <summary>
        /// Information to aid in pagination.
        /// </summary>
        public PageInfo PageInfo => this.CreateProperty(x => x.PageInfo, Octokit.GraphQL.PageInfo.Create);

        /// <summary>
        /// Identifies the total count of items in the connection.
        /// </summary>
        public int TotalCount { get; }

        /// <summary>
        /// The total size in kilobytes of all repositories in the connection.
        /// </summary>
        public int TotalDiskUsage { get; }

        internal static RepositoryConnection Create(IQueryProvider provider, Expression expression)
        {
            return new RepositoryConnection(provider, expression);
        }
    }
}