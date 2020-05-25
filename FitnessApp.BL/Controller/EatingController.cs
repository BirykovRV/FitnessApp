using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Controller
{
    public class EatingController : BaseController
    {
        private const string FOODS_FILE_NAME = "foods.dat";
        private User user;
        private const string EATING_FILE_NAME = "eatings.dat";

        public List<Food> Foods { get; }
        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть null.", nameof(user));

            Foods = GetAllFoods();
            Eating = GetEating();
        }
        /// <summary>
        /// Добавить продукт и вес в список еды.
        /// </summary>
        /// <param name="food"> Тип еды. </param>
        /// <param name="weight"> Вес. </param>
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);

            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                SaveFoods();
            }
            else
            {
                Eating.Add(product, weight);
                SaveFoods();
            }
        }

        private List<Eating> GetEating()
        {
            return Load<Eating>(EATING_FILE_NAME) ?? new List<Eating>();
        }

        private List<Food> GetAllFoods()
        {
            return Load<Food>(FOODS_FILE_NAME) ?? new List<Food>();
        }

        private void SaveFoods()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATING_FILE_NAME, Eating);
        }

    }
}
