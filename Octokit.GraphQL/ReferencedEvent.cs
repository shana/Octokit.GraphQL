namespace Octokit.GraphQL
{
    using System.Linq;
    using System.Linq.Expressions;
    using Octokit.GraphQL.Core;
    using Octokit.GraphQL.Core.Builders;

    /// <summary>
    /// Represents a 'referenced' event on a given `ReferencedSubject`.
    /// </summary>
    public class ReferencedEvent : QueryEntity
    {
        public ReferencedEvent(IQueryProvider provider, Expression expression) : base(provider, expression)
        {
        }

        /// <summary>
        /// Identifies the actor who performed the 'label' event.
        /// </summary>
        public IActor Actor => this.CreateProperty(x => x.Actor, Octokit.GraphQL.Internal.StubIActor.Create);

        /// <summary>
        /// Identifies the commit associated with the 'referenced' event.
        /// </summary>
        public Commit Commit => this.CreateProperty(x => x.Commit, Octokit.GraphQL.Commit.Create);

        /// <summary>
        /// Identifies the repository associated with the 'referenced' event.
        /// </summary>
        public Repository CommitRepository => this.CreateProperty(x => x.CommitRepository, Octokit.GraphQL.Repository.Create);

        /// <summary>
        /// Identifies the date and time when the object was created.
        /// </summary>
        public string CreatedAt { get; }

        public string Id { get; }

        /// <summary>
        /// Reference originated in a different repository.
        /// </summary>
        public bool IsCrossReference { get; }

        /// <summary>
        /// Object referenced by event.
        /// </summary>
        public ReferencedSubject Subject => this.CreateProperty(x => x.Subject, Octokit.GraphQL.ReferencedSubject.Create);

        internal static ReferencedEvent Create(IQueryProvider provider, Expression expression)
        {
            return new ReferencedEvent(provider, expression);
        }
    }
}