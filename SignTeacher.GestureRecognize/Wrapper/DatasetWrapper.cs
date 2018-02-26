using System.Collections.Generic;
using System.Diagnostics;
using SignTeacher.GestureRecognize.Excel.Interface;
using SignTeacher.GestureRecognize.Wrapper.Interface;
using SignTeacher.Model;
using SignTeacher.Model.Enum;

namespace SignTeacher.GestureRecognize.Wrapper
{
    public class DataSetWrapper : IDataSetWrapper
    {
        private readonly IExcelExporter _excelExporter;

        public DataSetWrapper(IExcelExporter excelExporter)
        {
            _excelExporter = excelExporter;

            this.DataSet = new List<DataSetInstance>();
        }

        public OutputClass OutputClass { get; set; }

        private List<DataSetInstance> DataSet { get; }

        public void Add(ControllerOutput controllerOutput)
        {
            var dataSetInstance = new DataSetInstance()
            {
                GrabAngle = controllerOutput.GrabAngle,
                Class = OutputClass
            };

            DataSet.Add(dataSetInstance);
        }

        public void ExportDataset()
        {
            _excelExporter.Export(this.DataSet, nameof(DataSet), nameof(DataSet));
            Debug.WriteLine("DataSet exported to excel");
        }
    }
}