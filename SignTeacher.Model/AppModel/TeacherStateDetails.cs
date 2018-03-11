using System.Collections.Generic;

namespace SignTeacher.Model.AppModel
{
    public class TeacherStateDetails
    {
        public string CurrentLetter { get; set; }

        public List<string> LettersToKnow { get; set; }

        public int Score { get; set; }

        public string Message { get; set; }
    }
}