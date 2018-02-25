using System.Collections.Generic;
using SignTeacher.Model;

namespace SignTeacher.GestureRecognize.Data
{
    public interface IDatasetWrapper
    {
        void Add(SignTeacherDataset signTeacherDataset);
        void ExportDataset();
    }
}