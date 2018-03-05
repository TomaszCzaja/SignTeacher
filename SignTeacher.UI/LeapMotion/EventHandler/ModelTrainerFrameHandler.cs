using System;
using System.Diagnostics;
using System.Linq;
using Leap;
using SignTeacher.GestureRecognize.Wrapper.Interface;
using SignTeacher.UI.LeapMotion.Data.Interface;
using SignTeacher.UI.LeapMotion.EventHandler.Interface;

namespace SignTeacher.UI.LeapMotion.EventHandler
{
    public class ModelTrainerFrameHandler : FrameHandlerBase, IModelTrainerFrameHandler
    {
        private readonly IDataSetWrapper _dataSetWrapper;
        private readonly IControllerOutputService _controllerOutputService;

        public ModelTrainerFrameHandler(IDataSetWrapper dataSetWrapper, IControllerOutputService controllerOutputService)
        {
            _dataSetWrapper = dataSetWrapper;
            _controllerOutputService = controllerOutputService;
        }

        protected override void OnHandle(object sender, FrameEventArgs eventArgs)
        {
            var frame = eventArgs.frame;
            var rightHand = frame.Hands.FirstOrDefault(hand => hand.IsRight);

            if (rightHand == null) throw new ArgumentException("Right hand is required!");

            var controllerOutput = _controllerOutputService.GetControllerOutput(rightHand);
            _dataSetWrapper.Add(controllerOutput);

            Debug.WriteLine($"{controllerOutput.IndexMiddleAngle} {controllerOutput.MiddleRingAngle} {controllerOutput.ThumbIndexAngle} {controllerOutput.RingPinkyAngle}");
        }
    }
}