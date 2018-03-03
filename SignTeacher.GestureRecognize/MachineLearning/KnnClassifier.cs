using Accord.MachineLearning;
using SignTeacher.Model.AppModel;
using IClassifier = SignTeacher.GestureRecognize.MachineLearning.Interface.IClassifier;

namespace SignTeacher.GestureRecognize.MachineLearning
{
    public class KnnClassifier : ClassifierBase, IClassifier
    {
        private KNearestNeighbors KNearestNeighbors { get; set; }

        public void Learn()
        {
            var inputs = GetLearnInputs();
            var outputs = GetOutputs();

            KNearestNeighbors = new KNearestNeighbors(k: 4);
            KNearestNeighbors.Learn(inputs, outputs);
        }

        public int Decide(ControllerOutput controllerOutput)
        {
            var inputs = GetDecideInputs(controllerOutput);
            var result = KNearestNeighbors.Decide(inputs);

            return result;
        }
    }
}