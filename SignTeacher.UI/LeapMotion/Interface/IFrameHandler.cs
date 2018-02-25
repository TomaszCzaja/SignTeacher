using Leap;

namespace SignTeacher.UI.LeapMotion.Interface
{
    public interface IFrameHandler
    {
        void Handle(object sender, FrameEventArgs eventArgs);
    }
}