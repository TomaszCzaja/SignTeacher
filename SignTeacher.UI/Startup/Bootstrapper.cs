using Autofac;
using Prism.Events;
using SignTeacher.DataAccess;
using SignTeacher.GestureRecognize;

namespace SignTeacher.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<UiServicesRegistry>();
            builder.RegisterModule<DataAccessServicesRegistry>();
            builder.RegisterModule<GestureRecognizeServicesRegistry>();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            return builder.Build();
        }
    }
}