namespace Octokit.GraphQL
{
    using System.Linq;
    using System.Linq.Expressions;
    using Octokit.GraphQL.Core;
    using Octokit.GraphQL.Core.Builders;

    /// <summary>
    /// Represents an object which can take actions on GitHub. Typically a User or Bot.
    /// </summary>
    public interface IActor : IQueryEntity
    {
        /// <summary>
        /// A URL pointing to the actor's public avatar.
        /// </summary>
        /// <param name="size">The size of the resulting square image.</param>
        string AvatarUrl(int? size = null);

        /// <summary>
        /// The username of the actor.
        /// </summary>
        string Login { get; }

        /// <summary>
        /// The path to this actor.
        /// </summary>
        string Path { get; }
    }
}

namespace Octokit.GraphQL.Internal
{
    using System.Linq;
    using System.Linq.Expressions;
    using Octokit.GraphQL.Core;
    using Octokit.GraphQL.Core.Builders;

    internal class StubIActor : QueryEntity, IActor
    {
        public StubIActor(IQueryProvider provider, Expression expression) : base(provider, expression)
        {
        }

        public string AvatarUrl(int? size = null) => null;

        public string Login { get; }

        public string Path { get; }

        internal static StubIActor Create(IQueryProvider provider, Expression expression)
        {
            return new StubIActor(provider, expression);
        }
    }
}