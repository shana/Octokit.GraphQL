namespace Octokit.GraphQL
{
    using System.Linq;
    using System.Linq.Expressions;
    using Octokit.GraphQL.Core;
    using Octokit.GraphQL.Core.Builders;

    /// <summary>
    /// A review object for a given pull request.
    /// </summary>
    public class PullRequestReview : QueryEntity
    {
        public PullRequestReview(IQueryProvider provider, Expression expression) : base(provider, expression)
        {
        }

        /// <summary>
        /// The actor who authored the comment.
        /// </summary>
        public IActor Author => this.CreateProperty(x => x.Author, Octokit.GraphQL.Internal.StubIActor.Create);

        /// <summary>
        /// Identifies the pull request review body.
        /// </summary>
        public string Body { get; }

        /// <summary>
        /// The body of this review rendered to HTML.
        /// </summary>
        public string BodyHTML { get; }

        /// <summary>
        /// The body of this review rendered as plain text.
        /// </summary>
        public string BodyText { get; }

        /// <summary>
        /// A list of review comments for the current pull request review.
        /// </summary>
        /// <param name="first">Returns the first _n_ elements from the list.</param>
        /// <param name="after">Returns the elements in the list that come after the specified global ID.</param>
        /// <param name="last">Returns the last _n_ elements from the list.</param>
        /// <param name="before">Returns the elements in the list that come before the specified global ID.</param>
        public PullRequestReviewCommentConnection Comments(int? first = null, string after = null, int? last = null, string before = null) => this.CreateMethodCall(x => x.Comments(first, after, last, before), Octokit.GraphQL.PullRequestReviewCommentConnection.Create);

        /// <summary>
        /// Identifies the commit associated with this pull request review.
        /// </summary>
        public Commit Commit => this.CreateProperty(x => x.Commit, Octokit.GraphQL.Commit.Create);

        /// <summary>
        /// Identifies the date and time when the object was created.
        /// </summary>
        public string CreatedAt { get; }

        /// <summary>
        /// Check if this comment was created via an email reply.
        /// </summary>
        public bool CreatedViaEmail { get; }

        /// <summary>
        /// Identifies the primary key from the database.
        /// </summary>
        public int? DatabaseId { get; }

        /// <summary>
        /// The actor who edited the comment.
        /// </summary>
        public IActor Editor => this.CreateProperty(x => x.Editor, Octokit.GraphQL.Internal.StubIActor.Create);

        public string Id { get; }

        /// <summary>
        /// The moment the editor made the last edit
        /// </summary>
        public string LastEditedAt { get; }

        /// <summary>
        /// The HTTP URL permalink for this PullRequestReview.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Identifies when the comment was published at.
        /// </summary>
        public string PublishedAt { get; }

        /// <summary>
        /// Identifies the pull request associated with this pull request review.
        /// </summary>
        public PullRequest PullRequest => this.CreateProperty(x => x.PullRequest, Octokit.GraphQL.PullRequest.Create);

        /// <summary>
        /// The repository associated with this node.
        /// </summary>
        public Repository Repository => this.CreateProperty(x => x.Repository, Octokit.GraphQL.Repository.Create);

        /// <summary>
        /// The HTTP URL permalink for this PullRequestReview.
        /// </summary>
        public string ResourcePath { get; }

        /// <summary>
        /// Identifies the current state of the pull request review.
        /// </summary>
        public PullRequestReviewState State { get; }

        /// <summary>
        /// Identifies when the Pull Request Review was submitted
        /// </summary>
        public string SubmittedAt { get; }

        /// <summary>
        /// Identifies the date and time when the object was last updated.
        /// </summary>
        public string UpdatedAt { get; }

        /// <summary>
        /// The HTTP URL permalink for this PullRequestReview.
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Check if the current viewer can delete this object.
        /// </summary>
        public bool ViewerCanDelete { get; }

        /// <summary>
        /// Check if the current viewer can update this object.
        /// </summary>
        public bool ViewerCanUpdate { get; }

        /// <summary>
        /// Reasons why the current viewer can not update this comment.
        /// </summary>
        public IQueryable<CommentCannotUpdateReason> ViewerCannotUpdateReasons => this.CreateProperty(x => x.ViewerCannotUpdateReasons);

        /// <summary>
        /// Did the viewer author this comment.
        /// </summary>
        public bool ViewerDidAuthor { get; }

        internal static PullRequestReview Create(IQueryProvider provider, Expression expression)
        {
            return new PullRequestReview(provider, expression);
        }
    }
}