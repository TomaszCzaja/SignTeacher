using Autofac;
using SignTeacher.GestureRecognize.Excel;
using SignTeacher.GestureRecognize.Excel.Interface;
using SignTeacher.GestureRecognize.MachineLearning;
using SignTeacher.GestureRecognize.MachineLearning.Interface;
using SignTeacher.GestureRecognize.Wrapper;
using SignTeacher.GestureRecognize.Wrapper.Interface;

namespace SignTeacher.GestureRecognize
{
    public class GestureRecognizeServicesRegistry : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ExcelExporter>().As<IExcelExporter>();
            builder.RegisterType<DataSetWrapper>().As<IDataSetWrapper>().SingleInstance();
            builder.RegisterType<NeuralNetworkClassifier>().As<IClassifier>().SingleInstance();
        }
    }
}