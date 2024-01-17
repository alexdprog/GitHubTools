

namespace GitHubTools.Infrastructure.Enums
{
    /// <summary>
    /// Operation status
    /// </summary>
    public enum ConnectionStatus
    {
        /// <summary>
        /// Не предпринималось
        /// </summary>
        NotAttempted = 0,

        /// <summary>
        /// Success
        /// </summary>
        Success = 1,

        /// <summary>
        /// аутентификация не прошла
        /// </summary>
        AuthenticationFailed = 2,

        /// <summary>
        /// что-то пошло не так, не связанное с аутентификацией
        /// </summary>
        GeneralFailure = 3,

        /// <summary>
        /// подключение отменено
        /// </summary>
        Cancelled = 4,

        /// <summary>
        /// доступ к ресурсу запрещен
        /// </summary>
        Forbidden = 5,
        /// <summary>
        /// вообще нет сетевого подключения
        /// </summary>
        NoNetwork = 6,
        /// <summary>
        /// с сервера пришел ответ в неожиданном формате
        /// </summary>
        DataFormatUnexpected = 7,
        /// <summary>
        /// связь с сервером есть, но запрашиваемые данные отсутствуют
        /// </summary>
        NotFound = 8
    }
}
