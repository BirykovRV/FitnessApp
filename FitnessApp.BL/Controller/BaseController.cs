using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.BL.Controller
{
    public abstract class BaseController
    {
        /// <summary>
        /// Сохранить объект в файл.
        /// </summary>
        /// <typeparam name="T"> Класс. </typeparam>
        /// <param name="fileName"> Имя файла. </param>
        /// <param name="obj"> Объект для сохранения. </param>
        protected void Save<T>(string fileName, T obj)
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
        protected T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();

            using (var stream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (stream.Length > 0 && formatter.Deserialize(stream) is T list)
                {
                    return list;
                }
                else
                {
                    return default(T);
                }
            }
        }
    }
}
