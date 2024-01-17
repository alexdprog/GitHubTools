using GitHubTools.CoreApplication.Dto;
using GitHubTools.CoreApplication.Models;
using GitHubTools.Infrastructure.Interfaces;

namespace GitHubTools.Infrastructure.Connectivity
{
    /// <summary>
    /// Provider wrapper.
    /// </summary>
    public class DataProvider : IDataProvider
    {
        private readonly IUrlBuilder _urlBuilder;
        private readonly IServerAccess _serverAccess;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serverAccess">доступ к серверу</param>
        /// <param name="cacheManager">кэш</param>
        /// <param name="urlBuilder">построитель url</param>
        /// <param name="userProfileService">получение профиля пользователя</param>
        public DataProvider(
            IServerAccess serverAccess,
            IUrlBuilder urlBuilder)
        {
            _serverAccess = serverAccess;
            _urlBuilder = urlBuilder;
        }

        /// <inheritdoc />
        public async Task<ServerDataAccessResult<IList<RepositoryDto>>> LoadRepositories(UserProfile userProfile)
        {
            var url = _urlBuilder.GetUrlForLoadRepositories(userProfile);
            var result = await GetData<IList<RepositoryDto>>(url);
            return result;
        }

        /// <summary>
        /// Query data
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<ServerDataAccessResult<TResult>> GetData<TResult>(
            string url) where TResult : class
        {
            return await _serverAccess.GetData<TResult>(url);
        }
    }
}
