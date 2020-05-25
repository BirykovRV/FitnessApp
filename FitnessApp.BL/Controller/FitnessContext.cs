using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Controller
{
    class FitnessContext : DbContext
    {
        public FitnessContext() : base("MSSQLConnection")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Eating> Eatings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Gender> Genders { get; set; }

    }
}
