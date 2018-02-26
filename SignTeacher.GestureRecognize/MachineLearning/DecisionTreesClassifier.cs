using System.Linq;
using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;
using SignTeacher.GestureRecognize.MachineLearning.Interface;
using SignTeacher.Model;

namespace SignTeacher.GestureRecognize.MachineLearning
{
    public class DecisionTreesClassifier : ClassifierBase, IClassifier
    {
        private DecisionTree DecisionTree { get; set; }

        public void Learn()
        {
            var inputs = GetInputs();
            var outputs = GetOutputs();
            var teacher = new C45Learning {Join = 0};

            foreach (var controllerOutputProperty in GetControllerOutputProperties())
            {
                teacher.Attributes.Add(DecisionVariable.Continuous(controllerOutputProperty));
            }

            DecisionTree = teacher.Learn(inputs, outputs);
        }

        public int Decide(ControllerOutput controllerOutput)
        {
            var inputs = controllerOutput
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

            var result = DecisionTree.Decide(inputs);

            return result;
        }
    }
}