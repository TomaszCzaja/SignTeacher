using SignTeacher.Model.AppModel;
using SignTeacher.UI.Event;

namespace SignTeacher.UI.Teacher.Interface
{
    public interface ITeacherState
    {
        TeacherStateDetails StateDetails { get; }

        ITeacherState HandleDecision(AfterFrameHandleEventArgs afterFrameHandleEventArgs);
    }
}