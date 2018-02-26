using System;
using System.Data;
using System.Linq;
using System.Reflection;
using Accord.IO;
using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.Math;
using SignTeacher.GestureRecognize.MachineLearning.Interface;
using SignTeacher.Model;
using SignTeacher.Model.Enum;

namespace SignTeacher.GestureRecognize.MachineLearning
{
    public class DecisionTreesClassifier : IClassifier
    {
        private DecisionTree DecisionTree { get; set; }

        public void Learn()
        {
            DataTable dataSet = new ExcelReader("DataSet.xls").GetWorksheet("DataSet");
            var controllerOutputProperties = typeof(ControllerOutput)
                .GetProperties()
                .Select(x => x.Name)
                .ToArray();

            var inputs = dataSet.ToJagged<double>(controllerOutputProperties);
            var outputs = dataSet.Columns["Class"]
                .ToArray<string>()
                .Select(x => Enum.Parse(typeof(OutputClass), x) as OutputClass?)
                .Where(x => x.HasValue)
                .Select(x => (int) x)
                .ToArray();

            var teacher = new C45Learning();

            foreach (var controllerOutputProperty in controllerOutputProperties)
            {
                teacher.Attributes.Add(DecisionVariable.Continuous(controllerOutputProperty));
            }

            teacher.Join = 0;

            DecisionTree = teacher.Learn(inputs, outputs);
        }

        public int Decide(ControllerOutput controllerOutput)
        {
            var input = controllerOutput
                .GetType()
                .GetProperties()
                .Select(x =>
                {
                    var value = x.GetValue(controllerOutput) as float?;
                    return value;
                })
                .Where(x => x.HasValue)
                .Select(x => x.Value)
                .ToArray();

            var result = DecisionTree.Decide(input);

            return result;
        }
    }
}