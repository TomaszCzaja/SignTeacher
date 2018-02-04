using Autofac;
using Prism.Events;
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

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            return builder.Build();
        }
    }
}