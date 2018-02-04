using Autofac;

namespace SignTeacher.DataAccess
{
    public class DataAccessServicesRegistry : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SignTeacherDbContext>().AsSelf();
        }
    }
}