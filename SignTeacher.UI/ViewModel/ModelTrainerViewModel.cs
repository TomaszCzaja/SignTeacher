using System;
using System.Windows.Input;
using Leap;
using Prism.Commands;
using SignTeacher.GestureRecognize.Wrapper.Interface;
using SignTeacher.Model.Enum;
using SignTeacher.UI.LeapMotion.Interface;
using SignTeacher.UI.ViewModel.Interface;

namespace SignTeacher.UI.ViewModel
{
    public class ModelTrainerViewModel : IModelTrainerViewModel
    {
        private readonly IModelTrainerFrameHandler _modelTrainerHandler;
        private readonly IDatasetWrapper _datasetWrapper;
        private readonly Controller _controller;

        public ModelTrainerViewModel(
            IModelTrainerFrameHandler modelTrainerFrameHandler, 
            Controller controller, 
            IDatasetWrapper datasetWrapper)
        {
            _controller = controller;
            _datasetWrapper = datasetWrapper;
            _modelTrainerHandler = modelTrainerFrameHandler;

            _controller.FrameReady += _modelTrainerHandler.Handle;

            ChooseClassCommand = new DelegateCommand<OutputClass?>(OnChooseClassCommand);
            SaveDataSet = new DelegateCommand(OnSaveDataSet);
        }

        public ICommand ChooseClassCommand { get; }

        public ICommand SaveDataSet { get; }

        public void UpdateLeapMotionHandler()
        {
            _controller.FrameReady -= _modelTrainerHandler.Handle;
        }

        private void OnChooseClassCommand(OutputClass? outputClass)
        {
            if (!outputClass.HasValue) throw new ArgumentException("ChooseClassCommand parameter can't be null");

            _datasetWrapper.OutputClass = outputClass.Value;
        }

        private void OnSaveDataSet()
        {
            _datasetWrapper.ExportDataset();
        }
    }
}