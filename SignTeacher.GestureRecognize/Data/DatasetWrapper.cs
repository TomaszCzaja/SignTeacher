using System.Collections.Generic;
using System.Diagnostics;
using SignTeacher.GestureRecognize.Excel.Interface;
using SignTeacher.Model.Dataset;

namespace SignTeacher.GestureRecognize.Data
{
    public class DatasetWrapper : IDatasetWrapper
    {
        private readonly IExcelExporter _excelExporter;

        public DatasetWrapper(IExcelExporter excelExporter)
        {
            _excelExporter = excelExporter;

            this.LeapMotionDatasets = new List<SignTeacherDataset>();
        }

        private List<SignTeacherDataset> LeapMotionDatasets { get; }


        public void Add(SignTeacherDataset signTeacherDataset)
        {
            LeapMotionDatasets.Add(signTeacherDataset);
        }

        public void ExportDataset()
        {
            _excelExporter.Export(this.LeapMotionDatasets, nameof(LeapMotionDatasets), nameof(LeapMotionDatasets));
            Debug.WriteLine("Dataset exported to excel");
        }
    }
}