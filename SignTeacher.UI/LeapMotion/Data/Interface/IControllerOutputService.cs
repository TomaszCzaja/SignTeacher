using Leap;
using SignTeacher.Model.AppModel;

namespace SignTeacher.UI.LeapMotion.Data.Interface
{
    public interface IControllerOutputService
    {
        ControllerOutput GetControllerOutput(Hand hand);
    }
}