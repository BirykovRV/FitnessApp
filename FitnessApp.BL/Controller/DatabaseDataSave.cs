using FitnessApp.BL.Model;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Controller
{
    class DatabaseDataSave : IDataSave
    {
        public List<T> Load<T>(string fileName) where T : class
        {
            using (var db = new FitnessContext())
            {
                return db.Set<T>().ToList();
            }
        }

        public void Save<T>(string fileName, T item) where T : class
        {
            using (var db = new FitnessContext())
            {
                if (item is List<User>)
                {
                    db.Users.AddRange(item as List<User>);
                }
                if (item is List<Food>)
                {
                    db.Foods.AddRange(item as List<Food>);
                }
                if (item is Eating)
                {
                    db.Eatings.Add(item as Eating);
                }
                if (item is Gender)
                {
                    db.Genders.Add(item as Gender);
                }
                db.SaveChanges();
            }
        }
    }
}
