using System;
using System.Windows.Input;
using Leap;
using Prism.Commands;
using SignTeacher.Model.Enum;
using SignTeacher.UI.LeapMotion.Interface;
using SignTeacher.UI.ViewModel.Interface;

namespace SignTeacher.UI.ViewModel
{
    public class ModelTrainerViewModel : IModelTrainerViewModel
    {
        private readonly IModelTrainerFrameHandler _modelTrainerHandler;
        private readonly Controller _controller;

        public ModelTrainerViewModel(
            IModelTrainerFrameHandler modelTrainerFrameHandler, 
            Controller controller)
        {
            _controller = controller;
            _modelTrainerHandler = modelTrainerFrameHandler;

            _controller.FrameReady += _modelTrainerHandler.Handle;

            SetClassCommand = new DelegateCommand<OutputClass?>(OnSetClassCommand);
        }

        public ICommand SetClassCommand { get; }

        public void UpdateLeapMotionHandler()
        {
            _controller.FrameReady -= _modelTrainerHandler.Handle;
        }

        private void OnSetClassCommand(OutputClass? outputClass)
        {
            if (!outputClass.HasValue) throw new ArgumentException("SetClassCommand parameter can't be null");

            throw new System.NotImplementedException();
        }
    }
}