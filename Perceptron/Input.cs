using System;

namespace JS_Perceptron_Project { 

    public interface IInput
    {
        double[] GetInputs();
        int GetLabel(IFunction linFunc);
    }

}