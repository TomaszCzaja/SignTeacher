using Autofac;
using Leap;
using SignTeacher.UI.Data;
using SignTeacher.UI.Data.Interface;
using SignTeacher.UI.LeapMotion;
using SignTeacher.UI.LeapMotion.Interface;
using SignTeacher.UI.ViewModel;
using SignTeacher.UI.ViewModel.Interface;

namespace SignTeacher.UI
{
    public class UiServicesRegistry : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<UserDetailViewModel>().As<IUserDetailViewModel>();

            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();
            builder.RegisterType<UserDataService>().As<IUserDataService>();

            builder.RegisterType<Controller>().AsSelf().SingleInstance();
            builder.RegisterType<FrameHandler>().As<IFrameHandler>();
        }
    }
}