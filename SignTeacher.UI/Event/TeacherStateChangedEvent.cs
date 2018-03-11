using Prism.Events;
using SignTeacher.Model.AppModel;

namespace SignTeacher.UI.Event
{
    public class TeacherStateChangedEvent : PubSubEvent<TeacherStateChangedArgs>
    {
        
    }

    public class TeacherStateChangedArgs
    {
        public string CurrentLetter { get; set; }

        public int Score { get; set; }

        public string Message { get; set; }
    }
}