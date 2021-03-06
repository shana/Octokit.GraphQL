namespace Octokit.GraphQL
{
    using System.Linq;
    using System.Linq.Expressions;
    using Octokit.GraphQL.Core;
    using Octokit.GraphQL.Core.Builders;

    /// <summary>
    /// Entities that can be subscribed to for web and email notifications.
    /// </summary>
    public interface ISubscribable : IQueryEntity
    {
        /// <summary>
        /// Check if the viewer is able to change their subscription status for the repository.
        /// </summary>
        bool ViewerCanSubscribe { get; }

        /// <summary>
        /// Identifies if the viewer is watching, not watching, or ignoring the repository.
        /// </summary>
        SubscriptionState ViewerSubscription { get; }
    }
}

namespace Octokit.GraphQL.Internal
{
    using System.Linq;
    using System.Linq.Expressions;
    using Octokit.GraphQL.Core;
    using Octokit.GraphQL.Core.Builders;

    internal class StubISubscribable : QueryEntity, ISubscribable
    {
        public StubISubscribable(IQueryProvider provider, Expression expression) : base(provider, expression)
        {
        }

        public bool ViewerCanSubscribe { get; }

        public SubscriptionState ViewerSubscription { get; }

        internal static StubISubscribable Create(IQueryProvider provider, Expression expression)
        {
            return new StubISubscribable(provider, expression);
        }
    }
}