using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.University;
using MySql.Data.MySqlClient;
using WorkOk = Data.WorkOk;
using Astu = Data.Astu;
using Oracle.DataAccess.Client;

namespace University
{
    /// <summary>
    /// Сессия авторизованного пользователя
    /// </summary>
    public static class Session
    {

        static UniversityModel _data;

        /// <summary>
        /// Контекст базы данных
        /// </summary>
        public static UniversityModel Data
        {
            get
            {
                if (_data == null)
                {
                    throw new Exception("Контекст базы данных недоступен.");
                }
                return _data;
            }
        }

        /// <summary>
        /// Текущий пользователь приложения
        /// </summary>
        public static User CurrentUser { get; private set; }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public static bool Initialize(string username, string password)
        {
            // Подключаем контекст БД
            var data = new UniversityModel();
            var user = data.Users.Where(u => (u.Login == username) && (u.PasswordHash == password)).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            else
            {
                _data = data;
                CurrentUser = user;
                WorkOkAuth();
                AstuAuth();
                return true; 
            }
        }
        
        static bool WorkOkAuth()
        {
            var csb = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Port = 3306,
                Database = "work_ok",
                UserID = "emackovenko",
                Password = "trustno1",
                CharacterSet = "cp1251",
                ConvertZeroDateTime = true,
                
            };

            var connection = new MySqlConnection(csb.ToString());
            return WorkOk.Context.Auth(connection);
        }

        static void AstuAuth()
        {
            var connecion = new OracleConnection()
            {
                ConnectionString = "User Id=mackovenko_e;Server=10.0.1.3;Connection Timeout=0;Unicode=True;Service Name=ASTUMRSK"
            };
            connecion.Open();
        }
    }
}
