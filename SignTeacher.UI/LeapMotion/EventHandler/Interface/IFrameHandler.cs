using Leap;

namespace SignTeacher.UI.LeapMotion.EventHandler.Interface
{
    public interface IFrameHandler
    {
        void Handle(object sender, FrameEventArgs eventArgs);
    }
}