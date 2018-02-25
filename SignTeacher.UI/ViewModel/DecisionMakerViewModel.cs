using Leap;
using SignTeacher.UI.LeapMotion.Interface;
using SignTeacher.UI.ViewModel.Interface;

namespace SignTeacher.UI.ViewModel
{
    public class DecisionMakerViewModel : IDecisionMakerViewModel
    {
        private readonly IDecisionMakerFrameHandler _decisionMakerFrameHandler;
        private readonly Controller _controller;

        public DecisionMakerViewModel(
            IDecisionMakerFrameHandler decisionMakerFrameHandler,
            Controller controller)
        {
            _controller = controller;
            _decisionMakerFrameHandler = decisionMakerFrameHandler;

            _controller.FrameReady += _decisionMakerFrameHandler.Handle;
        }

        public void UpdateLeapMotionHandler()
        {
            _controller.FrameReady -= _decisionMakerFrameHandler.Handle;
        }
    }
}