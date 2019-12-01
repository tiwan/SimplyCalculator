using SimplyCalculator_v2.MathOperationService;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplyCalculator_v2.MathOperation
{
    public class OperationFactory : IOperationFactory
    {
        public IOperation CreateOperation(OperationEnum operation)
        {
            switch (operation)
            {
                case OperationEnum.Division:
                    return new DivisionOperation();
                case OperationEnum.Add:
                    return new AddOperation();
                case OperationEnum.Multiplication:
                    return new MultiplicationOperation();
                case OperationEnum.Subtract:
                    return new SubtractOperation();
                default:
                    throw new Exception("Operation not found");
            }
        }
    }

    public enum OperationEnum
    {
        Division,
        Add,
        Multiplication,
        Subtract
    }
}
