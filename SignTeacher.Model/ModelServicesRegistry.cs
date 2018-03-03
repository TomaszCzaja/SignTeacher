using Autofac;
using SignTeacher.Model.Builder;
using SignTeacher.Model.Builder.Interface;

namespace SignTeacher.Model
{
    public class ModelServicesRegistry : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ControllerOutputBuilder>().As<IControllerOutputBuilder>();
        }
    }
}