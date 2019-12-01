using SimplyCalculator_v2.MathOperationService;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplyCalculator_v2.Priority
{
    public class PriorityService : IPriorityService
    {
        List<KeyValuePair<int, IOperation>> _piorityList = new List<KeyValuePair<int, IOperation>>();

        public void AddToPiority(int number, IOperation operation)
        {
            _piorityList.Add(new KeyValuePair<int, IOperation>( number, operation));
        }

        public List<KeyValuePair<int, IOperation>> GetPiorityList()
        {
            return _piorityList;
        }
    }
}
