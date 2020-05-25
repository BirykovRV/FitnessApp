using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.BL.Controller
{
    public abstract class BaseController
    {
        protected IDataSave dataSave = new DatabaseDataSave();
        /// <summary>
        /// Сохранить объект в файл.
        /// </summary>
        /// <typeparam name="T"> Класс. </typeparam>
        /// <param name="fileName"> Имя файла. </param>
        /// <param name="obj"> Объект для сохранения. </param>
        protected void Save<T>(string fileName, T obj) where T : class
        {
            dataSave.Save(fileName, obj);
        }
        /// <summary>
        /// Загрузить объекты из файла.
        /// </summary>
        /// <typeparam name="T"> Класс. </typeparam>
        /// <param name="fileName"> Имя файла. </param>
        /// <returns></returns>
        protected List<T> Load<T>(string fileName) where T : class
        {
            return dataSave.Load<T>(fileName);
        }
    }
}
