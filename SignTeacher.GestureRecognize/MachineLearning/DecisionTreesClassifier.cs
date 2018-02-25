using Accord.IO;
using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.Math;
using SignTeacher.Model.Enum;

namespace SignTeacher.GestureRecognize.MachineLearning
{
    public class DecisionTreesClassifier
    {
        private DecisionTree DecisionTree { get; set; }

        public void Learn()
        {
            var dataset = new ExcelReader("Dataset").GetWorksheet("Dataset");

            var inputs = dataset.ToJagged<double>("a");
            var outputs = dataset.Columns["b"].ToArray<OutputClass>();

            C45Learning teacher = new C45Learning(new[] {
                DecisionVariable.Continuous("a"),
            });
        }
    }
}