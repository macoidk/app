using ComplexNumbersOperations.Operations;

namespace ComplexNumbersOperations.Factories
{
    public abstract class OperationFactory
    {
        public abstract IComplexOperation CreateOperation(ComplexNumber left, ComplexNumber right);
    }
}