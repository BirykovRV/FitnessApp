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

            Console.WriteLine("Введите имя пользователя.");
            var userName = Console.ReadLine();
            Console.Clear();
            
            Console.WriteLine("Введите пол: ");
            var gender = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Введите дату рождения.");
            var birthDate = DateTime.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Введите вес.");
            var weight = double.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Введите рост.");
            var height = double.Parse(Console.ReadLine());
            Console.Clear();

            var userController = new UserController(userName, gender, birthDate, weight, height);
            userController.Save();

        }
    }
}
