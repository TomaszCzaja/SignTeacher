using System;
using System.Data;
using System.Linq;
using Accord.IO;
using Accord.Math;
using SignTeacher.Model.AppModel;
using SignTeacher.Model.Enum;

namespace SignTeacher.GestureRecognize.MachineLearning
{
    public abstract class ClassifierBase
    {
        protected double[][] GetLearnInputs()
        {
            var dataSet = GetDataSetFromExcel();
            var controllerOutputProperties = GetControllerOutputProperties();

            var inputs = dataSet.ToJagged<double>(controllerOutputProperties);

            return inputs;
        }

        protected double[] GetDecideInputs(ControllerOutput controllerOutput)
        {
            var result = controllerOutput
                .GetType()
                .GetProperties()
                .Select(x =>
                {
                    var value = x.GetValue(controllerOutput) as float?;
                    return value;
                })
                .Where(x => x.HasValue)
                .Select(x => x.Value)
                .ToArray()
                .ToDouble();

            return result;
        }

        protected int[] GetOutputs()
        {
            var dataSet = GetDataSetFromExcel();

            var outputs = dataSet.Columns["Class"]
                .ToArray<string>()
                .Select(x => Enum.Parse(typeof(OutputClass), x) as OutputClass?)
                .Where(x => x.HasValue)
                .Select(x => (int)x)
                .ToArray();

            return outputs;
        }

        protected string[] GetControllerOutputProperties()
            => typeof(ControllerOutput)
                .GetProperties()
                .Select(x => x.Name)
                .ToArray();

        private DataTable GetDataSetFromExcel()
            => new ExcelReader("DataSet.xls").GetWorksheet("DataSet");
    }
}