namespace Octokit.GraphQL
{
    using System.Linq;
    using System.Linq.Expressions;
    using Octokit.GraphQL.Core;
    using Octokit.GraphQL.Core.Builders;

    /// <summary>
    /// Autogenerated return type of AddProjectCard
    /// </summary>
    public class AddProjectCardPayload : QueryEntity
    {
        public AddProjectCardPayload(IQueryProvider provider, Expression expression) : base(provider, expression)
        {
        }

        /// <summary>
        /// The edge from the ProjectColumn's card connection.
        /// </summary>
        public ProjectCardEdge CardEdge => this.CreateProperty(x => x.CardEdge, Octokit.GraphQL.ProjectCardEdge.Create);

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; }

        /// <summary>
        /// The ProjectColumn
        /// </summary>
        public Project ProjectColumn => this.CreateProperty(x => x.ProjectColumn, Octokit.GraphQL.Project.Create);

        internal static AddProjectCardPayload Create(IQueryProvider provider, Expression expression)
        {
            return new AddProjectCardPayload(provider, expression);
        }
    }
}