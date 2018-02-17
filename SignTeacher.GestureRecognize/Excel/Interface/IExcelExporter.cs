using System.Collections.Generic;
using System.IO;

namespace SignTeacher.GestureRecognize.Excel.Interface
{
    public interface IExcelExporter
    {
        FileInfo CreateExcelFile(string fileName);

        void Export<T>(IEnumerable<T> collection, FileInfo file, string workSheetName);

        void Export<T>(IEnumerable<T> collection, string filename, string workSheetName);
    }
}