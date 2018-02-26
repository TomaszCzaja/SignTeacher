using SignTeacher.Model;
using SignTeacher.Model.Enum;

namespace SignTeacher.GestureRecognize.Wrapper.Interface
{
    public interface IDataSetWrapper
    {
        void Add(ControllerOutput controllerOutput);
        void ExportDataset();
        OutputClass OutputClass { get; set; }
    }
}