namespace Octokit.GraphQL
{
    using System.Linq;

    /// <summary>
    /// Autogenerated input type of AddPullRequestReviewComment
    /// </summary>
    public class AddPullRequestReviewCommentInput
    {
        public string ClientMutationId { get; set; }

        public string PullRequestReviewId { get; set; }

        public string CommitOID { get; set; }

        public string Body { get; set; }

        public string Path { get; set; }

        public int? Position { get; set; }

        public string InReplyTo { get; set; }
    }
}