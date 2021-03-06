namespace Octokit.GraphQL
{
    using System.Linq;

    /// <summary>
    /// Autogenerated input type of AddPullRequestReview
    /// </summary>
    public class AddPullRequestReviewInput
    {
        public string ClientMutationId { get; set; }

        public string PullRequestId { get; set; }

        public string Body { get; set; }

        public PullRequestReviewEvent? Event { get; set; }

        public IQueryable<DraftPullRequestReviewComment> Comments { get; set; }
    }
}