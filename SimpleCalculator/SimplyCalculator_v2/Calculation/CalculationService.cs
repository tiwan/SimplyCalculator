using SimplyCalculator_v2.MathOperationService;
using SimplyCalculator_v2.Priority;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplyCalculator_v2.Calculation
{
    public class CalculationService : ICalculationService
    {
        public List<string> Calculate(List<string> evaluationInput, IPriorityService priority)
        {
            var priorities = priority.GetPiorityList();

            var operationGroupedByPriorities = priorities.GroupBy(p => p.Key).OrderBy(p=> p.Key);

            foreach (var group in operationGroupedByPriorities)
            {
                for (int charPosition = 0; charPosition < evaluationInput.Count(); charPosition++)
                {
                    string currentChar = evaluationInput.ElementAt(charPosition);

                    if (group.Any(g=>g.Value.GetOperationSymbol() == currentChar) )
                    {
                        var concretPriority = GetOperationPriorityGroup(currentChar, group, charPosition);

                        if (concretPriority.Equals(new KeyValuePair<int, IOperation>()))
                            throw new Exception("no operation");

                        var operation = concretPriority.Value;

                        var result = operation.Calculate(evaluationInput, charPosition);

                        var transformationStrategy = operation.GetTransformation();

                        transformationStrategy.TransformOrginalExpresion(result, evaluationInput, charPosition);

                        charPosition = 0;

                    }
                }
            }
               
            return evaluationInput;
        }

        private KeyValuePair<int, IOperation> GetOperationPriorityGroup(string currentChar, IGrouping<int, KeyValuePair<int, IOperation>> group, int positionOfChar)
        {
            return group.FirstOrDefault(g => g.Value.GetOperationSymbol() == currentChar);
        }
    }
}
