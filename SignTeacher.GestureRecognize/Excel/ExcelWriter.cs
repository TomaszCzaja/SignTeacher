using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using SignTeacher.GestureRecognize.Excel.Interface;

namespace SignTeacher.GestureRecognize.Excel
{
    public class ExcelExporter : IExcelExporter
    {
        public FileInfo CreateExcelFile(string fileName)
            => new FileInfo(FixFileName(fileName));

        public void Export<T>(IEnumerable<T> collection, string filename, string workSheetName)
            => Export(collection, CreateExcelFile(filename), workSheetName);       

        public void Export<T>(IEnumerable<T> collection, FileInfo file, string workSheetName)
        {
            if(file.Extension != ".xlsx") throw new ArgumentException("Can't export data to excel. Wrong file format");

            DeleteFileIfExist(file);

            using (var excelFile = new ExcelPackage(file))
            {
                var worksheet = excelFile.Workbook.Worksheets.Add(workSheetName);
                worksheet.Cells["A1"].LoadFromCollection(collection, true);
                excelFile.Save();
            }
        }

        private string FixFileName(string fileName)
        {
            if (Path.HasExtension(fileName))
            {
                string ext = Path.GetExtension(fileName);

                if (ext != ".xlsx")
                {
                    fileName = Path.GetFileNameWithoutExtension(fileName) + ".xlsx";
                }
            }
            else
            {
                fileName += ".xlsx";
            }

            return fileName;
        }

        private void DeleteFileIfExist(FileInfo newFile)
        {
            if (newFile.Exists)
            {
                newFile.Delete(); 
            }
        }
    }
}