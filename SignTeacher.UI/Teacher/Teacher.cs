using Prism.Events;
using SignTeacher.UI.Event;
using SignTeacher.UI.Teacher.Interface;
using SignTeacher.UI.Teacher.TeacherState;

namespace SignTeacher.UI.Teacher
{
    public class Teacher : ITeacher
    {
        private readonly IEventAggregator _eventAggregator;

        public Teacher(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            State = new Uninitialized();

            _eventAggregator.GetEvent<AfterFrameHandleEvent>().Subscribe(OnAfterFrameHandleEvent);
        }

        private ITeacherState State { get; set; }

        private void OnAfterFrameHandleEvent(AfterFrameHandleEventArgs afterFrameHandleEventArgs)
        {
            State = State.HandleDecision(afterFrameHandleEventArgs);

            _eventAggregator
                .GetEvent<TeacherStateChangedEvent>()
                .Publish(
                    new TeacherStateChangedArgs()
                    {
                        Message = State.StateDetails.Message,
                        CurrentLetter = State.StateDetails.CurrentLetter,
                        Score = State.StateDetails.Score
                    });
        }
    }
}