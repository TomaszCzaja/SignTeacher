using SignTeacher.Model.AppModel;
using SignTeacher.UI.Event;
using SignTeacher.UI.Teacher.Interface;

namespace SignTeacher.UI.Teacher.TeacherState
{
    public class Active : ITeacherState
    {
        public Active(Model.AppModel.TeacherState state)
        {
            State = state;
        }

        public Model.AppModel.TeacherState State { get; set; }

        public ITeacherState HandleDecision(AfterFrameHandleEventArgs afterFrameHandleEventArgs)
        {
            if (afterFrameHandleEventArgs.ErrorMessage != null)
            {
                return new Active(new Model.AppModel.TeacherState()
                {
                    CurrentLetter = State.CurrentLetter,
                    LettersToKnow = State.LettersToKnow,
                    Message = afterFrameHandleEventArgs.ErrorMessage,
                    Score = State.Score
                });
            }

            return CheckResult(afterFrameHandleEventArgs);
        }

        private ITeacherState CheckResult(AfterFrameHandleEventArgs afterFrameHandleEventArgs)
        {
            if (State.Score > 10)
            {
                return new Passed(State);
            }

            var outputClass = afterFrameHandleEventArgs.OutputClass.ToString();
            var stateDetails = new Model.AppModel.TeacherState()
            {
                CurrentLetter = State.CurrentLetter,
                LettersToKnow = State.LettersToKnow,
                Message = State.Message,
                Score = State.Score
            };

            if (stateDetails.CurrentLetter.Equals(outputClass))
            {
                stateDetails.Score++;
                stateDetails.Message = "Cool! It's correct sign";
            }
            else
            {
                stateDetails.Score = 0;
                stateDetails.Message = "Wrong. Try again!";
            }

            return new Active(stateDetails);
        }
    }
}