using SignTeacher.Model.AppModel;
using SignTeacher.UI.Event;

namespace SignTeacher.UI.Teacher.Interface
{
    public interface ITeacherState
    {
        Model.AppModel.TeacherState State { get; }

        ITeacherState HandleDecision(AfterFrameHandleEventArgs afterFrameHandleEventArgs);
    }
}