

using GitHubTools.Infrastructure.Enums;

namespace GitHubTools.Infrastructure.Connectivity
{
    /// <summary>
    /// ������� ������ ������ � ��������� ������ ������� �� ������ ���� ������
    /// � ������ �����. ������ ������� ����� ���� null, � ����� ���� � ������ ������ ������ �� ����
    /// </summary>
    /// <typeparam name="T">��� ����, ��� ������� ���������� � ������</typeparam>
    public class ServerDataAccessResult<T> where T : class
    {
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="value">��������</param>
        /// <param name="connectionResult">��������� ������� ���������� � ��������</param>
        public ServerDataAccessResult(T value, ConnectionResult connectionResult)
        {
            Value = value;
            ConnectionResult = connectionResult;
        }

        /// <summary>
        /// ��������
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// �������� ������� ����. � ��������
        /// </summary>
        public ConnectionResult ConnectionResult { get; set; }

        /// <summary>
        /// ������� ��
        /// </summary>
        public bool Success => ConnectionResult?.Status == ConnectionStatus.Success;
    }
}