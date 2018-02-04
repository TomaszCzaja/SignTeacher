using Autofac;
using SignTeacher.UI.Data;
using SignTeacher.UI.ViewModel;

namespace SignTeacher.UI
{
    public class UiServicesRegistry : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<UserDataService>().As<IUserDataService>();
        }
    }
}