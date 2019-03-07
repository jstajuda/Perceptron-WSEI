using System;

namespace JS_Perceptron_Project { 

    public class LinearFunction : IFunction
    {
        private double a;
        private double b;

	    public LinearFunction(double a, double b)
	    {
            this.a = a;
            this.b = b;
	    }

        public double GetValue(double x)
        {
            return x * a + b;
        }

        public override string ToString()
        {
            string strA = "";
            if (b == 0) strA = "0";
            string strB = "";

            if( a != 0 )
            {
                if( a != 1) strA = string.Format("{0}x", a);
                else strA = string.Format("x");
            }

            if (b != 0)
            {
                if( b > 0) strB = string.Format("+ {0}", b);
                else if(b < 0) strB = string.Format("{0}", b);
            }

            return string.Format("Funkcja f(x) = {0} {1}", strA, strB);
        }
    }

}