using Prism.Events;
using SignTeacher.Model.Enum;

namespace SignTeacher.UI.Event
{
    public class AfterFrameHandleEvent : PubSubEvent<AfterFrameHandleEventArgs>
    {
        
    }

    public class AfterFrameHandleEventArgs
    {
        public OutputClass OutputClass { get; set; }

        public string ErrorMessage { get; set; }    
    }
}