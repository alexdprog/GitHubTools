namespace GitHubTools.CoreApplication.Models
{
    /// <summary>
    /// Repository class.
    /// </summary>
    public class Repository
    {
        /// <summary>
        /// Id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// NodeId.
        /// </summary>
        public string NodeId { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Full name.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Html Url.
        /// </summary>
        public string HtmlUrl { get; set; }

        /// <summary>
        /// description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Created at.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Updated at.
        /// </summary>
        public DateTime updated_at { get; set; }

        /// <summary>
        /// Pushed at.
        /// </summary>
        public DateTime pushed_at { get; set; }

        /// <summary>
        /// Git Url.
        /// </summary>
        public string GitUrl { get; set; }

        /// <summary>
        /// Language
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Visibility.
        /// </summary>
        public string Visibility { get; set; }

        /// <summary>
        /// default branch.
        /// </summary>
        public string DefaultBranch { get; set; }

        public Repository()
        {

        }
    }
}
