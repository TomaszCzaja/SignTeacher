using AutoMapper;
using SignTeacher.Model.AppModel;

namespace SignTeacher.UI.Startup
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ControllerOutput, Gesture>();
            });
        }
    }
}