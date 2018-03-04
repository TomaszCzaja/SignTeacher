using System;
using System.Diagnostics;
using System.Linq;
using Leap;
using SignTeacher.GestureRecognize.Wrapper.Interface;
using SignTeacher.Model.Builder.Interface;
using SignTeacher.UI.LeapMotion.Interface;

namespace SignTeacher.UI.LeapMotion
{
    public class ModelTrainerFrameHandler : FrameHandlerBase, IModelTrainerFrameHandler
    {
        private readonly IDataSetWrapper _dataSetWrapper;
        private readonly IControllerOutputBuilder _controllerOutputBuilder;

        public ModelTrainerFrameHandler(IDataSetWrapper dataSetWrapper, IControllerOutputBuilder controllerOutputBuilder)
        {
            _dataSetWrapper = dataSetWrapper;
            _controllerOutputBuilder = controllerOutputBuilder;
        }

        protected override void OnHandle(object sender, FrameEventArgs eventArgs)
        {
            var frame = eventArgs.frame;
            var rightHand = frame.Hands.FirstOrDefault(hand => hand.IsRight);

            if (rightHand == null) throw new ArgumentException("Right hand is required!");

            var controllerOutput = _controllerOutputBuilder.GetControllerOutput(rightHand);
            _dataSetWrapper.Add(controllerOutput);

            Debug.WriteLine($"{controllerOutput.IndexMiddleAngle} {controllerOutput.MiddleRingAngle} {controllerOutput.ThumbIndexAngle} {controllerOutput.RingPinkyAngle}");
        }
    }
}