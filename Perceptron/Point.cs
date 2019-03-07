using System;

namespace JS_Perceptron_Project
{

    public class Point : Input
    {
        private double x;
        private double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public int GetLabel(Function linFunc)
        {
            return (y >= linFunc.GetValue(x)) ? 1 : -1;
        }

        public double[] GetInputs()
        {
            return new double[]{ this.x, this.y };
        }

        public override string ToString()
        {
            return string.Format("P(x = {0}, y = {1})", this.x, this.y);
        }

    }

}

