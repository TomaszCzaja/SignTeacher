using SignTeacher.Model.Enum;

namespace SignTeacher.Model.AppModel
{
    public class DataSetInstance
    {
        public float GrabAngle { get; set; }

        public float IsThumbExtended { get; set; }

        public float IsIndexExtended { get; set; }

        public float IsMiddleExtended { get; set; }

        public float IsRingExtended { get; set; }

        public float IsPinkyExtended { get; set; }

        public OutputClass Class { get; set; }

        public void SetClass(OutputClass outputClass)
        {
            Class = outputClass;
        }
    }
}