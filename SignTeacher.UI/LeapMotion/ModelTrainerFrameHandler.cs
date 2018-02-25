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
        private readonly IDatasetWrapper _datasetWrapper;

        public ModelTrainerFrameHandler(IDatasetWrapper datasetWrapper)
        {
            _datasetWrapper = datasetWrapper;
        }

        protected override void OnHandle(object sender, FrameEventArgs eventArgs)
        {
            Frame frame = eventArgs.frame;
            Hand rightHand = frame.Hands.FirstOrDefault(hand => hand.IsRight);

            if (rightHand == null) throw new ArgumentException("Right hand is required!");

            _datasetWrapper.Add(new DataSetInstance(rightHand.GrabAngle));
            Debug.WriteLine("Trainer");
        }
    }
}