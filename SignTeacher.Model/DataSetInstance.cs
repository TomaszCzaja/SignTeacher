using SignTeacher.Model.Enum;

namespace SignTeacher.Model
{
    public class DataSetInstance
    {
        public DataSetInstance(float grabAngle)
        {
            GrabAngle = grabAngle;
        }

        public float GrabAngle { get; set; }

        public OutputClass Class { get; set; }
    }
}