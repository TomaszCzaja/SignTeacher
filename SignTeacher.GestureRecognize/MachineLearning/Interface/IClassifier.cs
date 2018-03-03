using SignTeacher.Model.AppModel;

namespace SignTeacher.GestureRecognize.MachineLearning.Interface
{
    public interface IClassifier
    {
        int Decide(ControllerOutput controllerOutput);
        void Learn();
    }
}