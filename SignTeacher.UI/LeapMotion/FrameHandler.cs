using System.Diagnostics;
using System.Linq;
using Leap;
using SignTeacher.UI.LeapMotion.Interface;

namespace SignTeacher.UI.LeapMotion
{
    public class FrameHandler : IFrameHandler
    {
        private int count = 0;
        public void Handle(object sender, FrameEventArgs eventArgs)
        {
            Frame frame = eventArgs.frame;
            //The following are Label controls added in design view for the form
            if (frame.Hands.Count == 2)
            {
                count++;
                Debug.WriteLine(count);
            }
        }
    }
}