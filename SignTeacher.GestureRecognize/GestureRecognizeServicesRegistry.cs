using Autofac;
using SignTeacher.GestureRecognize.Data;
using SignTeacher.GestureRecognize.Excel;
using SignTeacher.GestureRecognize.Excel.Interface;

namespace SignTeacher.GestureRecognize
{
    public class GestureRecognizeServicesRegistry : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ExcelExporter>().As<IExcelExporter>();
            builder.RegisterType<DatasetWrapper>().As<IDatasetWrapper>().SingleInstance();
        }
    }
}