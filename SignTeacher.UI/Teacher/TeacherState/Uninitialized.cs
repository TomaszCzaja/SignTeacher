using System;
using System.Collections.Generic;
using System.Linq;
using SignTeacher.Model.AppModel;
using SignTeacher.Model.Enum;
using SignTeacher.UI.Event;
using SignTeacher.UI.Teacher.Interface;

namespace SignTeacher.UI.Teacher.TeacherState
{
    public class Uninitialized : ITeacherState
    {
        public Uninitialized()
        {
        }

        public Uninitialized(TeacherStateDetails teacherStateDetails)
        {
            StateDetails = teacherStateDetails;
        }

        public TeacherStateDetails StateDetails { get; }

        private Random Random { get; } = new Random();

        public ITeacherState HandleDecision(AfterFrameHandleEventArgs afterFrameHandleEventArgs)
        {
            var outputClasses = Enum.GetValues(typeof(OutputClass));
            var currentLetter = GetCurrentLetter(outputClasses);
            var lettersToKnow = GetLettersToKnow(outputClasses);

            var stateDetails = new TeacherStateDetails()
            {
                CurrentLetter = currentLetter,
                LettersToKnow = lettersToKnow,
                Score = 0
            };

            return new Active(stateDetails);
        }

        private List<string> GetLettersToKnow(Array outputClasses)
            => outputClasses.Cast<OutputClass>().Select(x => x.ToString()).ToList();

        private string GetCurrentLetter(Array outputClasses)
            => outputClasses.GetValue(Random.Next(outputClasses.Length)).ToString();
    }
}