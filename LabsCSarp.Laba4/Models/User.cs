using System;
using Postgrest.Attributes;
using Supabase;

namespace LabsCSharp.Laba4.Models
{
    public class User : SupabaseModel
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        [PrimaryKey("Id", false)]
        public Guid Id { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        [Column("Login")]
        public string Login { get; set; }

        /// <summary>
        /// Дата создания пользователя
        /// </summary>
        [Column("DateOfCreate")]
        public DateTime DateOfCreate { get; set; }
    }
}
