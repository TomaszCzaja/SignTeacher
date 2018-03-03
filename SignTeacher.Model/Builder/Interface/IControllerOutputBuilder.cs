using Leap;
using SignTeacher.Model.AppModel;

namespace SignTeacher.Model.Builder.Interface
{
    public interface IControllerOutputBuilder
    {
        ControllerOutput GetControllerOutput(Hand hand);
    }
}