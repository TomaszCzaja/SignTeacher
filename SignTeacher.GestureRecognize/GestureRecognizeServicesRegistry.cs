using Autofac;
using SignTeacher.GestureRecognize.Excel;
using SignTeacher.GestureRecognize.Excel.Interface;

namespace SignTeacher.GestureRecognize
{
    public class GestureRecognizeServicesRegistry : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ExcelExporter>().As<IExcelExporter>();
        }
    }
}