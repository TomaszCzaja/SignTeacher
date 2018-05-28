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
        }
    }
}
