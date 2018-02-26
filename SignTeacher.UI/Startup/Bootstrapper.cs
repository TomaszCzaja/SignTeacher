using System.Linq;
using System.Reflection;
using Autofac;
using Prism.Events;

namespace SignTeacher.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            RegisterModules(builder);

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            return builder.Build();
        }

        private static void RegisterModules(ContainerBuilder builder)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var signTeacherAssemblies = executingAssembly
                .GetReferencedAssemblies()
                .Where(x => x.FullName.StartsWith("SignTeacher"))
                .Select(Assembly.Load)
                .ToList();
            signTeacherAssemblies.Add(executingAssembly);
            signTeacherAssemblies.ForEach(x => builder.RegisterAssemblyModules(x));
        }
    }
}