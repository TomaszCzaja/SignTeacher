using System;
using System.Linq;
using Prism.Events;
using SignTeacher.Model.AppModel;
using SignTeacher.Model.Enum;
using SignTeacher.UI.Event;
using SignTeacher.UI.Service.Interface;

namespace SignTeacher.UI.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly IEventAggregator _eventAggregator;

        public TeacherService(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<AfterFrameHandleEvent>().Subscribe(OnAfterFrameHandleEvent);
        }

        private TeacherState State { get; set; }

        public Random Random { get; } = new Random();

        public void InitializeState()
        {
            var outputClasses = Enum.GetValues(typeof(OutputClass));

            State = new TeacherState()
            {
                CurrentLetter = outputClasses.GetValue(Random.Next(outputClasses.Length)).ToString(),
                LettersToKnow = outputClasses.Cast<OutputClass>().Select(x => x.ToString()).ToList(),
                Score = 0,
                Passed = false
            };

            OnStateChanged();
        }

        private void OnAfterFrameHandleEvent(AfterFrameHandleEventArgs afterFrameHandleEventArgs)
        {
            if (afterFrameHandleEventArgs.ErrorMessage != null)
            {
                State.Message = afterFrameHandleEventArgs.ErrorMessage;
                OnStateChanged();
                return;
            }

            if (State.Passed)
            {
                GetNextLetter();
            }

            GetUserResult(afterFrameHandleEventArgs);
        }

        private void GetNextLetter()
        {
            State.LettersToKnow.Remove(State.CurrentLetter);
            State.CurrentLetter = State.LettersToKnow[Random.Next(State.LettersToKnow.Count)];
            State.Score = 0;
            State.Message = "Cool! It's correct sign";
            State.Passed = false;

            OnStateChanged();
        }

        private void GetUserResult(AfterFrameHandleEventArgs afterFrameHandleEventArgs)
        {
            var outputClass = afterFrameHandleEventArgs.OutputClass.ToString();

            if (State.CurrentLetter.Equals(outputClass))
            {
                State.Score++;
                State.Message = "Cool! It's correct sign";
                State.Passed = State.Score > 10;
            }
            else
            {
                State.Score = 0;
                State.Message = "Wrong. Try again!";
            }

            OnStateChanged();
        }

        private void OnStateChanged()
        {
            _eventAggregator
                .GetEvent<TeacherStateChangedEvent>()
                .Publish(
                    new TeacherStateChangedArgs()
                    {
                        State = State
                    });
        }
    }
}