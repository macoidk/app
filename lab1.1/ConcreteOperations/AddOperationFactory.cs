using ComplexNumbersOperations.Operations;

namespace ComplexNumbersOperations.Factories
{
    public class AddOperationFactory : OperationFactory
    {
        public override IComplexOperation CreateOperation(ComplexNumber left, ComplexNumber right)
        {
            return new AddComplexOperation(left, right);
        }
    }
}