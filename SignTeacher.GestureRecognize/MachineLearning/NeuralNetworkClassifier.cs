using System.Linq;
using Accord.Math;
using Accord.Neuro;
using Accord.Neuro.Learning;
using SignTeacher.GestureRecognize.MachineLearning.Interface;
using SignTeacher.Model;

namespace SignTeacher.GestureRecognize.MachineLearning
{
    public class NeuralNetworkClassifier: ClassifierBase, IClassifier
    {
        private ActivationNetwork NeuralNetwork { get; set; }

        public void Learn()
        {
            const int numberOfInputs = 1;
            const int numberOfClasses = 3;
            const int hiddenNeurons = 5;

            var outputs = Accord.Statistics.Tools.Expand(GetOutputs(), numberOfClasses, -1, 1);
            var inputs = GetInputs();

            var activationFunction = new BipolarSigmoidFunction(2);
            NeuralNetwork = new ActivationNetwork(activationFunction, numberOfInputs, hiddenNeurons, numberOfClasses);

            new NguyenWidrow(NeuralNetwork).Randomize();

            var teacher = new LevenbergMarquardtLearning(NeuralNetwork);

            for (var i = 0; i < 10; i++)
                teacher.RunEpoch(inputs, outputs);
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
                .ToArray()
                .ToDouble();

            var output = NeuralNetwork.Compute(inputs).Max(out var result);

            return result;
        }
    }
}