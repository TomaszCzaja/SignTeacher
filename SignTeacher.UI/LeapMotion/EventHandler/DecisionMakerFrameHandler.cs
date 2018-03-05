using System;
using System.Diagnostics;
using System.Linq;
using Leap;
using Prism.Events;
using SignTeacher.GestureRecognize.MachineLearning.Interface;
using SignTeacher.Model.Enum;
using SignTeacher.UI.Event;
using SignTeacher.UI.LeapMotion.Data.Interface;
using SignTeacher.UI.LeapMotion.EventHandler.Interface;

namespace SignTeacher.UI.LeapMotion.EventHandler
{
    class DecisionMakerFrameHandler : FrameHandlerBase, IDecisionMakerFrameHandler
    {
        private readonly IClassifier _classifier;
        private readonly IEventAggregator _eventAggregator;
        private readonly IControllerOutputService _controllerOutputService;

        public DecisionMakerFrameHandler(
            IClassifier classifier, 
            IEventAggregator eventAggregator, 
            IControllerOutputService controllerOutputService)
        {
            _classifier = classifier;
            _eventAggregator = eventAggregator;
            _controllerOutputService = controllerOutputService;
        }

        protected override void OnHandle(object sender, FrameEventArgs eventArgs)
        {
            var frame = eventArgs.frame;
            var rightHand = frame.Hands.FirstOrDefault(hand => hand.IsRight);

            if (rightHand == null) throw new ArgumentException("Right hand is required!");

            var controllerOutput = _controllerOutputService.GetControllerOutput(rightHand);
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