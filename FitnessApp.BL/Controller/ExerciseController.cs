using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Controller
{
    public class ExerciseController : BaseController
    {
        private const string EXERCISES_FILE_NAME = "exercises.dat";
        private const string ACTIVITIES_FILE_NAME = "activities.dat";
        private readonly User user;

        public List<Activity> Activities { get; }
        public List<Exercise> Exercises { get; }

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть Null.", nameof(user));

            Activities = GetAllActivities();
            Exercises = GetAllExercises();
        }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);

            if (act == null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);
                SaveActivities();
                SaveExercises();
            }
            else
            {
                var exercise = new Exercise(begin, end, act, user);
                Exercises.Add(exercise);                
                SaveExercises();
            }
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(EXERCISES_FILE_NAME) ?? new List<Activity>();
        }

        private void SaveExercises()
        {
            Save(EXERCISES_FILE_NAME, Exercises);
        }
        private void SaveActivities()
        {
            Save(ACTIVITIES_FILE_NAME, Activities);
        }
    }
}
