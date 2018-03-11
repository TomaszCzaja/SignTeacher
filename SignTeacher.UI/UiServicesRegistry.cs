using Autofac;
using Leap;
//using SignTeacher.UI.Data;
//using SignTeacher.UI.Data.Interface;
using SignTeacher.UI.LeapMotion.Data;
using SignTeacher.UI.LeapMotion.Data.Interface;
using SignTeacher.UI.LeapMotion.EventHandler;
using SignTeacher.UI.LeapMotion.EventHandler.Interface;
using SignTeacher.UI.Teacher.Interface;
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

            builder.RegisterType<TeacherViewModel>()
                .Keyed<IDetailViewModel>(nameof(TeacherViewModel));
            builder.RegisterType<ModelTrainerViewModel>()
                .Keyed<IDetailViewModel>(nameof(ModelTrainerViewModel));

            builder.RegisterType<Teacher.Teacher>().As<ITeacher>().SingleInstance();

            //builder.RegisterType<LookupDataService>().AsImplementedInterfaces();
            //builder.RegisterType<UserDataService>().As<IUserDataService>();

            builder.RegisterType<Controller>().AsSelf().SingleInstance();
            builder.RegisterType<ModelTrainerFrameHandler>().As<IModelTrainerFrameHandler>();
            builder.RegisterType<DecisionMakerFrameHandler>().As<IDecisionMakerFrameHandler>();
            builder.RegisterType<ControllerOutputService>().As<IControllerOutputService>();
        }
    }
}