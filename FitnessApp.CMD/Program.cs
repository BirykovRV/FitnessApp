using FitnessApp.BL.Controller;
using FitnessApp.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace FitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-RU");
            var resourceManager = new ResourceManager("FitnessApp.CMD.Languages.Message", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Greeting", culture));

            Console.Write(resourceManager.GetString("EnterName", culture));
            var userName = Console.ReadLine();

            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write(resourceManager.GetString("EnterGender", culture));
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("дату рождения");
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");
                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine(resourceManager.GetString("OptionQuestion", culture));
                Console.WriteLine(resourceManager.GetString("Option1", culture));
                Console.WriteLine(resourceManager.GetString("Option2", culture));
                Console.WriteLine(resourceManager.GetString("Option3", culture));
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var eating = EnterEating();

                        eatingController.Add(eating.Food, eating.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine("\t{0} - {1}", item.Key, item.Value);
                        }
                        break;
                    case ConsoleKey.A:
                        var exer = EnterExercise();                                                

                        exerciseController.Add(exer.Activity, exer.Begin, exer.End);

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine("\t{0} - {1} по {2}", item.Activity.Name, item.Star.ToShortTimeString(), item.Finish.ToShortTimeString());
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static (Activity Activity, DateTime Begin, DateTime End) EnterExercise()
        {
            Console.Write("Введите название упражнения: ");
            var activityName = Console.ReadLine();
            var energy = ParseDouble("расход энергии в минуту");
            var begin = ParseDateTime("время начала упражнения");
            var end = ParseDateTime("время окончания упражнения");
            var activity = new Activity(activityName, energy);

            return (activity, begin, end);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("EnterProductName");
            var foodName = Console.ReadLine();

            var proteins = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbohydrates = ParseDouble("углеводы");
            var calories = ParseDouble("калории");

            var food = new Food(foodName, proteins, fats, carbohydrates, calories);
            var weight = ParseDouble("вес порции");

            return (Food: food, Weight: weight);
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Введите {value} : ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}.");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
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
