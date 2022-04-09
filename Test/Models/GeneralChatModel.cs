using System;

namespace Test.Models
{
    public class GeneralChatModel
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Текст сообщения пользователя
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Время, когда пользователь отправил сообщение
        /// </summary>
        public DateTime SendingTime { get; set; }
    }
}
