using Autofac;
using SignTeacher.UI.Data;
using SignTeacher.UI.ViewModel;

namespace SignTeacher.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<UserDataService>().As<IUserDataService>();

            return builder.Build();
        }
    }
}