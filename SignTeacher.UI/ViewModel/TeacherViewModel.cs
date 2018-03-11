using System.Linq;
using Leap;
using Prism.Events;
using SignTeacher.UI.Event;
using SignTeacher.UI.LeapMotion.EventHandler.Interface;
using SignTeacher.UI.Teacher.Interface;
using SignTeacher.UI.ViewModel.Interface;

namespace SignTeacher.UI.ViewModel
{
    public class TeacherViewModel : ViewModelBase, ITeacherViewModel
    {
        private readonly IDecisionMakerFrameHandler _decisionMakerFrameHandler;
        private readonly Controller _controller;

        private string _displayedImagePath;
        private int _borderThickness;
        private string _message;

        public TeacherViewModel(
            IDecisionMakerFrameHandler decisionMakerFrameHandler,
            Controller controller,
            IEventAggregator eventAggregator,
            ITeacher teacher)
        {
            _controller = controller;
            _decisionMakerFrameHandler = decisionMakerFrameHandler;

            CheckControllerStatus();

            _controller.FrameReady += _decisionMakerFrameHandler.Handle;
            eventAggregator.GetEvent<TeacherStateChangedEvent>().Subscribe(OnTeacherStateChangedEvent);
        }

        public string DisplayedImagePath
        {
            get => _displayedImagePath;
            set
            {
                _displayedImagePath = value;
                OnPropertyChanged();
            }
        }

        public int BorderThickness
        {
            get => _borderThickness;
            set
            {
                _borderThickness = value;
                OnPropertyChanged();
            }
        }

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public void UpdateLeapMotionHandler()
        {
            _controller.FrameReady -= _decisionMakerFrameHandler.Handle;
        }

        private void CheckControllerStatus()
        {
            var device = _controller.Devices.FirstOrDefault();

            if (device == null)
            {
                Message = "Please connect LeapMotion controller";
            }
            else if (!device.IsStreaming)
            {
                Message = "Please resume tracking";
            }
            else
            {
                Message = "Controller status OK!";
            }
        }

        private void OnTeacherStateChangedEvent(TeacherStateChangedArgs teacherStateChangedArgs)
        {
            DisplayedImagePath = $"../Resources/{teacherStateChangedArgs.CurrentLetter}.PNG";
            Message = teacherStateChangedArgs.Message;
            BorderThickness = teacherStateChangedArgs.Score;
        }
    }
}