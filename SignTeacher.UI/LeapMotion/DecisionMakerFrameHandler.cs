using System;
using System.Diagnostics;
using System.Linq;
using Leap;
using Prism.Events;
using SignTeacher.GestureRecognize.MachineLearning.Interface;
using SignTeacher.Model.AppModel;
using SignTeacher.Model.Enum;
using SignTeacher.UI.Event;
using SignTeacher.UI.LeapMotion.Interface;

namespace SignTeacher.UI.LeapMotion
{
    class DecisionMakerFrameHandler : FrameHandlerBase, IDecisionMakerFrameHandler
    {
        private readonly IClassifier _classifier;
        private readonly IEventAggregator _eventAggregator;

        public DecisionMakerFrameHandler(IClassifier classifier, IEventAggregator eventAggregator)
        {
            _classifier = classifier;
            _eventAggregator = eventAggregator;
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

            var decision = _classifier.Decide(controllerOutput);

            _eventAggregator
                .GetEvent<AfterDecisionEvent>()
                .Publish(
                    new AfterDecisionEventArgs()
                    {
                        OutputClass = (OutputClass) decision
                    });


            Debug.WriteLine(controllerOutput);
        }
    }
}