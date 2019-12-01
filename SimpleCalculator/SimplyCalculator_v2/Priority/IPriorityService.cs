using System.Collections.Generic;
using SimplyCalculator_v2.MathOperationService;

namespace SimplyCalculator_v2.Priority
{
    public interface IPriorityService
    {
        void AddToPiority(int number, IOperation operation);
        List<KeyValuePair<int, IOperation>> GetPiorityList();
    }
}