using System.Collections.Generic;

namespace FitnessApp.BL.Controller
{
    public interface IDataSave
    {
        void Save<T>(string fileName, T item) where T : class;
        List<T> Load<T>(string fileName) where T : class;

    }
}
