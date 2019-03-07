using System;
using System.Collections.Generic;

namespace JS_Perceptron_Project { 

    public class Perceptron
    {
        private static readonly Random random = new Random();

        private double[] weights;
        private double learningRate;

        public Perceptron(int inputCount, double learningRate = 0.1)
	    {
            weights = new double[inputCount];
            initWeights(weights);
            this.learningRate = learningRate;
        }

        private static void initWeights(double[] weights)
        {
            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = RandomNumberBetween(-1, 1);
            }
        }

        public int Guess(double[] inputs)
        {
            double sum = 0;

            for (int i = 0; i < weights.Length; i++)
            {
                sum += weights[i] * inputs[i];
            }

            return Activate(sum);
        }

        private int Activate(double signal)
        {
            if (signal >= 0)
            {
                return 1;
            }
            return -1;
        }

        public bool Train(double[] inputs, int target)
        {
            int guess = Guess(inputs);
            int error = target - guess;

            if (guess != target)
            {
                for (int i = 0; i < inputs.Length; i++)
                {
                    weights[i] += error * inputs[i] * learningRate;
                }
                return true;
            }

            return false;
        }

        private static double RandomNumberBetween(double minValue, double maxValue)
        {
            var next = random.NextDouble();
            return minValue + (next * (maxValue - minValue));
        }

        public int Run<T>(IEnumerable<T> inputs, IFunction linFunc, bool initial = false) where T : IInput
        {
            int totalError = 0;
            
            foreach (IInput input in inputs)
            {
                int guess = Guess(input.GetInputs());
                int label = input.GetLabel(linFunc);
                double funcVal = linFunc.GetValue(input.GetInputs()[0]);
                string pointInfo = input.ToString();
                bool error = false;

                if( initial == true ) { 
                    if ( guess != label )
                    {
                        totalError++;
                        error = true; 
                    }
                }
                else
                {
                    if ( Train(input.GetInputs(), label) )
                    {
                        totalError++;
                        error = true;
                    }
                }

                Report(guess, label, funcVal, pointInfo, error);
            }

            return totalError;
        }

        public void Report(int guess, int label, double funcVal, string pointInfo, bool error = false)
        {
            if( error ) Console.ForegroundColor = ConsoleColor.DarkRed;
            else Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(pointInfo + "\t");
            Console.Write(" F(x) = " + funcVal + "\t");
            Console.Write(" Prawidlowy wynik: " + label + "\t");
            Console.Write(" Perceptron przewidzial: " + guess + "\n");
        }
    }

}