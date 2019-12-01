using System.Collections.Generic;

namespace SimplyCalculator_v2.MathOperation.Transformation
{
    public interface ITransformationStrategies
    {
        void TransformOrginalExpresion(List<string> result, List<string> orginalExpresion, int indexOfOperator);
    }
}