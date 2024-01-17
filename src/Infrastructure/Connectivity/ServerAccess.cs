using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using GitHubTools.CoreApplication.Models;
using GitHubTools.Infrastructure.Connectivity;
using GitHubTools.Infrastructure.Enums;
using GitHubTools.Infrastructure.Interfaces;
using Newtonsoft.Json;

namespace GitHubTools.Infrastructure.Connectivity
{
    /// <summary>
    /// класс ответственный за общение с сервером
    /// нуждается в весьма серьезной доработке
    /// а именно:
    /// - попытки переподключения на сетевых ошибках
    /// - возможность работы БЕЗ сервера некоторое время на данных из кэша (игнорируя их устаревание), включая и отправку показаний (когда она будет): для последнего нужна очередь "посылок" на сервер в БД
    ///  Желательно также заменить стандартный клиент на что-то иное (FlUrl, RestSharp,...)
    /// </summary>
    public class ServerAccess : IServerAccess
    {
        private static readonly Regex TokenRegex =
            new Regex(
                "<input name=\"__RequestVerificationToken\".*?value=\"(?<token>[^\"]+)\"",
                RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

        private HttpClient _httpClient;

        private readonly JsonSerializerSettings _jsSettings;

        private volatile string _jwtToken;
        private JsonSerializer _serializer;

        //private const string AuthCookieName = ".ASPXAUTH";

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="userProfileService">доступ к профилю пользователя</param>
        /// <param name="exceptionHandler">обработка исключений</param>
        /// <param name="urlBuilder">построитель urlov</param>
        /// <param name="logger">протоколирование</param>
        /// <param name="jsSettings">настройки сериализатора глобальные</param>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope",
            Justification = "it is a class field, disposed in Dispose")]
        public ServerAccess()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));//.Add("Accept", "application/vnd.github+json");
             _httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
            _serializer = JsonSerializer.Create(_jsSettings);
        }

        /// <inheritdoc/>
        public async Task<ServerDataAccessResult<T>> GetData<T>(
            string url) where T : class
        {
            var response = await GetDataAsJson<T>(url);
            if (response.ConnectionResult.Status != ConnectionStatus.Success)
            {
                var res = new ServerDataAccessResult<T>(null, response.ConnectionResult);
                return res;
            }
            return response;
        }

        private async Task<HttpResponseMessage> RetrieveDataGuarded(Func<Task<HttpResponseMessage>> actualInteraction)
        {
            var response = await actualInteraction();
            return response;
        }

        private async Task<ServerDataAccessResult<T>> CheckAndParseServerResponse<T>(HttpResponseMessage response) where T : class
        {
            ConnectionResult cResult = new ConnectionResult();
           
            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    cResult.Status = ConnectionStatus.AuthenticationFailed;
                    return new ServerDataAccessResult<T>(null, cResult);
                case HttpStatusCode.Forbidden:
                    cResult.Status = ConnectionStatus.Forbidden;
                    return new ServerDataAccessResult<T>(null, cResult);
                case HttpStatusCode.NotFound:
                    cResult.Status = ConnectionStatus.NotFound;
                    return new ServerDataAccessResult<T>(null, cResult);
            }
            try
            {
                response.EnsureSuccessStatusCode();
                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                using (var jsonReader = new JsonTextReader(reader))
                {
                    try
                    {
                        return new ServerDataAccessResult<T>(
                                _serializer.Deserialize<T>(jsonReader), ConnectionResult.Success());
                    }
                    catch (JsonException exception)
                    {
                        return new ServerDataAccessResult<T>(
                            null,
                            new ConnectionResult { Exception = exception, Status = ConnectionStatus.DataFormatUnexpected });
                    }
                    catch (Exception eComm)
                    {
                        var a = eComm.Message;
                        return new ServerDataAccessResult<T>(
                            null,
                            new ConnectionResult { Exception = eComm, Status = ConnectionStatus.DataFormatUnexpected });
                    }
                }
            }
            catch (Exception exception)
            {
                //_exceptionHandler.HandleAndSwallow(exception, "Error on checking and reading response");
                cResult.Status = ConnectionStatus.GeneralFailure;
                cResult.Exception = exception;
                return new ServerDataAccessResult<T>(null, cResult);
            }
        }

        private async Task<ServerDataAccessResult<T>> GetDataAsJson<T>(string uri) where T : class
        {
            ConnectionResult cResult = new ConnectionResult();
            try
            {
                var response = await _httpClient.GetAsync(uri);
                return await CheckAndParseServerResponse<T>(response);
            }
            catch (HttpRequestException ex) when (ex.InnerException is WebException webException && webException.Status == WebExceptionStatus.NameResolutionFailure)
            {
                cResult.Status = ConnectionStatus.NotFound;
                return new ServerDataAccessResult<T>(null, cResult);
            }
            catch (Exception exception)
            {
                //_exceptionHandler.HandleAndSwallow(exception, "Error on GetData");
                cResult.Status = ConnectionStatus.GeneralFailure;
                cResult.Exception = exception;
                return new ServerDataAccessResult<T>(null, cResult);
            }
        }

        bool IgnoreSSl { get; set; }

        private HttpClient CreateHttpClient()
        {
            var cookieContainer = new CookieContainer();
            HttpClientHandler clientHandler = new HttpClientHandler { CookieContainer = cookieContainer };

            if (IgnoreSSl) {
                clientHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, error) => true;
            }
            HttpClient httpClient = new HttpClient(clientHandler);

            return httpClient;
        }
    }
}
