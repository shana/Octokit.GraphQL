namespace Octokit.GraphQL
{
    using System.Linq;
    using System.Linq.Expressions;
    using Octokit.GraphQL.Core;
    using Octokit.GraphQL.Core.Builders;

    /// <summary>
    /// Represents a Git reference.
    /// </summary>
    public class Ref : QueryEntity
    {
        public Ref(IQueryProvider provider, Expression expression) : base(provider, expression)
        {
        }

        /// <summary>
        /// A list of pull requests with this ref as the head ref.
        /// </summary>
        /// <param name="first">Returns the first _n_ elements from the list.</param>
        /// <param name="after">Returns the elements in the list that come after the specified global ID.</param>
        /// <param name="last">Returns the last _n_ elements from the list.</param>
        /// <param name="before">Returns the elements in the list that come before the specified global ID.</param>
        /// <param name="states">A list of states to filter the pull requests by.</param>
        public PullRequestConnection AssociatedPullRequests(int? first = null, string after = null, int? last = null, string before = null, IQueryable<PullRequestState> states = null) => this.CreateMethodCall(x => x.AssociatedPullRequests(first, after, last, before, states), Octokit.GraphQL.PullRequestConnection.Create);

        public string Id { get; }

        /// <summary>
        /// The ref name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The ref's prefix, such as `refs/heads/` or `refs/tags/`.
        /// </summary>
        public string Prefix { get; }

        /// <summary>
        /// The repository the ref belongs to.
        /// </summary>
        public Repository Repository => this.CreateProperty(x => x.Repository, Octokit.GraphQL.Repository.Create);

        /// <summary>
        /// The object the ref points to.
        /// </summary>
        public IGitObject Target => this.CreateProperty(x => x.Target, Octokit.GraphQL.Internal.StubIGitObject.Create);

        internal static Ref Create(IQueryProvider provider, Expression expression)
        {
            return new Ref(provider, expression);
        }
    }
}