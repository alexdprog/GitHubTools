using System;
using System.Collections.Generic;
using System.Net.Http;

using GitHubTools.CoreApplication.Dto;
using GitHubTools.CoreApplication.Models;

namespace GitHubTools.Infrastructure.Interfaces
{
    /// <summary>
    /// построитель УРЛ
    /// </summary>
    public interface IUrlBuilder
    {

        /// <summary>
        /// получит URL для запроса общей информации о сервере
        /// </summary>
        /// <param name="userProfile">профиль пользователя</param>
        /// <returns>строка</returns>
        string GetUrlForLoadRepositories(UserProfile userProfile);

    }
}