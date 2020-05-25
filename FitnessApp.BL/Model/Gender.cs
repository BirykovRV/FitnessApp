using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Класс для создания пола.
    /// </summary>
    [Serializable]
    public class Gender
    {
        public int Id { get; set; }
        /// <summary>
        /// Имя пола.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Создать новый пол.
        /// </summary>
        /// <param name="name">Имя пола.</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null.", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
