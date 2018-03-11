using Prism.Events;
using SignTeacher.Model.AppModel;

namespace SignTeacher.UI.Event
{
    public class TeacherStateChangedEvent : PubSubEvent<TeacherStateChangedArgs>
    {
        
    }

    public class TeacherStateChangedArgs
    {
        public TeacherState State { get; set; }
    }
}