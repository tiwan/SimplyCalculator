using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplyCalculator_v2.MathOperation.Transformation
{
    public class DefaultTransformationStrategies : ITransformationStrategies
    {
        public void TransformOrginalExpresion(List<string> result, List<string> orginalExpresion, int indexOfOperator)
        {
            orginalExpresion[indexOfOperator + 1] = result.First();
            orginalExpresion.RemoveAt(indexOfOperator);
            orginalExpresion.RemoveAt(indexOfOperator - 1);
        }
    }
}
