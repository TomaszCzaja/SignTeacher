using Prism.Events;
using SignTeacher.Model.Enum;

namespace SignTeacher.UI.Event
{
    public class AfterDecisionEvent : PubSubEvent<AfterDecisionEventArgs>
    {
        
    }

    public class AfterDecisionEventArgs
    {
        public OutputClass OutputClass { get; set; }    
    }
}