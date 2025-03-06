using ComplexNumbersOperations.Operations;

namespace ComplexNumbersOperations.Factories
{
    public class SubtractOperationFactory : OperationFactory
    {
        public override IComplexOperation CreateOperation(ComplexNumber left, ComplexNumber right)
        {
            return new SubtractComplexOperation(left, right);
        }
    }
}