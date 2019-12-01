using SimplyCalculator_v2.MathOperationService;

namespace SimplyCalculator_v2.MathOperation
{
    public interface IOperationFactory
    {
        IOperation CreateOperation(OperationEnum operation);
    }
}