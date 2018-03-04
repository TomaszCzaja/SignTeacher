using System.Collections.Generic;
using System.Diagnostics;
using AutoMapper;
using SignTeacher.GestureRecognize.Excel.Interface;
using SignTeacher.GestureRecognize.Wrapper.Interface;
using SignTeacher.Model.AppModel;
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
            var dataSetInstance = Mapper.Map<DataSetInstance>(controllerOutput);
            dataSetInstance.SetClass(OutputClass);

            DataSet.Add(dataSetInstance);
        }

        public void ExportDataset()
        {
            _excelExporter.Export(this.DataSet, nameof(DataSet), nameof(DataSet));
            Debug.WriteLine("DataSet exported to excel");
        }
    }
}