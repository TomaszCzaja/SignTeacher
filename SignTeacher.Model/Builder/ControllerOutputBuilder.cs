using System;
using System.Linq;
using System.Windows.Media.Media3D;
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
                IsRingExtended = IsFingerExtended(hand, Finger.FingerType.TYPE_RING),
                ThumbIndexAngle =
                    GetAngleBetweenFingers(hand, Finger.FingerType.TYPE_THUMB, Finger.FingerType.TYPE_INDEX),
                IndexMiddleAngle = 
                    GetAngleBetweenFingers(hand, Finger.FingerType.TYPE_INDEX, Finger.FingerType.TYPE_MIDDLE),
                MiddleRingAngle = 
                    GetAngleBetweenFingers(hand, Finger.FingerType.TYPE_MIDDLE, Finger.FingerType.TYPE_RING),
                RingIndexAngle = 
                    GetAngleBetweenFingers(hand, Finger.FingerType.TYPE_RING, Finger.FingerType.TYPE_INDEX)
            };
        }

        private float GetAngleBetweenFingers(
            Hand hand, 
            Finger.FingerType firstFingerType,
            Finger.FingerType secondFingerType)
        {
            var firstFingerLeapVector = GetFinger(hand, firstFingerType).Bone(Bone.BoneType.TYPE_PROXIMAL).Direction;
            var secondFingerLeapVector = GetFinger(hand, secondFingerType).Bone(Bone.BoneType.TYPE_PROXIMAL).Direction;

            var angleBetween = firstFingerLeapVector.AngleTo(secondFingerLeapVector);

            return angleBetween;
        }

        private float IsFingerExtended(Hand hand, Finger.FingerType fingerType)
        {
            var isFingerExtended = GetFinger(hand, fingerType).IsExtended;

            return Convert.ToSingle(isFingerExtended);
        }

        private Finger GetFinger(Hand hand, Finger.FingerType fingerType)
            => hand.Fingers .Single(finger => finger.Type == fingerType);
    }
}