using SimplyCalculator_v2.MathOperation;
using SimplyCalculator_v2.MathOperation.Transformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplyCalculator_v2.MathOperationService
{
    public class MultiplicationOperation : IOperation
    {
        public List<string> Calculate(IEnumerable<string> listToCalcualte, int positionOfChar)
        {
            var A = Double.Parse(listToCalcualte.ElementAt(positionOfChar - 1));
            var B = Double.Parse(listToCalcualte.ElementAt(positionOfChar + 1));

            var result = new List<string> { (A * B).ToString() };

            return result;
        }

        public string GetOperationSymbol()
        {
            return "*";
        }

        public ITransformationStrategies GetTransformation()
        {
            return new DefaultTransformationStrategies();
        }
    }
}
