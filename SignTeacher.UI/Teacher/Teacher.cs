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

            TeacherState = new Uninitialized();

            _eventAggregator.GetEvent<AfterFrameHandleEvent>().Subscribe(OnAfterFrameHandleEvent);
        }

        private ITeacherState TeacherState { get; set; }

        private void OnAfterFrameHandleEvent(AfterFrameHandleEventArgs afterFrameHandleEventArgs)
        {
            TeacherState = TeacherState.HandleDecision(afterFrameHandleEventArgs);

            _eventAggregator
                .GetEvent<TeacherStateChangedEvent>()
                .Publish(
                    new TeacherStateChangedArgs()
                    {
                        Message = TeacherState.State.Message,
                        CurrentLetter = TeacherState.State.CurrentLetter,
                        Score = TeacherState.State.Score
                    });
        }
    }
}