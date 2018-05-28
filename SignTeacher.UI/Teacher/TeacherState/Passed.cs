using System;
using System.Linq;
using SignTeacher.Model.AppModel;
using SignTeacher.UI.Event;
using SignTeacher.UI.Teacher.Interface;

namespace SignTeacher.UI.Teacher.TeacherState
{
    public class Passed : ITeacherState
    {
        public Passed(Model.AppModel.TeacherState state)
        {
            State = state;
        }

        public Model.AppModel.TeacherState State { get; }

        private Random Random { get; } = new Random();

        public ITeacherState HandleDecision(AfterFrameHandleEventArgs afterFrameHandleEventArgs)
        {
            State.LettersToKnow.Remove(State.CurrentLetter);

            if (!State.LettersToKnow.Any())
            {
                return new Uninitialized(State);
            }

            var currentLetter = State.LettersToKnow[Random.Next(State.LettersToKnow.Count)];

            return new Active(new Model.AppModel.TeacherState()
            {
                CurrentLetter = currentLetter,
                LettersToKnow = State.LettersToKnow,
                Message = "You passed!",
                Score = 0
            });
        }
    }
}