using System;
using System.Diagnostics;
using System.Linq;
using Leap;
using Prism.Events;
using SignTeacher.GestureRecognize.MachineLearning.Interface;
using SignTeacher.Model;
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
            Frame frame = eventArgs.frame;
            Hand rightHand = frame.Hands.FirstOrDefault(hand => hand.IsRight);

            if (rightHand == null) throw new ArgumentException("Right hand is required!");

            var decision = _classifier.Decide(new ControllerOutput() { GrabAngle = rightHand.GrabAngle });

            _eventAggregator
                .GetEvent<AfterDecisionEvent>()
                .Publish(
                    new AfterDecisionEventArgs()
                    {
                        OutputClass = (OutputClass) decision
                    });

            Debug.WriteLine(decision);
        }
    }
}