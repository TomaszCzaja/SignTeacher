using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SignTeacher.Model.AppModel;

namespace SignTeacher.DataAccess
{
    public class SignTeacherDbContext : DbContext
    {
        public SignTeacherDbContext() : base("SignTeacherDb")
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
