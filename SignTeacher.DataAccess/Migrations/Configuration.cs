using System.Data.Entity.Migrations;
using SignTeacher.Model.AppModel;

namespace SignTeacher.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SignTeacherDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SignTeacherDbContext context)
        {
            context.Users.AddOrUpdate(
                f => f.FirstName,
                new User() { FirstName = "Thomas", LastName = "Huber" },
                new User() { FirstName = "Andreas", LastName = "Boehler" },
                new User() { FirstName = "Julia", LastName = "Huber" },
                new User() { FirstName = "Chrissi", LastName = "Egin" }
            );
        }
    }
}
