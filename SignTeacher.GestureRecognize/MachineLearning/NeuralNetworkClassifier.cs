﻿using System;
using Accord.Math;
using Accord.Neuro;
using Accord.Neuro.Learning;
using SignTeacher.GestureRecognize.MachineLearning.Interface;
using SignTeacher.Model.AppModel;
using SignTeacher.Model.Enum;

namespace SignTeacher.GestureRecognize.MachineLearning
{
    public class NeuralNetworkClassifier: ClassifierBase, IClassifier
    {
        private ActivationNetwork NeuralNetwork { get; set; }

        public void Learn()
        {
            const int hiddenNeurons = 5;
            var numberOfInputs = GetControllerOutputProperties().Length;
            var numberOfClasses = Enum.GetNames(typeof(OutputClass)).Length;

            var outputs = Accord.Statistics.Tools.Expand(GetOutputs(), numberOfClasses, -1, 1);
            var inputs = GetLearnInputs();

            var activationFunction = new BipolarSigmoidFunction(2);
            NeuralNetwork = new ActivationNetwork(activationFunction, numberOfInputs, hiddenNeurons, numberOfClasses);

            new NguyenWidrow(NeuralNetwork).Randomize();

            var teacher = new LevenbergMarquardtLearning(NeuralNetwork);

            for (var i = 0; i < 10; i++)
                teacher.RunEpoch(inputs, outputs);
        }

        public int Decide(ControllerOutput controllerOutput)
        {
            var inputs = GetDecideInputs(controllerOutput);
            var output = NeuralNetwork.Compute(inputs).Max(out var result);

            return result;
        }
    }
}