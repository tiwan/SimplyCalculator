using SimplyCalculator_v2.MathOperation;
using SimplyCalculator_v2.MathOperation.Transformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplyCalculator_v2.MathOperationService
{
    public interface IOperation
    {
        List<string> Calculate(IEnumerable<string> evaluationInput, int positionOfChar);
        string GetOperationSymbol();
        ITransformationStrategies GetTransformation();
    }
}
