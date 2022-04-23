using System;
using Postgrest.Attributes;
using Supabase;

namespace Test.Entities
{
    /// <summary>
    /// Модель таблицы HistoryChat, где хранятся сообщения пользователей чата
    /// </summary>
    public class HistoryChat : SupabaseModel
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        [Column]
        public Guid UserId { get; set; }

        /// <summary>
        /// Текст сообщения пользователя
        /// </summary>
        [Column]
        public string Text { get; set; }

        /// <summary>
        /// Время, когда пользователь отправил сообщение
        /// </summary>
        [Column]
        public DateTime SendingTime { get; set; }

        /// <summary>
        /// Ссылка на юзера
        /// </summary>
        public User User { get; set; }
    }
}
