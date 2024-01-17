using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;

using GitHubTools.CoreApplication.Dto;
using GitHubTools.CoreApplication.Models;
using GitHubTools.Infrastructure.Interfaces;

namespace GitHubTools.Infrastructure.Connectivity
{
    /// <summary>
    /// реализация построителя Url
    /// </summary>
    public class UrlBuilder : IUrlBuilder
    {
        /// <summary>
        /// Получение адреса для запроса текущих данных из счетчика
        /// </summary>
        /// <remarks>PowerGridMonitoring/LoadClientCurrentValues</remarks>
        /// <param name="nodeId"></param>
        /// <param name="requestScan"></param>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        public string GetUrlForLoadRepositories(UserProfile userProfile)
        {
            string url = $"https://api.github.com/users/{userProfile.UserName}/repos";
            return url;
        }
    }
}
