

using GitHubTools.Infrastructure.Enums;

namespace GitHubTools.Infrastructure.Connectivity
{
    /// <summary>
    /// обертка вокруг данных с описанием ответа сервера на запрос этих данных
    /// В случае отриц. ответа сервера может быть null, а может быть и порция старых данных из кэша
    /// </summary>
    /// <typeparam name="T">тип того, что реально содержится в ответе</typeparam>
    public class ServerDataAccessResult<T> where T : class
    {
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="value">значение</param>
        /// <param name="connectionResult">результат попытки соединения с сервером</param>
        public ServerDataAccessResult(T value, ConnectionResult connectionResult)
        {
            Value = value;
            ConnectionResult = connectionResult;
        }

        /// <summary>
        /// Значение
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// описание попытки соед. с сервером
        /// </summary>
        public ConnectionResult ConnectionResult { get; set; }

        /// <summary>
        /// успешно ли
        /// </summary>
        public bool Success => ConnectionResult?.Status == ConnectionStatus.Success;
    }
}