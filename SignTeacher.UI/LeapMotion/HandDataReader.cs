using System;
using System.Diagnostics;
using System.Linq;
using Leap;

namespace SignTeacher.UI.LeapMotion
{
    public class HandDataReader : FrameHandlerBase
    {
        protected override void OnHandle(object sender, FrameEventArgs eventArgs)
        {
            Frame frame = eventArgs.frame;
            Hand rightHand = frame.Hands.FirstOrDefault(hand => hand.IsRight);

            if (rightHand == null) throw new ArgumentException("Right hand is required!");
            

            Debug.WriteLine(frame.Timestamp);
        }
    }
}