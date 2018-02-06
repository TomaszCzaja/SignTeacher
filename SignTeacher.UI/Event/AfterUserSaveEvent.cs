using Prism.Events;

namespace SignTeacher.UI.Event
{
    public class AfterUserSaveEvent : PubSubEvent<AfterUserSavedEventArgs>
    {       
    }

    public class AfterUserSavedEventArgs
    {
        public int Id { get; set; }
        public string DisplayMember { get; set; }
    }
}