using SignTeacher.Model;
using SignTeacher.Model.Enum;

namespace SignTeacher.GestureRecognize.Wrapper.Interface
{
    public interface IDatasetWrapper
    {
        void Add(DataSetInstance dataSetInstance);
        void ExportDataset();
        OutputClass OutputClass { get; set; }
    }
}