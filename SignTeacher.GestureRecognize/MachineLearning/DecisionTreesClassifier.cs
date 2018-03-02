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
            var inputs = GetLearnInputs();
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
            var inputs = GetDecideInputs(controllerOutput);
            var result = DecisionTree.Decide(inputs);

            return result;
        }
    }
}