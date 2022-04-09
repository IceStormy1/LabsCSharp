using System;
using Postgrest.Attributes;
using Supabase;

namespace Test.Models
{
    /// <summary>
    /// Модель таблицы HistoryChat, где хранятся сообщения пользователей чата
    /// </summary>
    public class HistoryChat : SupabaseModel
    {
        [PrimaryKey("Id", false)]
        public Guid Id { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        [Column("UserId")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Текст сообщения пользователя
        /// </summary>
        [Column("Text")]
        public string Text { get; set; }

        /// <summary>
        /// Время, когда пользователь отправил сообщение
        /// </summary>
        [Column("SendingTime")]
        public DateTime SendingTime { get; set; }

        /// <summary>
        /// Ссылка на юзера
        /// </summary>
        public User User { get; set; }
    }
}
