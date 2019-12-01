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
                for (int positionOfChar = 0; positionOfChar < evaluationInput.Count(); positionOfChar++)
                {
                    string currentChar = evaluationInput.ElementAt(positionOfChar);

                    if (group.Any(g=>g.Value.GetOperationSymbol() == currentChar) )
                    {
                        var concretPriority = GetOperationPiorityGroup(currentChar, group, positionOfChar);

                        if (concretPriority.Equals(new KeyValuePair<int, IOperation>()))
                            throw new Exception("no operation");

                        var operation = concretPriority.Value;

                        var result = operation.Calculate(evaluationInput, positionOfChar);

                        var transformationStrategy = operation.GetTransformation();

                        transformationStrategy.TransformOrginalExpresion(result, evaluationInput, positionOfChar);

                        positionOfChar = 0;

                    }
                }
            }
               
            return evaluationInput;
        }

        private KeyValuePair<int, IOperation> GetOperationPiorityGroup(string currentChar, IGrouping<int, KeyValuePair<int, IOperation>> group, int positionOfChar)
        {
            return group.FirstOrDefault(g => g.Value.GetOperationSymbol() == currentChar);
        }
    }
}
