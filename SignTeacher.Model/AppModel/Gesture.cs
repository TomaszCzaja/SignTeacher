using SignTeacher.Model.Enum;

namespace SignTeacher.Model.AppModel
{
    public class Gesture : ControllerOutput
    {
        public OutputClass Class { get; set; }

        public void SetClass(OutputClass outputClass)
        {
            Class = outputClass;
        }
    }
}