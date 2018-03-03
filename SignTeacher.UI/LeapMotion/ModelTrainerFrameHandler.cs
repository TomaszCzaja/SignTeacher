using System;
using System.Diagnostics;
using System.Linq;
using Leap;
using SignTeacher.GestureRecognize.Wrapper.Interface;
using SignTeacher.Model.AppModel;
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

            var isThumbExtended = rightHand.Fingers
                .Single(finger => finger.Type == Finger.FingerType.TYPE_THUMB)
                .IsExtended;
            var isIndexExtended = rightHand.Fingers
                .Single(finger => finger.Type == Finger.FingerType.TYPE_INDEX)
                .IsExtended;
            var isRingExtended = rightHand.Fingers
                .Single(finger => finger.Type == Finger.FingerType.TYPE_RING)
                .IsExtended;
            var isMiddleExtended = rightHand.Fingers
                .Single(finger => finger.Type == Finger.FingerType.TYPE_MIDDLE)
                .IsExtended;
            var isPinkyExtended = rightHand.Fingers
                .Single(finger => finger.Type == Finger.FingerType.TYPE_PINKY)
                .IsExtended;

            var controllerOutput = new ControllerOutput()
            {
                GrabAngle = rightHand.GrabAngle,
                IsThumbExtended = Convert.ToSingle(isThumbExtended),
                IsIndexExtended = Convert.ToSingle(isIndexExtended),
                IsMiddleExtended = Convert.ToSingle(isMiddleExtended),
                IsPinkyExtended = Convert.ToSingle(isPinkyExtended),
                IsRingExtended = Convert.ToSingle(isRingExtended)
            };

            _dataSetWrapper.Add(controllerOutput);

            Debug.WriteLine(rightHand.GrabAngle);
        }
    }
}