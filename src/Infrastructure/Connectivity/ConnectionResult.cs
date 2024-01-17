using System;

using GitHubTools.Infrastructure.Enums;

namespace GitHubTools.Infrastructure.Connectivity
{
    /// <summary>
    /// Operation result.
    /// </summary>
    public class ConnectionResult
    {
        private string _message;

        /// <summary>
        /// Common status
        /// </summary>
        public ConnectionStatus Status { get; set; }

        /// <summary>
        /// Exception.
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Message.
        /// </summary>
        public string Message
        {
            get => _message ?? Exception?.Message;
            internal set => _message = value;
        }

        /// <summary>
        /// Create success result
        /// </summary>
        /// <returns>Success result/returns>
        public static ConnectionResult Success()
        {
            return new ConnectionResult { Status = ConnectionStatus.Success };
        }
    }
}
