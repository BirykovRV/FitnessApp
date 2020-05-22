using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public DateTime Star { get; }

        public DateTime Finish { get; }

        public Activity Activity { get; }

        public User User { get; }

        public Exercise(DateTime star, DateTime finish, Activity activity, User user)
        {
            Star = star;
            Finish = finish;
            Activity = activity ?? throw new ArgumentNullException("Активность не может быть null.", nameof(activity));
            User = user ?? throw new ArgumentNullException("Пользователь не можеть быть null.", nameof(user));
        }
    }
}
