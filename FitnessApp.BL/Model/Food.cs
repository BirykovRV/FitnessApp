using System;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Еда.
    /// </summary>
    [Serializable]
    public class Food
    {
        public int Id { get; set; }
        #region Свойства

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; set; }
        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; set; }
        /// <summary>
        /// Калории за 100 г.
        /// </summary>
        public double Calories { get; set; }
        #endregion
        /// <summary>
        /// Создать новую еду.
        /// </summary>
        /// <param name="name"> Имя продукта. </param>
        public Food(string name) : this(name, 0, 0, 0, 0)
        {            
        }
        /// <summary>
        /// Создать новую еду.
        /// </summary>
        /// <param name="name"> Имя продукта. </param>
        /// <param name="proteins"> Протеины. </param>
        /// <param name="fats"> Жиры. </param>
        /// <param name="carbohydrates"> Углеводы. </param>
        /// <param name="calories"> Калории. </param>
        public Food(string name, double proteins, double fats, double carbohydrates, double calories)
        {
            #region Проверки

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя еды не может быть пустым или null.", nameof(name));
            }
            if (proteins < 0)
            {
                throw new ArgumentException("Протеины не могут быть меньше нуля.", nameof(proteins));
            }
            if (fats < 0)
            {
                throw new ArgumentException("Жиры не могут быть меньше нуля.", nameof(fats));
            }
            if (carbohydrates < 0)
            {
                throw new ArgumentException("Углеводы не могут быть меньше нуля.", nameof(carbohydrates));
            }
            if (calories < 0)
            {
                throw new ArgumentException("Калории не могут быть меньше нуля.", nameof(calories));
            }
            #endregion

            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
