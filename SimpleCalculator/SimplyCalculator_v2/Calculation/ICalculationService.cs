using System.Collections.Generic;
using SimplyCalculator_v2.Priority;

namespace SimplyCalculator_v2.Calculation
{
    public interface ICalculationService
    {
        List<string> Calculate(List<string> evaluationInput, IPriorityService priority);
    }
}