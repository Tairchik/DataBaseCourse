using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainModule
{
    public class UserSettingsModel
    {
        public string FontFamily { get; set; } = "Segoe UI"; // Значение по умолчанию
        public int FontSize { get; set; } = 9;              // Значение по умолчанию

        public Font GetFont()
        {
            try
            {
                return new Font(FontFamily, FontSize, FontStyle.Regular);
            }
            catch
            {
                // Возвращаем шрифт по умолчанию в случае ошибки
                return new Font("Segoe UI", 9, FontStyle.Regular);
            }
        }

        public class SettingsRepository
        {
            // Имя файла базы данных (должно быть в корне приложения или указан полный путь)
            private const string DatabaseFileName = "Login.db";

            // Строка подключения к базе данных SQLite
            private readonly string _connectionString = $"Data Source={DatabaseFileName};Version=3;";

            public SettingsRepository()
            {
                // Простая проверка на существование файла
                if (!File.Exists(DatabaseFileName))
                {
                    
                }
            }

            /// <summary>
            /// Загружает настройки шрифта для указанного пользователя.
            /// Если настроек нет, возвращает значения по умолчанию.
            /// </summary>
            /// <param name="userId">ID пользователя</param>
            /// <returns>Объект UserSettingsModel</returns>
            public UserSettingsModel GetSettings(int userId)
            {
                var settings = new UserSettingsModel(); // Настройки по умолчанию
                string sql = "SELECT font_family, font_size FROM UserSettings WHERE id_user = @UserId";

                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqliteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Если запись найдена, загружаем значения
                                settings.FontFamily = reader["font_family"].ToString();
                                settings.FontSize = Convert.ToInt32(reader["font_size"]);
                            }
                        }
                    }
                }
                return settings;
            }

            /// <summary>
            /// Сохраняет или обновляет настройки шрифта для пользователя.
            /// Использует INSERT OR REPLACE для выполнения UPSERT-операции.
            /// </summary>
            /// <param name="userId">ID пользователя</param>
            /// <param name="fontFamily">Имя шрифта</param>
            /// <param name="fontSize">Размер шрифта</param>
            public void SaveSettings(int userId, string fontFamily, int fontSize)
            {
                // Запрос использует INSERT OR REPLACE, который либо вставляет новую запись,
                // либо заменяет существующую, если ключ (id_user) уже есть.
                string sql = @"
                INSERT OR REPLACE INTO UserSettings (id_user, font_family, font_size)
                VALUES (@UserId, @FontFamily, @FontSize)"
                ;

                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqliteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@FontFamily", fontFamily);
                        command.Parameters.AddWithValue("@FontSize", fontSize);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
