﻿using System;
using System.Diagnostics;
using Leap;
using SignTeacher.UI.LeapMotion.Interface;

namespace SignTeacher.UI.LeapMotion
{
    public abstract class FrameHandlerBase : IFrameHandler
    {
        public void Handle(object sender, FrameEventArgs eventArgs)
        {
            try
            {
                if (eventArgs.frame.Id % 500 == 0)
                {
                    OnHandle(sender, eventArgs);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Somethink went wrong. Message: " + e.Message);
            }
        }

        protected abstract void OnHandle(object sender, FrameEventArgs eventArgs);
    }
}