using Leap;
using Prism.Events;
using SignTeacher.UI.Event;
using SignTeacher.UI.LeapMotion.EventHandler.Interface;
using SignTeacher.UI.ViewModel.Interface;

namespace SignTeacher.UI.ViewModel
{
    public class DecisionMakerViewModel : ViewModelBase, IDecisionMakerViewModel
    {
        private readonly IDecisionMakerFrameHandler _decisionMakerFrameHandler;
        private readonly Controller _controller;
        private string _classLabel;

        public DecisionMakerViewModel(
            IDecisionMakerFrameHandler decisionMakerFrameHandler,
            Controller controller,
            IEventAggregator eventAggregator)
        {
            _controller = controller;
            _decisionMakerFrameHandler = decisionMakerFrameHandler;

            _controller.FrameReady += _decisionMakerFrameHandler.Handle;
            eventAggregator.GetEvent<AfterDecisionEvent>().Subscribe(OnAfterDecisionEvent);
        }

        public string ClassLabel
        {
            get => _classLabel;
            set
            {
                _classLabel = value;
                OnPropertyChanged();
            }
        }

        public void UpdateLeapMotionHandler()
        {
            _controller.FrameReady -= _decisionMakerFrameHandler.Handle;
        }

        private void OnAfterDecisionEvent(AfterDecisionEventArgs afterDecisionEventArgs)
        {
            ClassLabel = afterDecisionEventArgs.OutputClass.ToString();
        }
    }
}