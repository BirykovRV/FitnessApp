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
        public int Id { get; set; }
        public DateTime Star { get; set; }

        public DateTime Finish { get; set; }

        public int ActivityId { get; set; }

        public virtual Activity Activity { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public Exercise(DateTime star, DateTime finish, Activity activity, User user)
        {
            Star = star;
            Finish = finish;
            Activity = activity ?? throw new ArgumentNullException("Активность не может быть null.", nameof(activity));
            User = user ?? throw new ArgumentNullException("Пользователь не можеть быть null.", nameof(user));
        }
    }
}
