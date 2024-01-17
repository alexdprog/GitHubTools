using GitHubTools.Infrastructure.Connectivity;

namespace GitHubTools.Infrastructure.Interfaces
{
    /// <summary>
    /// Class for query data from server.
    /// </summary>
    public interface IServerAccess
    {
        /// <summary>
        /// Get datat from server/
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="url">Url of resource</param>
        /// <returns>Response</returns>
        Task<ServerDataAccessResult<T>> GetData<T>(string url) where T : class;

    }
}
