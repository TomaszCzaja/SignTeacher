using System.Diagnostics;
using Leap;
using SignTeacher.UI.LeapMotion.Interface;

namespace SignTeacher.UI.LeapMotion
{
    class DecisionMakerFrameHandler : FrameHandlerBase, IDecisionMakerFrameHandler
    {
        protected override void OnHandle(object sender, FrameEventArgs eventArgs)
        {
            Debug.WriteLine("Decision");
        }
    }
}