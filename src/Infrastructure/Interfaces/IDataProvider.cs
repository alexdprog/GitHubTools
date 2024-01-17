using GitHubTools.CoreApplication.Dto;
using GitHubTools.CoreApplication.Models;
using GitHubTools.Infrastructure.Connectivity;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace GitHubTools.Infrastructure.Interfaces
{
    /// <summary>
    /// контракт поставщика серверных данных для приложения
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// Загрузить список репозиториев
        /// </summary>
        /// <param name="request">параметры запроса</param>
        /// <param name="forceUpdate">параметр принудительного обновления с сервера</param>
        /// <returns>список доступных счетчиков</returns>
        Task<ServerDataAccessResult<IList<RepositoryDto>>> LoadRepositories(UserProfile userProfile);

        //Task<ServerDataAccessResult<ClientCurrentValues>> LoadClientCurrentValuesData(long nodeId, bool requestScan, bool forceUpdate = false);
    }
}
