using System;
using Postgrest.Attributes;
using Supabase;

namespace LabsCharp.Laba4.Entities
{
    [Table("Users")]
    public class User : SupabaseModel
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        [PrimaryKey()]
        public Guid Id { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        [Column()]
        public string Login { get; set; }

        /// <summary>
        /// Дата создания пользователя
        /// </summary>
        [Column()]
        public DateTime DateOfCreate { get; set; }
    }
}
