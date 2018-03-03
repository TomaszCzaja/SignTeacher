using System;
using System.Linq;
using Leap;
using SignTeacher.Model.AppModel;
using SignTeacher.Model.Builder.Interface;

namespace SignTeacher.Model.Builder
{
    public class ControllerOutputBuilder : IControllerOutputBuilder
    {
        protected ControllerOutput ControllerOutput { get; set; }

        public ControllerOutput GetControllerOutput(Hand hand)
        {
            CreateControllerOutput(hand);

            return ControllerOutput;
        }

        private void CreateControllerOutput(Hand hand)
        {
            ControllerOutput = new ControllerOutput()
            {
                GrabAngle = hand.GrabAngle,
                IsThumbExtended = IsFingerExtended(hand, Finger.FingerType.TYPE_THUMB),
                IsIndexExtended = IsFingerExtended(hand, Finger.FingerType.TYPE_INDEX),
                IsMiddleExtended = IsFingerExtended(hand, Finger.FingerType.TYPE_MIDDLE),
                IsPinkyExtended = IsFingerExtended(hand, Finger.FingerType.TYPE_PINKY),
                IsRingExtended = IsFingerExtended(hand, Finger.FingerType.TYPE_RING)
            };
        }

        private float IsFingerExtended(Hand hand, Finger.FingerType fingerType)
        {
            var isFingerExtended = hand.Fingers
                .Single(finger => finger.Type == fingerType)
                .IsExtended;

            return Convert.ToSingle(isFingerExtended);
        }
    }
}