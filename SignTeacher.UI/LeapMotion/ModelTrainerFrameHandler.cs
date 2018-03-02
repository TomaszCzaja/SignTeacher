using System;
using System.Diagnostics;
using System.Linq;
using Leap;
using SignTeacher.GestureRecognize.Wrapper.Interface;
using SignTeacher.Model;
using SignTeacher.UI.LeapMotion.Interface;

namespace SignTeacher.UI.LeapMotion
{
    public class ModelTrainerFrameHandler : FrameHandlerBase, IModelTrainerFrameHandler
    {
        private readonly IDataSetWrapper _dataSetWrapper;

        public ModelTrainerFrameHandler(IDataSetWrapper dataSetWrapper)
        {
            _dataSetWrapper = dataSetWrapper;
        }

        protected override void OnHandle(object sender, FrameEventArgs eventArgs)
        {
            var frame = eventArgs.frame;
            var rightHand = frame.Hands.FirstOrDefault(hand => hand.IsRight);

            if (rightHand == null) throw new ArgumentException("Right hand is required!");

            _dataSetWrapper.Add(new ControllerOutput()
            {
                GrabAngle = rightHand.GrabAngle
            });

            Debug.WriteLine(rightHand.GrabAngle);
        }
    }
}