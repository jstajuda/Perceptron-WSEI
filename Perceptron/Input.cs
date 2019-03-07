using System;

namespace JS_Perceptron_Project { 

    public interface Input
    {
        double[] GetInputs();
        int GetLabel(Function linFunc);
    }

}