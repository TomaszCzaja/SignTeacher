using Autofac;
using SignTeacher.DataAccess;

namespace SignTeacher.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<UiServicesRegistry>();
            builder.RegisterModule<DataAccessServicesRegistry>();

            return builder.Build();
        }
    }
}