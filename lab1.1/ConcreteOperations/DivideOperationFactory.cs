using ComplexNumbersOperations.Operations;

namespace ComplexNumbersOperations.Factories
{
    public class DivideOperationFactory : OperationFactory
    {
        public override IComplexOperation CreateOperation(ComplexNumber left, ComplexNumber right)
        {
            return new DivideComplexOperation(left, right);
        }
    }
}