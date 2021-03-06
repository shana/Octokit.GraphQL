namespace Octokit.GraphQL
{
    using System.Linq;

    /// <summary>
    /// Autogenerated input type of MoveProjectCard
    /// </summary>
    public class MoveProjectCardInput
    {
        public string ClientMutationId { get; set; }

        public string CardId { get; set; }

        public string ColumnId { get; set; }

        public string AfterCardId { get; set; }
    }
}