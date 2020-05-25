using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Controller
{
    class SerializeDataSave : IDataSave
    {
        /// <summary>
        /// Сохранить объект в файл.
        /// </summary>
        /// <typeparam name="T"> Класс. </typeparam>
        /// <param name="fileName"> Имя файла. </param>
        /// <param name="obj"> Объект для сохранения. </param>
        public void Save<T>(string fileName, T obj) where T : class
        {
            var formatter = new BinaryFormatter();

            using (var stream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream, obj);
            }
        }
        /// <summary>
        /// Загрузить объекты из файла.
        /// </summary>
        /// <typeparam name="T"> Класс. </typeparam>
        /// <param name="fileName"> Имя файла. </param>
        /// <returns></returns>
        public List<T> Load<T>(string fileName) where T : class
        {
            var formatter = new BinaryFormatter();

            using (var stream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (stream.Length > 0 && formatter.Deserialize(stream) is List<T> list)
                {
                    return list;
                }
                else
                {
                    return new List<T>();
                }
            }
        }
    }
}
