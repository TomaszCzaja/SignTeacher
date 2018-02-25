using SignTeacher.Model;

namespace SignTeacher.GestureRecognize.MachineLearning.Interface
{
    public interface IClassifier
    {
        int Decide(ControllerOutput controllerOutput);
        void Learn();
    }
}