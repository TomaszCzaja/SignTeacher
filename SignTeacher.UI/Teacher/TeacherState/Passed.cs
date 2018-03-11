using System;
using System.Linq;
using SignTeacher.Model.AppModel;
using SignTeacher.UI.Event;
using SignTeacher.UI.Teacher.Interface;

namespace SignTeacher.UI.Teacher.TeacherState
{
    public class Passed : ITeacherState
    {
        public Passed(TeacherStateDetails stateDetails)
        {
            StateDetails = stateDetails;
        }

        public TeacherStateDetails StateDetails { get; }

        private Random Random { get; } = new Random();

        public ITeacherState HandleDecision(AfterFrameHandleEventArgs afterFrameHandleEventArgs)
        {
            StateDetails.LettersToKnow.Remove(StateDetails.CurrentLetter);

            if (!StateDetails.LettersToKnow.Any())
            {
                return new Uninitialized(StateDetails);
            }

            var currentLetter = StateDetails.LettersToKnow[Random.Next(StateDetails.LettersToKnow.Count)];

            return new Active(new TeacherStateDetails()
            {
                CurrentLetter = currentLetter,
                LettersToKnow = StateDetails.LettersToKnow,
                Message = "You passed!",
                Score = 0
            });
        }
    }
}