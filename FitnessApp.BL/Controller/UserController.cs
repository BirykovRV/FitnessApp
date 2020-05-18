using FitnessApp.BL.Model;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Создание нового контролера пользователя.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        public UserController(string userName, string genderName, DateTime birthDate, double weight, double height)
        {
            // TODO: Проверка
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDate, weight, height);            
        }
        /// <summary>
        /// Загрузить данные пользователя.
        /// </summary>
        /// <returns> Пользователь приложения. </returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
            }
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }        
    }
}
