using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubTools.CoreApplication.Enums
{
    /// <summary>
    /// тип оповещения
    /// </summary>
    public enum NotificationType
    {
        /// <summary>
        /// Успех
        /// </summary>
        Success = 0,
        /// <summary>
        /// нейтральная информация
        /// </summary>
        Information = 1,
        /// <summary>
        /// предупреждение/ошибка
        /// </summary>
        Warning = 2
    }
}
