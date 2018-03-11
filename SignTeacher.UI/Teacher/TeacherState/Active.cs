using SignTeacher.Model.AppModel;
using SignTeacher.UI.Event;
using SignTeacher.UI.Teacher.Interface;

namespace SignTeacher.UI.Teacher.TeacherState
{
    public class Active : ITeacherState
    {
        public Active(TeacherStateDetails stateDetails)
        {
            StateDetails = stateDetails;
        }

        public TeacherStateDetails StateDetails { get; set; }

        public ITeacherState HandleDecision(AfterFrameHandleEventArgs afterFrameHandleEventArgs)
        {
            if (afterFrameHandleEventArgs.ErrorMessage != null)
            {
                return new Active(new TeacherStateDetails()
                {
                    CurrentLetter = StateDetails.CurrentLetter,
                    LettersToKnow = StateDetails.LettersToKnow,
                    Message = afterFrameHandleEventArgs.ErrorMessage,
                    Score = StateDetails.Score
                });
            }

            return CheckResult(afterFrameHandleEventArgs);
        }

        private ITeacherState CheckResult(AfterFrameHandleEventArgs afterFrameHandleEventArgs)
        {
            if (StateDetails.Score > 10)
            {
                return new Passed(StateDetails);
            }

            var outputClass = afterFrameHandleEventArgs.OutputClass.ToString();
            var stateDetails = new TeacherStateDetails()
            {
                CurrentLetter = StateDetails.CurrentLetter,
                LettersToKnow = StateDetails.LettersToKnow,
                Message = StateDetails.Message,
                Score = StateDetails.Score
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