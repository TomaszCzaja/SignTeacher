using System.Diagnostics;
using Leap;
using SignTeacher.UI.LeapMotion.Interface;

namespace SignTeacher.UI.LeapMotion
{
    public class ModelTrainerFrameHandler : FrameHandlerBase, IModelTrainerFrameHandler
    {
        protected override void OnHandle(object sender, FrameEventArgs eventArgs)
        {
            //Frame frame = eventArgs.frame;
            //Hand rightHand = frame.Hands.FirstOrDefault(hand => hand.IsRight);

            //if (rightHand == null) throw new ArgumentException("Right hand is required!");
            

            Debug.WriteLine("Trainer");
        }
    }
}