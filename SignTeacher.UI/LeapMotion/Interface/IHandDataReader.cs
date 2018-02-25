using Leap;

namespace SignTeacher.UI.LeapMotion.Interface
{
    public interface IHandDataReader
    {
        void Handle(object sender, FrameEventArgs eventArgs);
    }
}