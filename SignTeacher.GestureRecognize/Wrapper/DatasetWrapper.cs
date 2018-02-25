using System.Collections.Generic;
using System.Diagnostics;
using SignTeacher.GestureRecognize.Excel.Interface;
using SignTeacher.GestureRecognize.Wrapper.Interface;
using SignTeacher.Model;
using SignTeacher.Model.Enum;

namespace SignTeacher.GestureRecognize.Wrapper
{
    public class DatasetWrapper : IDatasetWrapper
    {
        private readonly IExcelExporter _excelExporter;

        public DatasetWrapper(IExcelExporter excelExporter)
        {
            _excelExporter = excelExporter;

            this.Dataset = new List<DataSetInstance>();
        }

        public OutputClass OutputClass { get; set; }

        private List<DataSetInstance> Dataset { get; }

        public void Add(ControllerOutput controllerOutput)
        {
            var dataSetInstance = new DataSetInstance()
            {
                GrabAngle = controllerOutput.GrabAngle,
                Class = OutputClass
            };

            Dataset.Add(dataSetInstance);
        }

        public void ExportDataset()
        {
            _excelExporter.Export(this.Dataset, nameof(Dataset), nameof(Dataset));
            Debug.WriteLine("Dataset exported to excel");
        }
    }
}