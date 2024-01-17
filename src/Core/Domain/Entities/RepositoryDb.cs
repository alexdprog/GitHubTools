namespace GitHubTools.Domain.Entities
{
    /// <summary>
    /// Class of repository entity.
    /// </summary>
    public class RepositoryDb
    {
        public int Id { get; set; }
        public string NodeId { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string HtmlUrl { get; set; }
        public string? Description { get; set; }
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime pushed_at { get; set; }
        public string GitUrl { get; set; }
        public string? Language { get; set; }
        public string Visibility { get; set; }
        public string DefaultBranch { get; set; }
        
        public OwnerDb Parent { get; set; }

        /// <summary>
        /// Constructor/
        /// </summary>
        public RepositoryDb()
        {

        }
    }
}
