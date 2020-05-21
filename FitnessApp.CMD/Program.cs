using FitnessApp.BL.Controller;
using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в приложение FitnessApp.");

            Console.Write("Введите имя пользователя: ");
            var userName = Console.ReadLine();

            var userController = new UserController(userName);
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");                
                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.ReadLine();
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Введите дату рождения (dd.mm.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения.");
                }
            }

            return birthDate;
        }

        private static float ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (float.TryParse(Console.ReadLine(), out float value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Неверный формат {0}.", name);
                }
            }
        }
    }
}
