using System;
using System.Data;
using System.Linq;
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
            DataTable dataset = new ExcelReader("Dataset.xls").GetWorksheet("Dataset");

            var inputs = dataset.ToJagged<double>("a");
            var outputs = dataset.Columns["b"]
                .ToArray<string>()
                .Select(x => (OutputClass)Enum.Parse(typeof(OutputClass), x))
                .Select(x => (int) x)
                .ToArray();

            var teacher = new C45Learning();
            teacher.Attributes.Add(DecisionVariable.Continuous("a"));
            teacher.Join = 0;

            DecisionTree = teacher.Learn(inputs, outputs);
        }

        public int Decide(ControllerOutput controllerOutput)
        {
            var input = controllerOutput
                .GetType()
                .GetProperties()
                .Select(p =>
                {
                    var value = p.GetValue(controllerOutput);
                    return (float) value;
                })
                .ToArray();

            var result = DecisionTree.Decide(input);

            return result;
        }
    }
}